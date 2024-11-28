using UnityEngine;

namespace Project
{
    public interface IItemInventoryCreatedRaycast : IItemInventory
    {
        IItemInventory Get(Vector3 position);
    }
}