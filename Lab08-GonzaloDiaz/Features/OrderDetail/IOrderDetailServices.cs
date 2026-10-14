using System.Collections.Generic;
using Lab08_GonzaloDiaz.DTOs;

namespace Lab08_GonzaloDiaz.Features.OrderDetail;

public interface IOrderDetailServices
{
    List<ProductOrderDto> ObtenerProductosDeOrden(int orderId);

    int ObtenerCantidadTotal(int orderId);

    List<SoldProductDto> ObtenerProductosPorCliente(int clientId);
}