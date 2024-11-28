using u20201b510_tallercito.SCM.Domain.Model.Aggregate;
using u20201b510_tallercito.SCM.Interfaces.REST.Resources;

namespace u20201b510_tallercito.SCM.Interfaces.REST.Transform;

public static class InventoryItemResourceFromEntityAssembler
{

    public static InventoryItemResource ToResourceFromEntity(InventoryItem Entity)
    {
        return new InventoryItemResource(
            Entity.ProductSku, 
            Entity.Status.ToString(), 
            Entity.MinimumQuantity, 
            Entity.AvailableQuantity, 
            Entity.ReservedQuantity, 
            Entity.PendingSupplyQuantity);
    }
    
}