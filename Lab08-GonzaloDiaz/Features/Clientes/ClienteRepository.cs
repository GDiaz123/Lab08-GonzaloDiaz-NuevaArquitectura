using Lab08_GonzaloDiaz.Models;

namespace Lab08_GonzaloDiaz.Repository;

public class ClienteRepository
    : GenericRepository<Client>, IClienteRepository
{
    public ClienteRepository(ApplicationDbContext context)
        : base(context)
    {
    }
}