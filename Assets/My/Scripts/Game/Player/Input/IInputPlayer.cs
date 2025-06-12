using UnityEngine;
using System;

namespace Project
{
    public interface IInputPlayer
    {
        #region Action
        public static Action OnShootAutomatic;
        public static Action OnShot;

        public static Action OnMouse1Down;
        public static Action OnMouse1;

        public static Action OnInterectable;
        public static Action OnInventory;
        public static Action OnReload;
        #endregion

        #region bool
        public bool IsJump { get; set; }
        public bool IsAcceleration { get; set; }
        #endregion

        public Vector2 MoveDirection { get; set; }
        public Vector2 MouseDirection { get; set; }

        void Update();
    }
}