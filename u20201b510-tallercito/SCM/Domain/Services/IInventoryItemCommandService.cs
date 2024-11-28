using u20201b510_tallercito.SCM.Domain.Model.Aggregate;
using u20201b510_tallercito.SCM.Domain.Model.Commands;

namespace u20201b510_tallercito.SCM.Domain.Services;

public interface IInventoryItemCommandService
{
    
    public Task<InventoryItem> Handle(CreateInventoryItemCommand command);
    
}