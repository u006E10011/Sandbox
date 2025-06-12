using UnityEngine;

namespace Project.Inventory
{
    public interface IInventoryItemActivatedAndCreated : IInventoryItem
    {
        GameObject Get(Vector3 position);
    }
}