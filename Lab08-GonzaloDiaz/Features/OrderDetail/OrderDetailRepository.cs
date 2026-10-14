using Lab08_GonzaloDiaz.Models;

namespace Lab08_GonzaloDiaz.Repository;

public class OrderDetailRepository
    : GenericRepository<Orderdetail>, IOrderDetailRepository
{
    public OrderDetailRepository(ApplicationDbContext context)
        : base(context)
    {
    }
}