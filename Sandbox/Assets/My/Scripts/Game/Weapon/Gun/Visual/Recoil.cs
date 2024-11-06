using UnityEngine;

namespace Project
{
    public class Recoil : MonoBehaviour
    {
        [SerializeField] private WeaponConfig _settings;

        private Vector3 _currentRotation;
        private Vector3 _targetRotation;

        private Damager _damager;

        private void OnValidate() => _damager = _damager != null ? _damager : GetComponentInParent<Damager>();

        private void OnEnable() => _damager.OnShootEvent += RecoilShot;
        private void OnDisable() => _damager.OnShootEvent -= RecoilShot;

        private void Update() => Rotate();

        private void Rotate()
        {
            _targetRotation = Vector3.Lerp(_targetRotation, Vector3.zero, _settings.ReturnSpeed * Time.deltaTime);
            _currentRotation = Vector3.Slerp(_currentRotation, _targetRotation, _settings.Snappiness * Time.deltaTime);
            transform.localRotation = Quaternion.Euler(_currentRotation);
        }

        private void RecoilShot() => _targetRotation +=
            new Vector3(_settings.Recoil.x,
            Random.Range(-_settings.Recoil.y, _settings.Recoil.y),
            Random.Range(-_settings.Recoil.z, _settings.Recoil.z));
    }
}