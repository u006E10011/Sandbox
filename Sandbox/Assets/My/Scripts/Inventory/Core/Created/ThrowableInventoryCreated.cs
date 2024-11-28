using N19;
using UnityEngine;

namespace Project
{
    public class ThrowableInventoryCreated : ItemInventoryCreated, IItemInventoryCreatedThrowable
    {
        private GameObject _item;

        public override void Init()
        {
            base.Init();

            foreach (var item in ObjectPool.Pool)
                item.transform.parent = Parent;
        }

        public GameObject Get(Vector3 position)
        {
            _item = ObjectPool.Get();
            _item.transform.parent = Parent;
            _item.transform.position = position;
            _item.transform.localRotation = Quaternion.Euler(Vector3.zero);

            return _item;
        }

        public override void Return()
        {
            ObjectPool.Return(_item);
            gameObject.Deactivate();
        }
    }
}