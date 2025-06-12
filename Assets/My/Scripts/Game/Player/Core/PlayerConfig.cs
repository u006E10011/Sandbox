using UnityEngine;

namespace Project
{
    [CreateAssetMenu(fileName = nameof(PlayerConfig), menuName = "Config/Character/PlayerConfig")]
    public class PlayerConfig : ScriptableObject
    {
        [Header("Stats")]
        public float Speed = 15;
        public float MinSpeed = 5;
        public float Acceleration = 25;
        public float JumpHeight = 2;

        [Header("Mouse")]
        public float Sensitivity = 200;
        public N19.MinMax RotateMinMax = new(-90, 90);

        [Header("Physics")]
        public LayerMask Ground;
        public bool VisibleGizmos;
        public float Radius = 0.5f;
        public float Gravity = -9.8f;

        [Space(5)]
        public float MaxInertia = 500;
        public float InertiaMultiplier = 100;
        public float InertiaPeduction = 80;
    }
}