using u20201b510_tallercito.SD.Domain.Model.Aggregate;
using u20201b510_tallercito.Shared.Domain.Repositories;

namespace u20201b510_tallercito.SD.Domain.Repositories;

public interface IOrderItemRepository: IBaseRepository<OrderItem>
{
    Task<bool> ExistsByProductSkuAndOrderIdAsync(Guid productSku, int orderId);
}