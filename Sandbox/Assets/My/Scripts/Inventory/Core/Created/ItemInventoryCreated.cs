using N19;
using System.Collections.Generic;
using UnityEngine;

namespace Project
{
    public abstract class ItemInventoryCreated : MonoBehaviour
    {
        [SerializeField] private int _index;

        [SerializeField] private InventoryItemType _type;
        [SerializeField] private Transform _parent;

        protected Transform InstantiateitemPoint;
        protected InventoryConfig Config;
        protected GameObjectPool ObjectPool;

        private void Reset() => _parent = gameObject.transform;

        public virtual void Init(Transform instantiateItemPoint)
        {
            Config = LoaderConfig.InventoryConfig;
            InstantiateitemPoint = instantiateItemPoint;

            ObjectPool = new(Type()[_index].Item, Type()[_index].Count);

            foreach (var item in ObjectPool.Pool)
                item.transform.parent = _parent;
        }

        public abstract void Return();

        public List<InventoryItem> Type()
        {
            switch (_type)
            {
                case InventoryItemType.Weapon:
                    break;
                case InventoryItemType.NPS:
                    return Config.NPS;
                case InventoryItemType.Necbox:
                    return Config.Nexbot;
                case InventoryItemType.Throwable:
                    return Config.Trowable;
                default:
                    return null;
            }

            return null;
        }

    }
}