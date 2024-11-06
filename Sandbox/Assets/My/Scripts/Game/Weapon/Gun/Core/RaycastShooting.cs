using UnityEngine;

namespace Project
{
    public class RaycastShooting : MonoBehaviour
    {
        [SerializeField] private WeaponConfig _settings;
        [SerializeField] private Transform _shotPoint;

        [Space(10)] public Visual Visual;

        private Damager _damager;

        private void OnValidate()
        {
            _damager = _damager != null ? _damager : GetComponentInParent<Damager>();
        }

        private void OnEnable() => _damager.OnShootEvent += PerfomAttack;
        private void OnDisable() => _damager.OnShootEvent -= PerfomAttack;

        public void PerfomAttack()
        {
            for (int i = 0; i < _settings.ShotCount; i++)
                PerfomRaycast();

            Visual.PerfomEffect();
        }

        private void PerfomRaycast()
        {
            var direction = _settings.UseSpread ? _shotPoint.forward + CalculateSpread() : _shotPoint.forward;
            var ray = new Ray(_shotPoint.position, direction);

            if (Physics.Raycast(ray, out RaycastHit hit, _settings.Distance, _settings.ShowLayer))
            {
                Collider hitCollider = hit.collider;

                if (hit.transform.gameObject.layer == _settings.DamagebleLayer)
                {
                    if (hitCollider.TryGetComponent<IDamageble>(out var damageble))
                    {
                        damageble.ApplyDamage(_settings.Damage);
                        Visual.SpawnParticleEffectOnHit(hit, true);
                    }
                }
                else
                    Visual.SpawnParticleEffectOnHit(hit, false);
            }
        }

        private Vector3 CalculateSpread()
        {
            return new Vector3
            {
                x = Random.Range(-_settings.SpreadFactor, _settings.SpreadFactor),
                y = Random.Range(-_settings.SpreadFactor, _settings.SpreadFactor),
                z = Random.Range(-_settings.SpreadFactor, _settings.SpreadFactor)
            };
        }

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            var ray = new Ray(_shotPoint.position, _shotPoint.forward);

            if (Physics.Raycast(ray, out var hit, _settings.Distance, _settings.ShowLayer))
                DrawRay(ray, hit.point, hit.distance, Color.red);
            else
            {
                var hitPosition = ray.origin + ray.direction * _settings.Distance;

                DrawRay(ray, hitPosition, _settings.Distance, Color.green);
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

