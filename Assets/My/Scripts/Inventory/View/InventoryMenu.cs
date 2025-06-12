using UnityEngine;

namespace Project.Inventory
{
    public class InventoryMenu : MonoBehaviour
    {
        [SerializeField] private GameObject _menu;

        private void Start()
        {
            IInputPlayer.OnInventory += MenuState;
            EventBus.Instance.OnInventoryIsOpen += ActiveSelf;
        }

        private void OnDisable()
        {
            IInputPlayer.OnInventory -= MenuState;
            EventBus.Instance.OnInventoryIsOpen -= ActiveSelf;
        }

        private void MenuState()
        {
            _menu.SetActive(!_menu.activeSelf);
            CursorController.CursorState(_menu.activeSelf);
        }

        private bool ActiveSelf() => _menu.activeSelf;
    }
}