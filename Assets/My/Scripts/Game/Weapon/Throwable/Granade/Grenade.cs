using N19;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project
{
    public class Grenade : MonoBehaviour, IExplosion
    {
        [SerializeField] private GrenadeConfig _config;
        [SerializeField] private Rigidbody _rb;

        [SerializeField, Space(10)] private Color _GizmosDrawSphere;

        [Space(10)] public Explose Explose;

        private static readonly Dictionary<GameObject, Grenade> HasHed = new();

        private void OnEnable() => HasHed.Add(gameObject, this);
        private void OnDisable() => HasHed.Remove(gameObject);

        public IEnumerator Explosion(GameObjectPool objectPool, float delay)
        {
            yield return new WaitForSeconds(delay);

            Explose.Explosion(this, _config.Data);

            _rb.isKinematic = true;
            objectPool.Return(gameObject);
        }

        public static bool GetValue(GameObject key, out Grenade value)
        {
            return HasHed.TryGetValue(key, out value);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = _GizmosDrawSphere;
            Gizmos.DrawSphere(transform.position, _config.Data.Radius);
        }
    }
}
