using N19;
using UnityEngine;

namespace Project.Inventory
{
    public class InventoryItemCreater : MonoBehaviour, IInventoryItemActivatedAndCreated
    {
        [SerializeField] private InventoryItem _config;
        [SerializeField] private Transform _parent;

        public GameObjectPool Pool { get; private set; }

        public void Init()
        {
            Pool = new(_config.Prefab, _config.Count);

            foreach (var item in Pool.Pool)
                 item.transform.parent = _parent;
        }

        public GameObject Get(Vector3 position)
        {
            var item = Pool.Get();
            item.transform.SetPositionAndRotation(position, Quaternion.identity);
            return item;
        }

        public void Return()
        {
            Pool.Return(Pool.Pool.Peek());
        }
    }
}