using Microsoft.AspNetCore.Mvc;

namespace Lab08_GonzaloDiaz.Features.Clientes;

[Route("api/[controller]")]
[ApiController]
public class ClienteController : ControllerBase
{
    private readonly IClienteServices _service;

    public ClienteController(IClienteServices service)
    {
        _service = service;
    }

    [HttpGet("buscar-por-nombre")]
    public async Task<IActionResult> BuscarPorNombre(
        [FromQuery] string nombre,
        [FromQuery] bool comienzaCon = false)
    {
        var resultado = await _service.BuscarPorNombreAsync(
            nombre, comienzaCon);

        return Ok(resultado);
    }

    [HttpGet("mas-pedidos")]
    public async Task<IActionResult> ObtenerClienteConMasPedidos()
    {
        var resultado = await _service.ObtenerClienteConMasPedidosAsync();

        if (resultado == null)
            return NotFound();

        return Ok(resultado);
    }

    [HttpGet("por-producto/{productId:int}")]
    public async Task<IActionResult> ObtenerClientesPorProducto(
        int productId)
    {
        var resultado = await _service.ObtenerClientesPorProductoAsync(
            productId);

        return Ok(resultado);
    }
}