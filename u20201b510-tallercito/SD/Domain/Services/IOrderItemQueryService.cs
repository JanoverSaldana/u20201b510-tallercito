using u20201b510_tallercito.SD.Domain.Model.Aggregate;
using u20201b510_tallercito.SD.Domain.Model.Queries;

namespace u20201b510_tallercito.SD.Domain.Repositories;

public interface IOrderItemQueryService
{
    public Task<OrderItem> Handle(GetOrderItemByIdQuery query);
}