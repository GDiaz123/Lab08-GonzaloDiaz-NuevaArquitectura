using System.Collections.Generic;
using System.Linq;
using Lab08_GonzaloDiaz.Models;
using Lab08_GonzaloDiaz.Repository;
namespace Lab08_GonzaloDiaz.Features.Clientes;

public class ProductService : IProductServices
{
    private readonly IProductRepository _products;

    public ProductService(IProductRepository products)
    {
        _products = products;
    }

    public List<Product> ObtenerPorPrecioMayor(decimal precio)
    {
        return _products.Query()
            .Where(p => p.Price > precio)
            .ToList();
    }

    public Product? ObtenerMasCaro()
    {
        return _products.Query()
            .OrderByDescending(p => p.Price)
            .ThenBy(p => p.Productid)
            .FirstOrDefault();
    }

    public decimal? ObtenerPrecioPromedio()
    {
        return _products.Query()
            .Select(p => (decimal?)p.Price)
            .Average();
    }

    public List<Product> ObtenerSinDescripcion()
    {
        return _products.Query()
            .Where(p =>
                p.Description == null ||
                p.Description == "")
            .ToList();
    }
}