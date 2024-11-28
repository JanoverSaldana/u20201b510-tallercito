namespace u20201b510_tallercito.SCM.Interfaces.REST.Resources;

public record CreateInventoryItemResource(
    Guid ProductSku, 
    double MinimumQuantity, 
    double AvailableQuantity);
    
    
