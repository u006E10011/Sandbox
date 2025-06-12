using UnityEngine;
using Project.Inventory;

namespace Project
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private PlayerController _player;

        #region Inventory
        [Tooltip("Inventory")]
        [SerializeField] private Transform _containerItemInventoryWeapon;
        [SerializeField] private Transform _containerItemInventoryNPC;
        [SerializeField] private Transform _containerItemInventoryNextbot;

        [SerializeField, Space(10)] private Inventory.Inventory _inventory;
        [SerializeField] private InventoryMenu _inventoryMenu;
        [SerializeField] private RaycastItemCreater _creater;
        [SerializeField] private ButtonCreater _buttonCreater;

        [SerializeField, Space(10)] private ObjectPoolLoader _objectPoolLoader;
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
            _objectPoolLoader.Init(_player.transform);

            _creater.Init(_inventory);
            _inventory.Init(_containerItemInventoryWeapon, _containerItemInventoryNPC, _containerItemInventoryNextbot);
            _buttonCreater.Init(_inventory);
        }
    }
}