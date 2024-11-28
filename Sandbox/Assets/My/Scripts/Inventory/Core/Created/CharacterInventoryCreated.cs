using UnityEngine;

namespace Project
{
    public class CharacterInventoryCreated : ItemInventoryCreated, IItemInventoryCreatedRaycast
    {
        [SerializeField] private Transform _rotateDirection;

        public override void Init()
        {
            base.Init();

            foreach (var item in ObjectPool.Pool)
                item.transform.parent = Parent;
        }

        public IItemInventory Get(Vector3 position)
        {
            var item = ObjectPool.Get();
            item.transform.position = position;
            item.transform.parent = Parent;
            item.transform.LookAt(_rotateDirection);
            item.transform.rotation = Quaternion.Euler(0, item.transform.eulerAngles.y, 0);

            return this;
        }

        public override void Return()
        {
            ObjectPool.Return(ObjectPool.Pool.Peek());
        }
    }
}