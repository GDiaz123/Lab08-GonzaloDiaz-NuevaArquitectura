using Microsoft.AspNetCore.Mvc;

namespace Lab08_GonzaloDiaz.Features.Order;

[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly IOrderServices _service;

    public OrderController(IOrderServices service)
    {
        _service = service;
    }

    [HttpGet("despues-de-fecha")]
    public IActionResult ObtenerDespuesDeFecha(
        [FromQuery] DateTime fecha)
    {
        return Ok(_service.ObtenerDespuesDeFecha(fecha));
    }

    [HttpGet("con-detalles")]
    public IActionResult ObtenerPedidosConDetalles()
    {
        return Ok(_service.ObtenerPedidosConDetalles());
    }
}