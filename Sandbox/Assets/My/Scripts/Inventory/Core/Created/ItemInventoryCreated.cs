using N19;
using System.Collections.Generic;
using UnityEngine;

namespace Project
{
    public abstract class ItemInventoryCreated : MonoBehaviour
    {
        [SerializeField] private int _index;

        [SerializeField] private InventoryItemType _type;

        [SerializeField] protected Transform Parent;

        protected InventoryConfig Config;
        public GameObjectPool ObjectPool { get; private set; }

        private void Reset() => Parent = gameObject.transform;

        public virtual void Init()
        {
            Config = LoaderConfig.InventoryConfig;
            ObjectPool = new(Type()[_index].Item, Type()[_index].Count);
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