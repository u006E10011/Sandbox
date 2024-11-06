using UnityEngine;

namespace Project
{
    [CreateAssetMenu(fileName = "SwayConfig", menuName = "Config/Weapon/Sway")]
    public class SwayConfig : ScriptableObject
    {
        public float Speed;
        public Vector2 Force;

        [Space(5)] public bool InverseX;
        public bool InverseY;

        [Space(5)] public Vector2 MinMaxSwayX;
        public Vector2 MinMaxSwayY;
    }
}