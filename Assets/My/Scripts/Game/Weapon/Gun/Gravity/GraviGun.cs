using UnityEngine;

namespace Project
{
    public class GraviGun : MonoBehaviour
    {
        private GravityGunConfig _config;

        [SerializeField, Space(10)] private Transform _point;

        private float _time;

        private void OnEnable()
        {
            IInputPlayer.OnShootAutomatic += Forward;
            IInputPlayer.OnMouse1 += Back;
        }

        private void OnDisable()
        {
            IInputPlayer.OnShootAutomatic -= Forward;
            IInputPlayer.OnMouse1 -= Back;
        }

        private void Start() => _config = LoaderConfig.GravityGunConfig;
        private void Update() => _time += Time.deltaTime;

        private void Forward() => AddForce(_config.ForceForward);
        private void Back() => AddForce(-_config.ForceBack);

        private void AddForce(float force)
        {
            if ((bool)EventBus.Instance.OnInventoryIsOpen?.Invoke())
                return;

            var hit = Physics.BoxCastAll(_point.position + Vector3.forward * (_config.Size.z / 2), _config.Size, _point.forward, Quaternion.identity, _config.MaxDistance, _config.Layer);

            for (int i = 0; i < hit.Length; i++)
            {
                var rb = hit[i].collider.attachedRigidbody;

                if (rb)
                {
                    var position = transform.position - rb.position;
                    rb.AddForceAtPosition(position * force, _point.position);
                }
            }

            if (_time >= _config.IntervalPlaySound)
                PlaySound();
        }

        private void PlaySound()
        {
            _time = 0;
            SoundController.Instance.Play2D(_config.ShotSound, LoaderConfig.SoundConfig.Mixer.GravirtGun);
        }

#if UNITY_EDITOR
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.white;
            Gizmos.DrawCube(_point.position + Vector3.forward * (_config.Size.z / 2), _config.Size);
        }
#endif
    }
}