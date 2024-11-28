using u20201b510_tallercito.SCM.Domain.Model.Aggregate;
using u20201b510_tallercito.SCM.Domain.Model.Queries;

namespace u20201b510_tallercito.SCM.Domain.Services;

public interface IInventoryItemQueryService
{
    Task<InventoryItem> Handle(GetInventoryItemByIdQuery query);
    
    Task<InventoryItem> Handle(GetInventoryItemByProductSkuQuery query);
    
}