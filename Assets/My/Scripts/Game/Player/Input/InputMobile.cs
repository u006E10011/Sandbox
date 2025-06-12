using UnityEngine;
using UnityEngine.UI;

namespace Project
{
    public class InputMobile : IInputPlayer
    {
        public InputMobile(Joystick joystick, SelectButton jump, SelectButton acceleration, Button shot, Button reload, Button inventory)
        {
            _move = joystick;
            _jump = jump;
            _relaod = reload;
            _shot = shot;
            _acceleration = acceleration;
            _inventory = inventory;
        }

        #region Propertis
        public bool IsJump { get; set; }
        public bool IsAcceleration { get; set; }

        public Vector2 MoveDirection { get; set; }
        public Vector2 MouseDirection { get; set; }
        #endregion

        #region Private
        private readonly Joystick _move;
        private readonly SelectButton _jump;
        private readonly SelectButton _acceleration;
        private readonly Button _relaod;
        private readonly Button _shot;
        private readonly Button _inventory;
        #endregion

        public void Update()
        {
            MoveDirection = new Vector2(_move.Horizontal, _move.Vertical);
            IsAcceleration = (MoveDirection.x != 0 || MoveDirection.y != 0) && _acceleration.IsSelected;
            IsJump = _jump.IsSelected;
        }

        public void AddListener()
        {
            _relaod.onClick.AddListener(() => IInputPlayer.OnReload?.Invoke());
            _shot.onClick.AddListener(() => IInputPlayer.OnShot?.Invoke());
            _shot.onClick.AddListener(() => IInputPlayer.OnShootAutomatic?.Invoke());
            _inventory.onClick.AddListener(() => IInputPlayer.OnInventory?.Invoke());
        }

        public void RemoveListener()
        {
            _relaod.onClick.RemoveListener(() => IInputPlayer.OnReload?.Invoke());
            _shot.onClick.RemoveListener(() => IInputPlayer.OnShot?.Invoke());
            _shot.onClick.RemoveListener(() => IInputPlayer.OnShootAutomatic?.Invoke());
            _inventory.onClick.RemoveListener(() => IInputPlayer.OnInventory?.Invoke());
        }
    }
}