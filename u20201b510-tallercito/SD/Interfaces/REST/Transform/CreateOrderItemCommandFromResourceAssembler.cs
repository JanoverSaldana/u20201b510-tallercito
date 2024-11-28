using u20201b510_tallercito.SD.Domain.Model.Commands;
using u20201b510_tallercito.SD.Interfaces.REST.Resources;

namespace u20201b510_tallercito.SD.Interfaces.REST.Transform;

public static class CreateOrderItemCommandFromResourceAssembler
{
    public static CreateOrderItemCommand ToCommandFromResource(CreateOrderItemResource resource)
    {
        return new CreateOrderItemCommand(
            resource.ProductSku,
            resource.RequestedQuantity, 
            resource.OrderedAt);
    }
}

