using UnityEngine;

namespace Project
{
    public class RaycastShooting : MonoBehaviour
    {
        [SerializeField] private WeaponConfig _config;
        [SerializeField] private Transform _shotPoint;

        [Space(10)] public WeaponParticleSystem WeaponParticleSystem;

        private Damager _damager;

        private void OnValidate() => _damager = _damager != null ? _damager : GetComponentInParent<Damager>();
        private void Awake() => WeaponParticleSystem.Init(this, _config);

        private void OnEnable()
        {
            _damager.GetData(_config);
            _damager.OnShootEvent += PerfomAttack;
        }

        private void OnDisable() => _damager.OnShootEvent -= PerfomAttack;

        public void PerfomAttack()
        {
            for (int i = 0; i < _config.ShotCount; i++)
                PerfomRaycast();

            WeaponParticleSystem.PerfomEffect();
        }

        private void PerfomRaycast()
        {
            var direction = _config.UseSpread ? _shotPoint.forward + CalculateSpread() : _shotPoint.forward;
            var ray = new Ray(_shotPoint.position, direction);

            if (Physics.Raycast(ray, out RaycastHit hit, _config.Distance, _config.ShowLayer))
            {
                Collider hitCollider = hit.collider;

                if (hit.transform.gameObject.layer == Layer.ENEMY)
                {
                    if (hitCollider.TryGetComponent<IDamageble>(out var damageble))
                    {
                        damageble.ApplyDamage(_config.Damage);
                        WeaponParticleSystem.SpawnParticleEffectOnHit(hit, true);
                    }
                }
                else
                    WeaponParticleSystem.SpawnParticleEffectOnHit(hit, false);
            }

            SoundController.Instance.Play2D(_config.ShotSound, mixer: LoaderConfig.SoundConfig.Mixer.Raycast);
        }

        private Vector3 CalculateSpread()
        {
            return new Vector3
            {
                x = Random.Range(-_config.SpreadFactor, _config.SpreadFactor),
                y = Random.Range(-_config.SpreadFactor, _config.SpreadFactor),
                z = Random.Range(-_config.SpreadFactor, _config.SpreadFactor)
            };
        }

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            var ray = new Ray(_shotPoint.position, _shotPoint.forward);

            if (Physics.Raycast(ray, out var hit, _config.Distance, _config.ShowLayer))
                DrawRay(ray, hit.point, hit.distance, Color.red);
            else
            {
                var hitPosition = ray.origin + ray.direction * _config.Distance;

                DrawRay(ray, hitPosition, _config.Distance, Color.green);
            }
        }

        private static void DrawRay(Ray ray, Vector3 hitPosition, float distance, Color color)
        {
            const float hitPositionRadius = 0.15f;

            Debug.DrawRay(ray.origin, ray.direction * distance, color);

            Gizmos.color = color;
            Gizmos.DrawSphere(hitPosition, hitPositionRadius);
        }

#endif
    }
}

