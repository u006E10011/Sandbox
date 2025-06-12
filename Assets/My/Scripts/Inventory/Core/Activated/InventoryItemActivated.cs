using N19;
using UnityEngine;

namespace Project.Inventory
{
    public class InventoryItemActivated : MonoBehaviour, IInventoryItemActivated
    {
        public IInventoryItem Get()
        {
            gameObject.Activate();

            return this;
        }

        public void Return()
        {
            gameObject.Deactivate();
        }
    }
}