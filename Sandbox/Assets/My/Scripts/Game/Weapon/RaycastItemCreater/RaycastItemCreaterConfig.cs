using UnityEngine;

namespace Project
{
    [CreateAssetMenu(fileName = nameof(RaycastItemCreaterConfig), menuName = "Config/Inventory/RaycastItemCreaterConfig")]
    public class RaycastItemCreaterConfig : ScriptableObject
    {
        public float Reload;
        public N19.MinMax Distance;

        [Space(10)] public LayerMask Layer;

        [Space(10)] public AudioClip ShotSound;
    }
}