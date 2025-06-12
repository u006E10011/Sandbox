using UnityEngine;

namespace Project
{
   // [CreateAssetMenu(fileName = nameof(ThrowableConfig), menuName = "Config/Trowable" + nameof(ThrowableConfig))]
    public abstract class ThrowableConfig : ScriptableObject
    {
        public float ThrowCooldown;
        public float ThrowUpForce;
        public float ThrowForce;
    }
}