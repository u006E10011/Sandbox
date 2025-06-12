using UnityEngine;

namespace Project.Inventory
{
    public interface IInventoryItemCreated : IInventoryItem
    {
        IInventoryItem Get(Vector3 position);
    }
}