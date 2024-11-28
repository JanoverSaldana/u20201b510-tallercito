using u20201b510_tallercito.SD.Domain.Model.Aggregate;
using u20201b510_tallercito.SD.Interfaces.REST.Resources;

namespace u20201b510_tallercito.SD.Interfaces.REST.Transform;

public static class OrderItemResourceFromEntityAssembler
{
    public static OrderItemResource ToResourceFromEntity(OrderItem entity)
    {
        return new OrderItemResource(
            entity.OrderId, 
            entity.ProductSku, 
            entity.RequestedQuantity, 
            entity.Status.ToString(), 
            entity.OrderedAt
            );
        
    }
}

