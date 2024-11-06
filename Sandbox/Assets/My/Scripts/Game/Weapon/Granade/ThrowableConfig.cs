using System.Collections;
using UnityEngine;

namespace Project
{
    [CreateAssetMenu(fileName = nameof(ThrowableConfig), menuName = "Config/Trowable" + nameof(ThrowableConfig))]
    public class ThrowableConfig : ScriptableObject
    {
        public float ThrowCooldown;
        public float throwUpForce;
        public float throwForce;

        public GameObject Item;
    }
}