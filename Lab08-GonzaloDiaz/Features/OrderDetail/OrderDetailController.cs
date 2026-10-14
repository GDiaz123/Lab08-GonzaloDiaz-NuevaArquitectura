using Microsoft.AspNetCore.Mvc;

namespace Lab08_GonzaloDiaz.Features.OrderDetail;

[Route("api/[controller]")]
[ApiController]
public class OrderDetailController : ControllerBase
{
    private readonly IOrderDetailServices _service;

    public OrderDetailController(IOrderDetailServices service)
    {
        _service = service;
    }

    [HttpGet("por-orden/{orderId:int}")]
    public IActionResult ObtenerProductosDeOrden(int orderId)
    {
        return Ok(_service.ObtenerProductosDeOrden(orderId));
    }

    [HttpGet("cantidad-total/{orderId:int}")]
    public IActionResult ObtenerCantidadTotal(int orderId)
    {
        return Ok(new
        {
            OrderId = orderId,
            CantidadTotal = _service.ObtenerCantidadTotal(orderId)
        });
    }

    [HttpGet("por-cliente/{clientId:int}")]
    public IActionResult ObtenerProductosPorCliente(int clientId)
    {
        return Ok(_service.ObtenerProductosPorCliente(clientId));
    }
}