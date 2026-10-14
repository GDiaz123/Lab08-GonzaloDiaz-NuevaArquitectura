using System.Collections.Generic;
using System.Linq;
using Lab08_GonzaloDiaz.DTOs;
using Lab08_GonzaloDiaz.Repository;

namespace Lab08_GonzaloDiaz.Features.OrderDetail;

public class OrderDetailService : IOrderDetailServices
{
    private readonly IOrderDetailRepository _details;
    private readonly IProductRepository _products;
    private readonly IOrderRepository _orders;

    public OrderDetailService(
        IOrderDetailRepository details,
        IProductRepository products,
        IOrderRepository orders)
    {
        _details = details;
        _products = products;
        _orders = orders;
    }

    public List<ProductOrderDto> ObtenerProductosDeOrden(int orderId)
    {
        return _details.Query()
            .Where(d => d.Orderid == orderId)
            .Join(
                _products.Query(),
                d => d.Productid,
                p => p.Productid,
                (d, p) => new ProductOrderDto
                {
                    OrderId = d.Orderid,
                    ProductId = p.Productid,
                    ProductName = p.Name,
                    Quantity = d.Quantity
                })
            .ToList();
    }

    public int ObtenerCantidadTotal(int orderId)
    {
        return _details.Query()
            .Where(d => d.Orderid == orderId)
            .Select(d => (int?)d.Quantity)
            .Sum() ?? 0;
    }

    public List<SoldProductDto> ObtenerProductosPorCliente(int clientId)
    {
        var productIds = _orders.Query()
            .Where(o => o.Clientid == clientId)
            .Join(
                _details.Query(),
                o => o.Orderid,
                d => d.Orderid,
                (o, d) => d.Productid)
            .Distinct();

        return _products.Query()
            .Where(p => productIds.Contains(p.Productid))
            .Select(p => new SoldProductDto
            {
                ProductId = p.Productid,
                ProductName = p.Name
            })
            .ToList();
    }
}