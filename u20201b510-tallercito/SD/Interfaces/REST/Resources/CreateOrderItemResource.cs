namespace u20201b510_tallercito.SD.Interfaces.REST.Resources;

public record CreateOrderItemResource(    
    Guid ProductSku,
    double RequestedQuantity, 
    DateTime OrderedAt);