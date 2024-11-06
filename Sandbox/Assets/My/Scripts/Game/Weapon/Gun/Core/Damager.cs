using System;
using UnityEngine;

using static Project.PlayerInput;

namespace Project
{
    public class Damager : MonoBehaviour
    {
        public event Action OnShootEvent;

        [SerializeField] private WeaponConfig _settings;

        private int _currentAmmo;
        private float _timer;

        private void OnEnable()
        {
            OnReload += InvokeReload;

            if (_settings.IsAutomatic)
                OnShootAutomatic += Shot;
            else
                OnShoot += Shot;
        }

        private void OnDisable()
        {
            OnReload -= InvokeReload;

            if (_settings.IsAutomatic)
                OnShootAutomatic -= Shot;
            else
                OnShoot -= Shot;
        }

        private void Start() => _currentAmmo = _settings.MagazineSize;

        private void Update() => _timer += Time.deltaTime;

        private void Shot()
        {
            if ((bool)EventBus.Instance.OnInventoryIsOpen?.Invoke())
                return;

            if (_currentAmmo > 0 && _timer > _settings.FireTime)
            {
                OnShootEvent?.Invoke();

                _currentAmmo--;
                _timer = 0;
            }

            if (_currentAmmo <= 0)
                InvokeReload();
        }

        public void InvokeReload() => Invoke(nameof(Reload), _settings.ReloadTime);
        private void Reload() => _currentAmmo = _settings.MagazineSize;
    }
}