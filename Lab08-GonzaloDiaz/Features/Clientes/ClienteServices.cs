using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Lab08_GonzaloDiaz.DTOs;
using Lab08_GonzaloDiaz.Models;
using Lab08_GonzaloDiaz.Repository;

namespace Lab08_GonzaloDiaz.Features.Clientes;

public class ClienteServices : IClienteServices
{
    private readonly IClienteRepository _clients;
    private readonly IOrderRepository _orders;
    private readonly IOrderDetailRepository _details;

    public ClienteServices(
        IClienteRepository clients,
        IOrderRepository orders,
        IOrderDetailRepository details)
    {
        _clients = clients;
        _orders = orders;
        _details = details;
    }

    public async Task<List<Client>> BuscarPorNombreAsync(
        string nombre,
        bool comienzaCon = false)
    {
        var consulta = _clients.Query().AsNoTracking();

        if (comienzaCon)
        {
            consulta = consulta.Where(
                c => c.Name.StartsWith(nombre));
        }
        else
        {
            consulta = consulta.Where(
                c => c.Name.Contains(nombre));
        }

        return await consulta.ToListAsync();
    }

    public async Task<ClientOrderCountDto?>
        ObtenerClienteConMasPedidosAsync()
    {
        var cantidades = _orders.Query()
            .GroupBy(o => o.Clientid)
            .Select(g => new
            {
                ClientId = g.Key,
                OrderCount = g.Count()
            });

        return await cantidades
            .Join(
                _clients.Query(),
                g => g.ClientId,
                c => c.Clientid,
                (g, c) => new ClientOrderCountDto
                {
                    ClientId = c.Clientid,
                    ClientName = c.Name,
                    OrderCount = g.OrderCount
                })
            .OrderByDescending(c => c.OrderCount)
            .ThenBy(c => c.ClientId)
            .FirstOrDefaultAsync();
    }

    public async Task<List<Client>> ObtenerClientesPorProductoAsync(
        int productId)
    {
        var clientIds = _details.Query()
            .Where(d => d.Productid == productId)
            .Join(
                _orders.Query(),
                d => d.Orderid,
                o => o.Orderid,
                (d, o) => o.Clientid)
            .Distinct();

        return await _clients.Query()
            .AsNoTracking()
            .Where(c => clientIds.Contains(c.Clientid))
            .ToListAsync();
    }
}