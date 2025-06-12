using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Inventory
{
    [CreateAssetMenu(fileName = nameof(InventoryButtonConfig), menuName = "Config/Inventory/" + nameof(InventoryButtonConfig))]
    public class InventoryButtonConfig : ScriptableObject
    {
        public Button PrefabButton;
        public List<Sprite> IconWeapon;
        public List<Sprite> IconNPC;
        public List<Sprite> IconNextbot;
    }
}