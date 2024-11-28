namespace u20201b510_tallercito.SCM.Domain.Model.Commands;


public record CreateInventoryItemCommand(
    Guid ProductSku, 
    double MinimumQuantity, 
    double AvailableQuantity);