using System.Collections.Generic;
using UnityEngine;

namespace Project
{
    public class Bootstrap : MonoBehaviour
    {
        #region Inventory
        [Tooltip("Inventory")]
        [SerializeField] private Transform _containerItemInventoryWeapon;
        [SerializeField] private Transform _containerItemInventoryNPS;
        [SerializeField] private Transform _containerItemInventoryNexbot;

        [SerializeField, Space(10)] private Inventory _inventory;
        [SerializeField] private InventoryMenu _inventoryMenu;
        [SerializeField] private RaycastItemCreater _creater;

        [SerializeField, Space(10)] private List<ItemInventoryCreated> _itemCreater;
        #endregion

        private void Awake()
        {
            Application.targetFrameRate = 60;

            LoaderConfig.Init();
            CursorController.CursorState(false);

            Inventory();
        }

        private void Inventory()
        {
            for (int i = 0; i < _itemCreater.Count; i++)
                _itemCreater[i].Init();

            _inventory.Init(_containerItemInventoryWeapon, _containerItemInventoryNPS, _containerItemInventoryNexbot);
            _inventoryMenu.Init(_inventory);
            _creater.Init(_inventory);
        }
    }
}