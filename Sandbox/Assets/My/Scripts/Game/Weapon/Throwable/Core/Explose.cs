using UnityEngine;
using N19;

namespace Project
{
    [System.Serializable]
    public class Explose
    {
        public ParticleSystem Effect;

        public void Explosion(MonoBehaviour owner, ExplosionData data)
        {
            Collider[] colliders = Physics.OverlapSphere(owner.transform.position, data.Radius);

            EffectPlay(owner);
            SoundController.Instance.Play3D(data.ExplosionSound, LoaderConfig.SoundConfig.Mixer.Explosion, position: owner.transform.position);

            for (int i = 0; i < colliders.Length; i++)
            {
                var rb = colliders[i].attachedRigidbody;

                if (rb)
                    rb.AddExplosionForce(data.ExplosionForce, owner.transform.position, data.Radius);

                if (colliders[i].TryGetComponent(out IDamageble health))
                    health.ApplyDamage(data.Damage);
            }
        }

        public void EffectPlay(MonoBehaviour owner)
        {
            Effect.gameObject.Activate();
            Effect.transform.position = owner.transform.position;
            Effect.transform.parent = null;
            Effect.Play();
        }
    }
}