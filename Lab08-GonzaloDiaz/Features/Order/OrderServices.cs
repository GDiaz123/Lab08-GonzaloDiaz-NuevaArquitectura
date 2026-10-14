using System;
using System.Collections.Generic;
using System.Linq;
using Lab08_GonzaloDiaz.DTOs;
using Lab08_GonzaloDiaz.Models;
using Lab08_GonzaloDiaz.Features.OrderDetail;
using Lab08_GonzaloDiaz.Repository;
using OrderEntity = Lab08_GonzaloDiaz.Models.Order;

namespace Lab08_GonzaloDiaz.Features.Order;
public class OrderService : IOrderServices
{
    private readonly IOrderRepository _orders;
    private readonly IOrderDetailRepository _details;
    private readonly IProductRepository _products;

    public OrderService(
        IOrderRepository orders,
        IOrderDetailRepository details,
        IProductRepository products)
    {
        _orders = orders;
        _details = details;
        _products = products;
    }

    public List<OrderEntity> ObtenerDespuesDeFecha(DateTime fecha)
    {
        return _orders.Query()
            .Where(o => o.Orderdate > fecha)
            .ToList();
    }

    public List<OrderWithDetailsDto> ObtenerPedidosConDetalles()
    {
        var detalles = _details.Query()
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

        var pedidos = _orders.Query()
            .OrderBy(o => o.Orderid)
            .Select(o => new
            {
                OrderId = o.Orderid,
                OrderDate = o.Orderdate
            })
            .ToList();

        return pedidos
            .Select(o => new OrderWithDetailsDto
            {
                OrderId = o.OrderId,
                OrderDate = o.OrderDate,
                Details = detalles
                    .Where(d => d.OrderId == o.OrderId)
                    .ToList()
            })
            .ToList();
    }
}