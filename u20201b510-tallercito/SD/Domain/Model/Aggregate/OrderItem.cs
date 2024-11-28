using u20201b510_tallercito.SCM.Domain.Model.Commands;
using u20201b510_tallercito.SD.Domain.Model.Commands;
using u20201b510_tallercito.SD.Domain.Model.ValueObjects;

namespace u20201b510_tallercito.SD.Domain.Model.Aggregate;

public partial class OrderItem
{
        
    public int Id { get; set; }
    public int? OrderId { get; set; }
    public Guid ProductSku { get; set; }
    public double RequestedQuantity { get; set; }
    public EOrderItemStatus Status { get; set; }
    public DateTime OrderedAt { get; set; }
    
    public OrderItem()
    {
        OrderId = null;
        ProductSku = Guid.Empty;
        RequestedQuantity = 0;
        Status = EOrderItemStatus.WAITING_FOR_INVENTORY;
    }

    public OrderItem(CreateOrderItemCommand command, int orderId)
    {
        OrderId = orderId;
        ProductSku = command.ProductSku;
        RequestedQuantity = command.RequestedQuantity;
        Status = EOrderItemStatus.WAITING_FOR_INVENTORY;
        OrderedAt = command.OrderedAt;
    }
    
}