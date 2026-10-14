using System.Collections.Generic;
using System.Threading.Tasks;
using Lab08_GonzaloDiaz.DTOs;
using Lab08_GonzaloDiaz.Models;

namespace Lab08_GonzaloDiaz.Features.Clientes;

public interface IClienteServices
{
    Task<List<Client>> BuscarPorNombreAsync(
        string nombre,
        bool comienzaCon = false);

    Task<ClientOrderCountDto?> ObtenerClienteConMasPedidosAsync();

    Task<List<Client>> ObtenerClientesPorProductoAsync(
        int productId);
}