using UnityEngine;

namespace Project
{
    public interface IItemInventoryCreated : IItemInventory
    {
        IItemInventory Get(Vector3 position);
    }
}