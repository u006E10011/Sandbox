using UnityEngine;

namespace Project
{
    public static class LoaderConfig
    {
        public static PlayerConfig PlayerConfig { get; private set; }

        public static InventoryConfig InventoryConfig { get; private set; }
        public static RaycastItemCreaterConfig RaycastItemCreaterConfig { get; private set; }

        public static void Init()
        {
            PlayerConfig = Resources.Load<PlayerConfig>(Path.PLAYER_CONFIG);
            InventoryConfig = Resources.Load<InventoryConfig>(Path.INVENTORY_CONFIG);
            RaycastItemCreaterConfig = Resources.Load<RaycastItemCreaterConfig>(Path.RAYCAST_ITEM_CREATER_CONFIG);
        }
    }
}