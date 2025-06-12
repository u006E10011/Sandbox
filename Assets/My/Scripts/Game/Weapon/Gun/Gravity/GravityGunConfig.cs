using UnityEngine;

namespace Project
{
    [CreateAssetMenu(fileName = nameof(GravityGunConfig), menuName = "Config/Weapon/" + nameof(GravityGunConfig))]
    public class GravityGunConfig : ScriptableObject
    {
        public float MaxDistance;
        public float ForceForward = 15;
        public float ForceBack = 15;

        [Space(5)]
        public float IntervalPlaySound = .1f;

        [Space(5)]
        public Vector3 Size = new(0.3f, 0.3f, 15);
        public LayerMask Layer;

        [Space(10)] public AudioClip ShotSound;
    }
}