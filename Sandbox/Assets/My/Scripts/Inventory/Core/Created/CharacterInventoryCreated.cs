using UnityEngine;

namespace Project
{
    public class CharacterInventoryCreated : ItemInventoryCreated, IItemInventoryCreated
    {
        public IItemInventory Get (Vector3 position)
        {
            var item = ObjectPool.Get();
            item.transform.position = position;
            item.transform.LookAt(InstantiateitemPoint);
            item.transform.rotation = Quaternion.Euler(0, item.transform.eulerAngles.y, 0);

            return this;
        }

        public override void Return()
        {
            ObjectPool.Return(ObjectPool.Pool.Peek());
        }
    }
}