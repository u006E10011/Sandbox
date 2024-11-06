using System;

namespace Project
{
    public class EventBus
    {
        private static EventBus _instance;
        public static EventBus Instance { get => _instance ??= new EventBus(); }

        public Func<bool> OnInventoryIsOpen;
    }
}
