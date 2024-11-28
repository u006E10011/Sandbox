using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Project
{
    public class InventoryMenu : MonoBehaviour
    {
        [SerializeField] private GameObject _menu;

        [SerializeField, Space(10)] private List<Button> _weapon = new();
        [SerializeField] private List<Button> _NPS = new();
        [SerializeField] private List<Button> _necbox = new();

        private Inventory _inventory;

        private void Start()
        {
            IInputPlayer.OnInventory += MenuState;
            EventBus.Instance.OnInventoryIsOpen += ActiveSelf;

            for (int i = 0; i < _inventory.Weapon.Count; i++)
                _weapon[i].onClick.AddListener(GetWeapon(i));

            for (int i = 0; i < _inventory.NPS.Count; i++)
                _NPS[i].onClick.AddListener(GetNPS(i));

            for (int i = 0; i < _inventory.Nexbot.Count; i++)
                _necbox[i].onClick.AddListener(GetNecbox(i));

            GetWeapon(0);
        }

        private void OnDisable()
        {
            IInputPlayer.OnInventory -= MenuState;
            EventBus.Instance.OnInventoryIsOpen -= ActiveSelf;
        }

        public void Init(Inventory inventory)
        {
            _inventory = inventory;
        }

        private void MenuState()
        {
            _menu.SetActive(!_menu.activeSelf);
            CursorController.CursorState(_menu.activeSelf);
        }

        private bool ActiveSelf() => _menu.activeSelf;

        private UnityAction GetWeapon(int index) => () => _inventory.Switch(InventoryItemType.Weapon, index);

        private UnityAction GetNPS(int index) => () => _inventory.Switch(InventoryItemType.NPS, index);

        private UnityAction GetNecbox(int index) => () => _inventory.Switch(InventoryItemType.Necbox, index);
    }
}