using System.Collections;
using UnityEngine;

namespace Project
{
    [CreateAssetMenu(fileName = nameof(ThrowableConfig), menuName = "Config/Trowable" + nameof(ThrowableConfig))]
    public class ThrowableConfig : ScriptableObject
    {
        public float ThrowCooldown;
        public float ThrowUpForce;
        public float ThrowForce;

        public GameObject Item;
    }
}