using u20201b510_tallercito.SD.Domain.Model.Aggregate;
using u20201b510_tallercito.SD.Domain.Model.Commands;
using u20201b510_tallercito.SD.Domain.Repositories;
using u20201b510_tallercito.SD.Domain.Services;
using u20201b510_tallercito.Shared.Domain.Repositories;

namespace u20201b510_tallercito.SD.Application.Internal.CommandServices;

public class OrderItemCommandService(IOrderItemRepository orderItemRepository, IUnitOfWOrk unitOfWork): IOrderItemCommandService
{
    public async Task<OrderItem> Handle(CreateOrderItemCommand command, int orderId)
    {
        
        var orderItem = new OrderItem(command, orderId);
        
        await orderItemRepository.AddAsync(orderItem);
        await unitOfWork.CompleteAsync();
        
        return orderItem;
    }
}