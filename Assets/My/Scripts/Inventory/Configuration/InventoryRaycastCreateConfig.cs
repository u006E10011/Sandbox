using System.Collections.Generic;
using UnityEngine;

namespace Project.Inventory
{
    [CreateAssetMenu(fileName = nameof(InventoryRaycastCreateConfig), menuName = "Config/Inventory/" + nameof(InventoryRaycastCreateConfig))]
    public class InventoryRaycastCreateConfig : ScriptableObject
    {
        public int IndexRaycastItemCreatePistol = 2;

        public List<InventoryItem> NPC;
        public List<InventoryItem> Nexbot;

    }
}