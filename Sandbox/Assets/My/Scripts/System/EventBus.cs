using System;

namespace Project
{
    public class EventBus
    {
        private static EventBus _instance;
        public static EventBus Instance { get => _instance ??= new EventBus(); }

        public Func<bool> OnInventoryIsOpen;

        #region UI
        public Action OnKillEnemy;
        public Action OnDiedPlayer;
        public Action OnHeadShot;

        public Action<float> OnGametime;
        public Action<float> OnDamageToEnemy;
        #endregion
    }
}