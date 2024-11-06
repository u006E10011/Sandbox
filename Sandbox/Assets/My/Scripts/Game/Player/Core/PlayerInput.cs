using UnityEngine;
using System;

using static UnityEngine.Input;
using static N19.Constant;

namespace Project
{
    public class PlayerInput : MonoBehaviour
    {
        #region Instance
        private static PlayerInput _instance;
        public static PlayerInput Instance
        {
            get => _instance;
            set => _instance = value;
        }
        #endregion

        #region Action
        public static Action OnShootAutomatic;
        public static Action OnShoot;

        public static Action OnE;
        public static Action OnF;
        public static Action OnReload;
        #endregion

        #region bool
        public bool IsJump { get; private set; }
        public bool IsAcceleration { get; private set; }
        #endregion

        public Vector2 Direction { get; private set; }
        public Vector2 MouseDirection { get; private set; }

        private void Awake()
        {
            _instance = null;
            _instance = this;
        }

        private void Update()
        {
            Direction = new Vector2(Input.GetAxis(HORIZONTAL), Input.GetAxis(VERTICAL));
            MouseDirection = new Vector2(Input.GetAxis(MOUSE_X), Input.GetAxis(MOUSE_Y));

            Mouse();
            Keyboard();
        }

        private void Keyboard()
        {
            IsAcceleration = GetKey(KeyCode.LeftShift) && (Direction.x != 0 || Direction.y != 0);
            IsJump = GetKey(KeyCode.Space);

            if (GetKeyDown(KeyCode.Escape) || GetKeyDown(KeyCode.Tab))
                CursorController.CursorState();
        }

        private void Mouse()
        {
            if (GetMouseButtonDown(0))
                OnShoot?.Invoke();
            if (GetMouseButton(0))
                OnShootAutomatic?.Invoke();

            if (GetKeyDown(KeyCode.E))
                OnE?.Invoke();

            if (GetKeyDown(KeyCode.F))
                OnF?.Invoke();

            if (GetKeyDown(KeyCode.R))
                OnReload?.Invoke();

        }
    }
}

