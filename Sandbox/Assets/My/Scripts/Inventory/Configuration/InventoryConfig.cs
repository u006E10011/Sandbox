using N19;
using System.Collections.Generic;
using UnityEngine;

namespace Project
{
    [System.Serializable]
    public class InventoryItem
    {
        public int Count;
        /*[GameObjectOfType(typeof(IItemInventory))] */
        public GameObject Item;
    }

    [CreateAssetMenu(fileName = "InventoryConfig", menuName = "Config/Inventory/InventoryConfig")]
    public class InventoryConfig : ScriptableObject
    {
        /*[GameObjectOfType(typeof(IItemInventory))] */
        public List<InventoryItem> NPS;
        /*[GameObjectOfType(typeof(IItemInventory))] */
        public List<InventoryItem> Nexbot;
    }
}