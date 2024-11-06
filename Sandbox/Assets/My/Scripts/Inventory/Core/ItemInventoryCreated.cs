using N19;
using System.Collections.Generic;
using UnityEngine;

namespace Project
{
    public class ItemInventoryCreated : MonoBehaviour, IItemInventoryCreated
    {
        [SerializeField] private int _index;

        [SerializeField] private InventoryItemType _type;
        [SerializeField] private Transform _parent;

        private Transform _instantiateitemPoint;
        private InventoryConfig _config;
        private GameObjectPool _objectPool;

        public void Init(Transform instantiateitemPoint)
        {
            _parent ??= gameObject.transform;
            _config = LoaderConfig.InventoryConfig;
            _instantiateitemPoint = instantiateitemPoint;

            _objectPool = new(Type()[_index].Item, Type()[_index].Count);

            foreach (var item in _objectPool.Pool)
                item.transform.parent = _parent;
        }


        public IItemInventory Get(Vector3 position)
        {
            var item = _objectPool.Get();
            item.transform.position = position;
            item.transform.LookAt(_instantiateitemPoint);
            item.transform.rotation = Quaternion.Euler(0, item.transform.eulerAngles.y, 0);

            return this;
        }

        public void Return()
        {
            _objectPool.Return(_objectPool.Pool.Peek());
        }

        private List<InventoryItem> Type()
        {
            switch (_type)
            {
                case InventoryItemType.Weapon:
                    break;
                case InventoryItemType.NPS:
                    return _config.NPS;
                case InventoryItemType.Necbox:
                    return _config.Nexbot;
                default:
                    return null;
            }

            return null;
        }

    }
}