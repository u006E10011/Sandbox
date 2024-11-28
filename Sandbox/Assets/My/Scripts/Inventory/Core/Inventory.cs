using System.Collections.Generic;
using UnityEngine;

namespace Project
{
    public class Inventory : MonoBehaviour, ISwitchItemInventory
    {
        public List<IItemInventoryActivated> Weapon { get; private set; } = new();
        public List<IItemInventoryCreatedRaycast> NPS { get; private set; } = new();
        public List<IItemInventoryCreatedRaycast> Nexbot { get; private set; } = new();

        private IItemInventoryActivated _weapon;
        private IItemInventoryCreatedRaycast _raycastCrate;

        public void Init(Transform containerItemInventoryWeapon, Transform containerItemInventoryNPS, Transform containerItemInventoryNexbot)
        {
            Weapon = new(containerItemInventoryWeapon.GetComponentsInChildren<IItemInventoryActivated>(true));
            NPS = new(containerItemInventoryNPS.GetComponentsInChildren<IItemInventoryCreatedRaycast>(true));
            Nexbot = new(containerItemInventoryNexbot.GetComponentsInChildren<IItemInventoryCreatedRaycast>(true));

            _weapon = Weapon?[0];
            _raycastCrate = NPS?[0];
        }


        public void Switch(InventoryItemType type, int index)
        {
            _weapon?.Return();

            switch (type)
            {
                case InventoryItemType.Weapon:
                    _weapon = (IItemInventoryActivated)Weapon[index].Get();
                    break;
                case InventoryItemType.NPS:
                    _raycastCrate = NPS[index];
                    _weapon = (IItemInventoryActivated)Weapon[LoaderConfig.InventoryConfig.IndexRaycastItemCreatePistol].Get();
                    break;
                case InventoryItemType.Necbox:
                    _raycastCrate = Nexbot[index];
                    _weapon = (IItemInventoryActivated)Weapon[LoaderConfig.InventoryConfig.IndexRaycastItemCreatePistol].Get();
                    break;
            }
        }
        public IItemInventory GetItem() => _raycastCrate;
    }
}