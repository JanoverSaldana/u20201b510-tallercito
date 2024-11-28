namespace u20201b510_tallercito.SCM.Interfaces.REST.Resources;

public record InventoryItemResource(
    Guid ProductSku, 
    string Status, 
    double MinimumQuantity, 
    double AvailableQuantity, 
    double ReservedQuantity, 
    double PendingSupplyQuantity);
