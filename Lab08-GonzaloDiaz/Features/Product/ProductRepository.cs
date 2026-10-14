using Lab08_GonzaloDiaz.Models;
using Lab08_GonzaloDiaz.Repository;
using Microsoft.EntityFrameworkCore;

namespace  Lab08_GonzaloDiaz.Repositories;

public class ProductRepository : GenericRepository<Product>, IProductRepository
{
    private readonly ApplicationDbContext _context;

    public ProductRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
}