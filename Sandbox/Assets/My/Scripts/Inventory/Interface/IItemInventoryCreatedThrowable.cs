using UnityEngine;

namespace Project
{
    public interface IItemInventoryCreatedThrowable : IItemInventory
    {
        GameObject Get(Vector3 position);
    }
}