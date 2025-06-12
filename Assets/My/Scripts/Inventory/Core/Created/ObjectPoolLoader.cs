using UnityEngine;
using System.Collections.Generic;

namespace Project.Inventory
{
    public class ObjectPoolLoader : MonoBehaviour
    {
        [SerializeField] private List<InventoryItemCreater> _itemCreater;
        [SerializeField] private List<InventoryRaycastCreaterObject> _itemRaycastCreater;

        public void Init(Transform player)
        {
            _itemCreater.ForEach(item => item.Init());
            _itemRaycastCreater.ForEach(_item => _item.Init(player));
        }
    }
}