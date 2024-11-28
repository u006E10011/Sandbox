using N19;
using System.Collections;
using UnityEngine;

namespace Project
{
    [System.Serializable]
    public class WeaponParticleSystem
    {
        public ParticleSystem MuzzleEffect;

        public ParticleSystemObjectPool HitEffectPool;
        public ParticleSystemObjectPool OtherEffectPool;

        private WeaponConfig _config;
        private MonoBehaviour _owner;
        private WaitForSeconds _delay;

        public void Init(MonoBehaviour owner, WeaponConfig config)
        {
            _owner = owner;
            _config = config;

            HitEffectPool = new(_config.HitEffect, _config.Preload);
            OtherEffectPool = new(_config.OtherEffect, _config.Preload);

            _delay = new(_config.LifeTime);

            SetParent(HitEffectPool);
            SetParent(OtherEffectPool);
        }

        public void PerfomEffect()
        {
            if (MuzzleEffect)
                MuzzleEffect.Play();
        }

        public void SpawnParticleEffectOnHit(RaycastHit hit, bool isEnemy)
        {
            if (_config.HitEffect)
            {
                var objectPool = isEnemy ? HitEffectPool : OtherEffectPool;
                var effectType = objectPool.Get();

                effectType.transform.parent = hit.transform;
                effectType.transform.rotation = Quaternion.LookRotation(hit.normal);
                effectType.transform.position = hit.point;
                
                _owner.StartCoroutine(Return(objectPool, effectType));
            }
        }

        private IEnumerator Return(ParticleSystemObjectPool objectPool, ParticleSystem particle)
        {
            yield return _delay;

            particle.transform.parent = _owner.transform;
            objectPool.Return(particle);
        }

        private void SetParent(ParticleSystemObjectPool objectPool)
        {
            foreach (var item in objectPool.Pool)
                item.transform.parent = _owner.transform;
        }
    }
}
