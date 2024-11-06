using UnityEngine;

namespace Project
{
    [System.Serializable]
    public class Visual
    {
        public ParticleSystem MuzzleEffect;

        public WeaponConfig _config;
        public AudioSource _audioSource;

        public void PerfomEffect()
        {
            if (MuzzleEffect)
                MuzzleEffect.Play();

            if (_audioSource && _config.AudioClip)
                _audioSource.PlayOneShot(_config.AudioClip);
        }

        public void SpawnParticleEffectOnHit(RaycastHit hit, bool isEnemy)
        {
            if (_config.HitEffect)
            {
                var effectType = isEnemy ? _config.HitEffect : _config.OtherEffect;
                var effectRotation = Quaternion.LookRotation(hit.normal);
                var effect = Object.Instantiate(effectType, hit.point, effectRotation);

                Object.Destroy(effect.gameObject, _config.LifeTime);
            }
        }
    }
}
