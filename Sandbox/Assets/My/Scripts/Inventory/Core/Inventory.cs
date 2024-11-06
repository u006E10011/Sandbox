using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Project
{
    public class Inventory : MonoBehaviour, ISwitchItemInventory
    {
        public List<IItemInventoryActivated> Weapon { get; private set; } = new();
        public List<IItemInventoryCreated> NPS { get; private set; } = new();
        public List<IItemInventoryCreated> Nexbot { get; private set; } = new();

        private IItemInventoryActivated _weapon;
        private IItemInventoryCreated _character;

        public void Init(Transform containerItemInventoryWeapon, Transform containerItemInventoryNPS, Transform containerItemInventoryNexbot)
        {
            Weapon = new(containerItemInventoryWeapon.GetComponentsInChildren<IItemInventoryActivated>(true));
            NPS = new(containerItemInventoryNPS.GetComponentsInChildren<IItemInventoryCreated>(true));
            Nexbot = new(containerItemInventoryNexbot.GetComponentsInChildren<IItemInventoryCreated>(true));

            _weapon = Weapon?[0];
            _character = NPS?[0];
        }


        public void Switch(InventoryItemType type, int index)
        {
            switch (type)
            {
                case InventoryItemType.Weapon:
                    _weapon?.Return();
                    _weapon = (IItemInventoryActivated)Weapon[index].Get();
                    break;
                case InventoryItemType.NPS:
                    _character = NPS[index];
                    break;
                case InventoryItemType.Necbox:
                    _character = Nexbot[index];
                    break;
            }
        }
        public IItemInventory GetItem() => _character;
    }
}