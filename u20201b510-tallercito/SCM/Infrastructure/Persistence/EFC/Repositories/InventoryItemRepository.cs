using Microsoft.EntityFrameworkCore;
using u20201b510_tallercito.SCM.Domain.Model.Aggregate;
using u20201b510_tallercito.SCM.Domain.Repositories;
using u20201b510_tallercito.Shared.Infrastructure.Persistence.EFC.Configuration;
using u20201b510_tallercito.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace u20201b510_tallercito.SCM.Infrastructure.Persistence.EFC.Repositories;

public class InventoryItemRepository(AppDbContext context): BaseRepository<InventoryItem>(context), IInventoryItemRepository
{
    public async Task<bool> ExistsByGuid(Guid guid)
    {
        return await Context.Set<InventoryItem>().AnyAsync(x => x.ProductSku == guid);
    }

    public async Task<InventoryItem> FindByProductSkuAsync(Guid productSku)
    {
        return await Context.Set<InventoryItem>().FirstOrDefaultAsync(x => x.ProductSku == productSku);
    }
}