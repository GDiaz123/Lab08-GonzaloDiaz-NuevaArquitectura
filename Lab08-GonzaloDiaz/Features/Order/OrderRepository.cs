using Lab08_GonzaloDiaz.Models;
using Lab08_GonzaloDiaz.Repository;
using Microsoft.EntityFrameworkCore;

namespace  Lab08_GonzaloDiaz.Repository;

public class OrderRepository : GenericRepository<Order>, IOrderRepository
{
    private readonly ApplicationDbContext _context;

    public OrderRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
}