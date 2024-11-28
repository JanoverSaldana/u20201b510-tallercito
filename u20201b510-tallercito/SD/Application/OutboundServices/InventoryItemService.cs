using u20201b510_tallercito.SCM.Interfaces.ACL;

namespace u20201b510_tallercito.SD.Application.OutboundServices;

public class ExternalIInventoryItemService(IInventoryItemContextFacade inventoryItemContextFacade)
{

    public async Task<bool> existsInventoryItemByProductSku(Guid ProductSku)
    {
        bool exist = await inventoryItemContextFacade.existsInventoryItemByProductSku(ProductSku);
        return exist;
    }
    
}