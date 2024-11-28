using u20201b510_tallercito.SD.Domain.Model.Aggregate;
using u20201b510_tallercito.SD.Domain.Model.Commands;

namespace u20201b510_tallercito.SD.Domain.Services;

public interface IOrderItemCommandService
{
    public Task<OrderItem> Handle(CreateOrderItemCommand command, int OrderId);
}