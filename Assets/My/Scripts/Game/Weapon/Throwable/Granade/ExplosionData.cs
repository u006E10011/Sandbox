using UnityEngine;

namespace Project
{
    [System.Serializable]
    public struct ExplosionData
    {
        public float ExplosionForce;
        public float DelayToExplosion;
        public float Radius;
        public float Damage;

        [Space(10)] public AudioClip ExplosionSound;
    }
}