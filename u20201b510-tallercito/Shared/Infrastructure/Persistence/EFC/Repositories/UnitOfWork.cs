using u20201b510_tallercito.Shared.Domain.Repositories;
using u20201b510_tallercito.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace u20201b510_tallercito.Shared.Infrastructure.Persistence.EFC.Repositories;

public class UnitOfWork : IUnitOfWOrk
{
    private readonly AppDbContext _context;
    
    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task CompleteAsync()
    {
        await _context.SaveChangesAsync();
    }
}