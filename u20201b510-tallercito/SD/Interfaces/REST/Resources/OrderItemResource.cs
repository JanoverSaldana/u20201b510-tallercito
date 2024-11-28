namespace u20201b510_tallercito.SD.Interfaces.REST.Resources;


public record OrderItemResource(
    int? OrderId, 
    Guid ProductSku, 
    double RequestedQuantity, 
    string Status, 
    DateTime OrderedAt);