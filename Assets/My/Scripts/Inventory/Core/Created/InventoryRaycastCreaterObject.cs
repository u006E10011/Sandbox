using N19;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Inventory
{
    public class InventoryRaycastCreaterObject : MonoBehaviour, IInventoryItemCreated
    {
        [SerializeField] private InventoryRaycastCreateConfig _config;

        [SerializeField, Space(10)] private RaycastCreateType _type;
        [SerializeField] private int _index;

        [SerializeField, Space(5)] private Transform _parent;

        private GameObjectPool _pool;
        private Transform _rotationItem;

        public void Init(Transform player)
        {
            _rotationItem = player;
            _pool = new(Item()[_index].Prefab, Item()[_index].Count);

            foreach (var item in _pool.Pool)
                item.transform.parent = _parent;
        }

        public IInventoryItem Get(Vector3 position)
        {
            var item = _pool.Get();
            item.transform.position = position;
            item.transform.LookAt(_rotationItem);
            item.transform.rotation = Quaternion.Euler(0, item.transform.eulerAngles.y, 0);

            return this;
        }

        public void Return()
        {
            _pool.Return(_pool.Pool.Peek());
        }

        private List<InventoryItem> Item() => _type switch
        {
            RaycastCreateType.NPC => _config.NPC,
            RaycastCreateType.Nextbot => _config.Nexbot,
            _ => null
        };
    }
}