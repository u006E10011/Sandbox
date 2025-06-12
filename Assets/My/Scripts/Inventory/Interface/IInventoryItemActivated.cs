namespace Project.Inventory
{
    public interface IInventoryItemActivated: IInventoryItem
    {
        IInventoryItem Get();
    }
}