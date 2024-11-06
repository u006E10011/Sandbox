using N19;
using UnityEngine;

namespace Project
{
    public class ItemInventoryActivated : MonoBehaviour, IItemInventoryActivated
    {
        public IItemInventory Get()
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