using System.Collections.Generic;
using UnityEngine;

namespace Project.Inventory
{
    public class Inventory : MonoBehaviour, ISwitchInventoryItem
    {
        public List<IInventoryItemActivated> Weapon { get; private set; } = new();
        public List<IInventoryItemCreated> NPC { get; private set; } = new();
        public List<IInventoryItemCreated> Nextbot { get; private set; } = new();

        private IInventoryItemActivated _weapon;
        private IInventoryItemCreated _raycastCrate;

        public void Init(Transform containerItemInventoryWeapon, Transform containerItemInventoryNPS, Transform containerItemInventoryNexbot)
        {
            Weapon = new(containerItemInventoryWeapon.GetComponentsInChildren<IInventoryItemActivated>(true));
            NPC = new(containerItemInventoryNPS.GetComponentsInChildren<IInventoryItemCreated>(true));
            Nextbot = new(containerItemInventoryNexbot.GetComponentsInChildren<IInventoryItemCreated>(true));

            _raycastCrate = NPC?[0];
            Switch(InventoryItemType.Weapon, 0);
            Debug.Log($"Weapon count: {Weapon.Count}");
            Debug.Log($"NPC count: {NPC.Count}");
            Debug.Log($"Nextbot count: {Nextbot.Count}");
        }

        public void Switch(InventoryItemType type, int index)
        {
            _weapon?.Return();

            switch (type)
            {
                case InventoryItemType.Weapon:
                    _weapon = (IInventoryItemActivated)Weapon[index].Get();
                    break;
                case InventoryItemType.NPC:
                    _raycastCrate = NPC[index];
                    SetWeaponRaycastCreater();
                    break;
                case InventoryItemType.Nextbot:
                    _raycastCrate = Nextbot[index];
                    SetWeaponRaycastCreater();
                    break;
            }
        }
        public IInventoryItem GetItem() => _raycastCrate;

        private void SetWeaponRaycastCreater()
        {
            _weapon = (IInventoryItemActivated)Weapon[LoaderConfig.InventoryRaycastCreateConfig.IndexRaycastItemCreatePistol].Get();
        }
    }
}