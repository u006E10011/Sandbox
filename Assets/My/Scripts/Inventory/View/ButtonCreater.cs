using UnityEngine;
using UnityEngine.Events;

namespace Project.Inventory
{
    public class ButtonCreater : MonoBehaviour
    {
        [SerializeField] private InventoryButtonConfig _config;

        [SerializeField, Space(10)] private Transform _containerWeapon;
        [SerializeField] private Transform _containerNPC;
        [SerializeField] private Transform _containerNextbot;

        private Inventory _inventory;

        public void Init(Inventory inventory)
        {
            _inventory = inventory;

            CreaterButton(InventoryItemType.Weapon, _containerWeapon, _config.IconWeapon.Count);
            CreaterButton(InventoryItemType.NPC, _containerNPC, _config.IconNPC.Count);
            CreaterButton(InventoryItemType.Nextbot, _containerNextbot, _config.IconNextbot.Count);
        }

        private void CreaterButton(InventoryItemType type, Transform parent, int count)
        {
            for (int i = 0; i < count; i++)
            {
                var button = Instantiate(_config.PrefabButton, parent);
                button.onClick.AddListener(() => d(type, i));
            }
        }
        UnityAction d(InventoryItemType type, int count)
        {
            return () =>
            {
                _inventory.Switch(type, count);
                Debug.Log("invoke");
            };
        }
}
}