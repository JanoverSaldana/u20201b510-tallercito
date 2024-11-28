using u20201b510_tallercito.SCM.Domain.Model.Aggregate;
using u20201b510_tallercito.SCM.Domain.Model.Commands;
using u20201b510_tallercito.SCM.Domain.Repositories;
using u20201b510_tallercito.SCM.Domain.Services;
using u20201b510_tallercito.Shared.Domain.Repositories;

namespace u20201b510_tallercito.SCM.Application.Internal.CommandServices;

public class InventoryItemCommandService(IInventoryItemRepository inventoryItemRepository, IUnitOfWOrk unitOfWork): IInventoryItemCommandService
{
    public async Task<InventoryItem> Handle(CreateInventoryItemCommand command)
    {
        
        if (command.ProductSku == null ||command.ProductSku == Guid.Empty) throw new Exception("El valor de ProductSku no puede ser nulo o vacío");
        
        if (command.AvailableQuantity == null || command.AvailableQuantity < 0 || command.AvailableQuantity == 0) throw new Exception("El valor de AvailableQuantity no puede ser nulo o negativo");
        
        var exists = await inventoryItemRepository.ExistsByGuid(command.ProductSku);
        if(exists) throw new Exception("Ya existe un InventoryItem con el mismo valor de ProductSku");
        
        if(command.AvailableQuantity < command.MinimumQuantity * 2) throw new Exception("El valor de AvailableQuantity debe ser por lo menos el doble del valor de MinimumQuantity");
        
        var inventoryItem = new InventoryItem(command);
        
        await inventoryItemRepository.AddAsync(inventoryItem);
        await unitOfWork.CompleteAsync();

        return inventoryItem;
    }
}