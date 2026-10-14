using Microsoft.AspNetCore.Mvc;

namespace Lab08_GonzaloDiaz.Features.Clientes;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductServices _service;

    public ProductController(IProductServices service)
    {
        _service = service;
    }

    [HttpGet("precio-mayor")]
    public IActionResult ObtenerPorPrecioMayor(
        [FromQuery] decimal precio)
    {
        return Ok(_service.ObtenerPorPrecioMayor(precio));
    }

    [HttpGet("mas-caro")]
    public IActionResult ObtenerMasCaro()
    {
        var resultado = _service.ObtenerMasCaro();

        if (resultado == null)
            return NotFound();

        return Ok(resultado);
    }

    [HttpGet("precio-promedio")]
    public IActionResult ObtenerPrecioPromedio()
    {
        return Ok(new
        {
            PrecioPromedio = _service.ObtenerPrecioPromedio()
        });
    }

    [HttpGet("sin-descripcion")]
    public IActionResult ObtenerSinDescripcion()
    {
        return Ok(_service.ObtenerSinDescripcion());
    }
}