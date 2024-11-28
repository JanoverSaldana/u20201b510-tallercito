namespace u20201b510_tallercito.SD.Domain.Model.Commands;


public record CreateOrderItemCommand(
    Guid ProductSku,
    double RequestedQuantity, 
    DateTime OrderedAt);