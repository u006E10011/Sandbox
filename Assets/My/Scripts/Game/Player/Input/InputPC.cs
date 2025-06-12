using UnityEngine;

using static UnityEngine.Input;
using static N19.Constant;

namespace Project
{
    public class InputPC : IInputPlayer
    {
        #region bool
        public bool IsJump { get; set; }
        public bool IsAcceleration { get; set; }
        #endregion

        #region Vector2
        public Vector2 MoveDirection { get; set; }
        public Vector2 MouseDirection { get; set; }
        #endregion

        public void Update()
        {
            MoveDirection = new Vector2(GetAxis(HORIZONTAL), GetAxis(VERTICAL));
            MouseDirection = new Vector2(GetAxis(MOUSE_X), GetAxis(MOUSE_Y));

            Mouse();
            Keyboard();
        }

        private void Keyboard()
        {
            IsAcceleration = GetKey(KeyCode.LeftShift) && (MoveDirection.x != 0 || MoveDirection.y != 0);
            IsJump = GetKey(KeyCode.Space);

            if (GetKeyDown(KeyCode.Escape) || GetKeyDown(KeyCode.Tab))
                CursorController.CursorState();
        }

        private void Mouse()
        {
            if (GetMouseButtonDown(0))
                IInputPlayer.OnShot?.Invoke();
            if (GetMouseButton(0))
                IInputPlayer.OnShootAutomatic?.Invoke();

            if (GetMouseButtonDown(1))
                IInputPlayer.OnMouse1Down?.Invoke();
            if (GetMouseButton(1))
                IInputPlayer.OnMouse1?.Invoke();

            if (GetKeyDown(KeyCode.E))
                IInputPlayer.OnInterectable?.Invoke();
            if (GetKeyDown(KeyCode.F))
                IInputPlayer.OnInventory?.Invoke();
            if (GetKeyDown(KeyCode.R))
                IInputPlayer.OnReload?.Invoke();

        }
    }
}

