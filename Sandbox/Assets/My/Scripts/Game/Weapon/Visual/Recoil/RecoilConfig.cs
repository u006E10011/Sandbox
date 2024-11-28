using UnityEngine;

namespace Project
{
    [CreateAssetMenu(fileName = nameof(RecoilConfig), menuName = "Config/Weapon/" + nameof(RecoilConfig))]
    public class RecoilConfig : ScriptableObject
    {
        public float Snappiness = 15;
        public float ReturnSpeed = 10;

        [Space(10)] public Vector3 Recoil = new(-2, 1, 1);
    }
}