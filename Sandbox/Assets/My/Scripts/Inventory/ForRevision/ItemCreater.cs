using N19;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Revision
{
    public class ItemCreater
    {
        private InventoryConfig _config;
        private GameObjectPool _pool;

        public ItemCreater(InventoryConfig config)
        {
            _config = config;
        }

        public void Create(InventoryItemType type)
        {
            switch (type)
            {
                case InventoryItemType.Weapon:
                    break;
                case InventoryItemType.NPS:
                    //Transform parent = new GameObject()
                    break;
                case InventoryItemType.Necbox:
                    break;
            }
        }

        private void CreateType(List<InventoryItem> type, Transform parent, int index)
        {
            for (int i = 0; i < type.Count; i++)
                CreateConcreate(type[i], parent);
        }

        private void CreateConcreate(InventoryItem item, Transform parent)
        {
            /*            for (int i = 0; i < length; i++)
                        {

                        }*/
        }
    }
}