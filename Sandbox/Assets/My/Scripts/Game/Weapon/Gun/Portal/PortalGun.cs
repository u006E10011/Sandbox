using UnityEngine;

namespace Project
{
    public class PortalGun : MonoBehaviour
    {
        [SerializeField] private CharacterController _player;
        [SerializeField] private Transform _head;

        private PortalGunConfig _config;

        private void OnEnable() => IInputPlayer.OnShot += Invoke;
        private void OnDisable() => IInputPlayer.OnShot -= Invoke;

        private void Start() => _config = LoaderConfig.PortalGunConfig;

        private void Invoke()
        {
            if ((bool)EventBus.Instance.OnInventoryIsOpen?.Invoke())
                return;

            _player.enabled = false;

            var ray = new Ray(_head.transform.position, _head.transform.forward);
            Physics.Raycast(ray, out RaycastHit hit, _config.MaxDistance, _config.Layer);

            _player.transform.position = hit.point + (_player.transform.position - hit.point).normalized * _config.Offset;

            _player.enabled = true;

            SoundController.Instance.Play2D(_config.ShotSound, LoaderConfig.SoundConfig.Mixer.PortalGun);
        }

        private void OnDrawGizmos()
        {
            if (gameObject.activeSelf)
            {
                Gizmos.color = Color.blue;
                Gizmos.DrawRay(_head.transform.position, _head.transform.forward * _config.MaxDistance);
            }
        }
    }
}