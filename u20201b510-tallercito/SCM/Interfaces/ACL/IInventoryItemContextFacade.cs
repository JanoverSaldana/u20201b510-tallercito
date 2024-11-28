namespace u20201b510_tallercito.SCM.Interfaces.ACL;

public interface IInventoryItemContextFacade
{
    Task<bool> existsInventoryItemByProductSku(Guid ProductSku);
}