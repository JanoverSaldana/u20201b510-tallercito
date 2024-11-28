using u20201b510_tallercito.SCM.Domain.Model.Commands;
using u20201b510_tallercito.SCM.Interfaces.REST.Resources;

namespace u20201b510_tallercito.SCM.Interfaces.REST.Transform;

public static class CreateInventoryItemCommandFromResourceAssembler
{

    public static CreateInventoryItemCommand ToCommandFromResource( CreateInventoryItemResource resource)
    {
        return new CreateInventoryItemCommand(
            resource.ProductSku,
            resource.MinimumQuantity,
            resource.AvailableQuantity
        );
    }
}


