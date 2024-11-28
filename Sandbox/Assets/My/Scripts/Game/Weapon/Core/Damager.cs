using System;
using UnityEngine;

namespace Project
{
    public class Damager : MonoBehaviour
    {
        public event Action OnShootEvent;

        private int _currentAmmo;
        private float _timer;

        private WeaponConfig _config;

        private void OnEnable() => IInputPlayer.OnReload += InvokeReload;

        private void OnDisable()
        {
            IInputPlayer.OnReload -= InvokeReload;

            if (_config && _config.IsAutomatic)
                IInputPlayer.OnShootAutomatic -= Shot;
            else
                IInputPlayer.OnShot -= Shot;
        }

        private void Update() => _timer += Time.deltaTime;

        public void GetData(WeaponConfig config)
        {
            _config = config;

            _currentAmmo = config.MagazineSize;
            _timer = config.FireTime;

            if (_config.IsAutomatic)
                IInputPlayer.OnShootAutomatic += Shot;
            else
                IInputPlayer.OnShot += Shot;
        }

        private void Shot()
        {
            if ((bool)EventBus.Instance.OnInventoryIsOpen?.Invoke())
                return;

            if (_currentAmmo > 0 && _timer > _config.FireTime)
            {
                OnShootEvent?.Invoke();

                _currentAmmo--;
                _timer = 0;
            }

            if (_currentAmmo <= 0)
                InvokeReload();
        }

        public void InvokeReload() => Invoke(nameof(Reload), _config.ReloadTime);
        private void Reload() => _currentAmmo = _config.MagazineSize;
    }
}