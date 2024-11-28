using u20201b510_tallercito.SCM.Domain.Model.Queries;
using u20201b510_tallercito.SD.Domain.Model.Aggregate;
using u20201b510_tallercito.SD.Domain.Model.Queries;
using u20201b510_tallercito.SD.Domain.Repositories;

namespace u20201b510_tallercito.SD.Application.Internal.QueryServices;

public class OrderItemQueryService(IOrderItemRepository orderItemRepository): IOrderItemQueryService
{
    public async Task<OrderItem> Handle(GetOrderItemByIdQuery query)
    {
        return await orderItemRepository.FindByIdAsync(query.Id);
    }
}