using Project.Inventory;
using UnityEngine;

namespace Project
{
    public static class LoaderConfig
    {
        #region Player
        public static PlayerConfig PlayerConfig { get; private set; }
        #endregion

        #region Inventory
        public static InventoryRaycastCreateConfig InventoryRaycastCreateConfig { get; private set; }
        public static RaycastItemCreaterConfig RaycastItemCreaterConfig { get; private set; }
        #endregion

        #region Weapon
        public static GravityGunConfig GravityGunConfig { get; private set; }
        public static PortalGunConfig PortalGunConfig { get; private set; }
        #endregion

        #region Sound
        public static FootSoundConfig FootSoundConfig { get; private set; }
        public static SoundConfig SoundConfig { get; private set; }
        #endregion

        public static void Init()
        {
            #region Player
            PlayerConfig = Resources.Load<PlayerConfig>(Path.PLAYER_CONFIG);
            #endregion

            #region Inventory
            InventoryRaycastCreateConfig = Resources.Load<InventoryRaycastCreateConfig>(Path.INVENTORY_RAYCAST_CREATE_CONFIG);
            RaycastItemCreaterConfig = Resources.Load<RaycastItemCreaterConfig>(Path.RAYCAST_ITEM_CREATER_CONFIG);
            #endregion

            #region Weapon
            
            GravityGunConfig = Resources.Load<GravityGunConfig>(Path.GRAVITY_GUN_CONFIG);
            PortalGunConfig = Resources.Load<PortalGunConfig>(Path.PORTAL_GUN_CONFIG);
            #endregion

            #region Sound
            FootSoundConfig = Resources.Load<FootSoundConfig>(Path.FOOT_SOUND_CONFIG);
            SoundConfig = Resources.Load<SoundConfig>(Path.SOUND_CONFIG_CONFIG);
            #endregion
        }
    }
}