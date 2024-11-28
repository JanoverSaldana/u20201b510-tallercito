using u20201b510_tallercito.SCM.Domain.Model.Commands;
using u20201b510_tallercito.SCM.Domain.Model.ValueObjects;

namespace u20201b510_tallercito.SCM.Domain.Model.Aggregate;

public partial class InventoryItem
{
    public int Id { get; set; }
    
    public Guid ProductSku { get; set; }
    public EStatusInventoryItem Status { get; set; }
    public double MinimumQuantity { get; set; }
    public double AvailableQuantity { get; set; }
    public double ReservedQuantity { get; set; }
    public double PendingSupplyQuantity { get; set; }
    


    public InventoryItem()
    {
        Status = EStatusInventoryItem.WITH_STOCK;
        MinimumQuantity = 0;
        AvailableQuantity = 0;
        ReservedQuantity = 0;
        PendingSupplyQuantity = 0;
    }
    
    
    public InventoryItem(CreateInventoryItemCommand command) : this()
    {
        ProductSku = command.ProductSku;
        MinimumQuantity = command.MinimumQuantity;
        AvailableQuantity = command.AvailableQuantity;
    }
    
    
}