using System;
using UnityEngine;

namespace Project
{
    public enum Pause
    {
        On,
        Off
    }

    public static class PauseController
    {
        public static Action OnPauseOn;
        public static Action OnPauseOff;

        public static Pause Value { get; private set; } = Pause.Off;

        public static void SwitchPause(Pause pause)
        {
            System.Action action = pause switch
            {
                Pause.On => () => On(),
                Pause.Off => () => Off(),
                _ => () => Off(),
            };

            action?.Invoke();
        }

        private static void On()
        {
            Time.timeScale = 0;

           OnPauseOn?.Invoke();
        }

        private static void Off()
        {
            Time.timeScale = 0;

            OnPauseOff?.Invoke();
        }
    }

}