using Microsoft.EntityFrameworkCore;
using u20201b510_tallercito.SD.Domain.Model.Aggregate;
using u20201b510_tallercito.SD.Domain.Repositories;
using u20201b510_tallercito.Shared.Infrastructure.Persistence.EFC.Configuration;
using u20201b510_tallercito.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace u20201b510_tallercito.SD.Infrastructure.Persistence.EFC.Repositories;

public class OrderItemRepository(AppDbContext context) : BaseRepository<OrderItem>(context), IOrderItemRepository
{
    public async Task<bool> ExistsByProductSkuAndOrderIdAsync(Guid productSku, int orderId)
    {
        return await Context.Set<OrderItem>()
            .AnyAsync(orderItem => orderItem.ProductSku == productSku && orderItem.OrderId == orderId);
    }
}