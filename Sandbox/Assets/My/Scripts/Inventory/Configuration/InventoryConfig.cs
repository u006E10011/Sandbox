using System.Collections.Generic;
using UnityEngine;

namespace Project
{
    [System.Serializable]
    public class InventoryItem
    {
        public int Count;
        public GameObject Item;
    }

    [CreateAssetMenu(fileName = "InventoryConfig", menuName = "Config/Inventory/InventoryConfig")]
    public class InventoryConfig : ScriptableObject
    {
        public List<InventoryItem> NPS;
        public List<InventoryItem> Nexbot;
        public List<InventoryItem> Trowable;

    }
}