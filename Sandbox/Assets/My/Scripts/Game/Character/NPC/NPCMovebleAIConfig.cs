using UnityEngine;

namespace Project
{
    [CreateAssetMenu(fileName = nameof(NPCMovebleAIConfig), menuName = "Config/Character/" + nameof(NPCMovebleAIConfig))]
    public class NPCMovebleAIConfig : ScriptableObject
    {
        [Header("Settings AI Navigation")]
        public float RadiusSpawnPoint = 15;
        public float Chance = .3f;
        public N19.MinMax Delay = new(1, 10);

        [Header("Steering")]
        public float Speed = 3.5f;
        public float IdleAndularSpeed = 0;
        public float WalkAndularSpeed = 120;
        public float Acceleration = 8;
        public float StoppingDistance = .5f;

        [Header("Obstacle Avoidance")]
        public float Radius = .5f;
        public float Height = 2;
    }
}