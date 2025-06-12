using DG.Tweening;
using UnityEngine;

namespace Project
{
    public class ShakeCameraOnWeaponAttack : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private Damager _damager;
        [SerializeField] private ShakeCameraOnWeaponAttackConfig _config;

        private void OnEnable() => _damager.OnShootEvent += Animation;
        private void OnDisable() => _damager.OnShootEvent -= Animation;

        private void Animation()
        {
            if (!_config.IsActive)
                return;

            _camera.transform
                .DOShakePosition(_config.Duration, _config.Strength, _config.Vibrato, _config.Randomness, _config.Snapping, _config.FadeOut, _config.Mode)
                .SetEase(Ease.InOutBounce)
                .SetLink(_camera.gameObject);

            _camera.transform
                .DOShakeRotation(_config.Duration, _config.Strength, _config.Vibrato, _config.Randomness, _config.FadeOut, _config.Mode)
                .SetEase(Ease.InOutBounce)
                .SetLink(_camera.gameObject);
        }
    }
}