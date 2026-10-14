using System.Collections.Generic;
using Lab08_GonzaloDiaz.Models;

namespace Lab08_GonzaloDiaz.Features.Clientes;

public interface IProductServices
{
    List<Product> ObtenerPorPrecioMayor(decimal precio);

    Product? ObtenerMasCaro();

    decimal? ObtenerPrecioPromedio();

    List<Product> ObtenerSinDescripcion();
}