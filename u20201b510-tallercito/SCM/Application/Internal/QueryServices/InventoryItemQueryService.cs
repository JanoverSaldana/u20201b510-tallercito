using u20201b510_tallercito.SCM.Domain.Model.Aggregate;
using u20201b510_tallercito.SCM.Domain.Model.Queries;
using u20201b510_tallercito.SCM.Domain.Repositories;
using u20201b510_tallercito.SCM.Domain.Services;

namespace u20201b510_tallercito.SCM.Application.Internal.QueryServices;

public class InventoryItemQueryService(IInventoryItemRepository inventoryItemRepository): IInventoryItemQueryService
{
    public async Task<InventoryItem> Handle(GetInventoryItemByIdQuery query)
    {
        return await inventoryItemRepository.FindByIdAsync(query.Id);
    }

    public async Task<InventoryItem> Handle(GetInventoryItemByProductSkuQuery query)
    {
        return await inventoryItemRepository.FindByProductSkuAsync(query.ProductSku);
    }
    
}