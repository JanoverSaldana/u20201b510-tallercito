using u20201b510_tallercito.SCM.Domain.Model.Aggregate;
using u20201b510_tallercito.Shared.Domain.Repositories;

namespace u20201b510_tallercito.SCM.Domain.Repositories;

public interface IInventoryItemRepository: IBaseRepository<InventoryItem>
{
    Task<bool> ExistsByGuid (Guid guid);
    
    Task<InventoryItem> FindByProductSkuAsync(Guid productSku);
}