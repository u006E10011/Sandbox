using UnityEngine;

namespace Project.Inventory
{
    [System.Serializable]
    [CreateAssetMenu(fileName = nameof(InventoryItem), menuName = "Config/Inventory/" + nameof(InventoryItem))]
    public class InventoryItem : ScriptableObject
    {
        public GameObject Prefab;
        public int Count;
    }
}