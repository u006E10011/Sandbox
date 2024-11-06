using UnityEngine;

namespace Project
{
    [CreateAssetMenu(fileName = nameof(RaycastItemCreaterConfig), menuName = "Config/Inventory/RaycastItemCreaterConfig")]
    public class RaycastItemCreaterConfig : ScriptableObject
    {
        public float Reload;
        public N19.MinMax Distance;

        public LayerMask Layer;
    }
}