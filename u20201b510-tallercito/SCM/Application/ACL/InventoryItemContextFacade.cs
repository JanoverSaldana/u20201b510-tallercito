using u20201b510_tallercito.SCM.Domain.Model.Queries;
using u20201b510_tallercito.SCM.Domain.Services;
using u20201b510_tallercito.SCM.Interfaces.ACL;

namespace u20201b510_tallercito.SCM.Application.ACL;

public class InventoryItemContextFacade(IInventoryItemQueryService inventoryItemQueryService, IInventoryItemCommandService inventoryItemCommandService): IInventoryItemContextFacade
{
    public async Task<bool> existsInventoryItemByProductSku(Guid productSku)
    {
        var exists = false;
        
        var getInventoryItemByProductSkuQuery = new GetInventoryItemByProductSkuQuery(productSku);

        var inventoryItem = await inventoryItemQueryService.Handle(getInventoryItemByProductSkuQuery);
        
        if (inventoryItem != null)
        {
            exists = true;
        }
        
        return exists;
    }

    public async Task<bool> updateStatusInventoryItem(Guid ProductSku)
    {
        throw new NotImplementedException();
    }
}