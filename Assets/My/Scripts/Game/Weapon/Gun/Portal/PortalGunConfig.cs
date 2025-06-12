using UnityEngine;

namespace Project
{
    [CreateAssetMenu(fileName = nameof(PortalGunConfig), menuName = "Config/Weapon/" + nameof(PortalGunConfig))]
    public class PortalGunConfig : ScriptableObject
    {
        public float Offset = 1;
        public float MaxDistance = Mathf.Infinity;

        [Space(5)] public LayerMask Layer;

        [Space(10)] public AudioClip ShotSound;
    }
}