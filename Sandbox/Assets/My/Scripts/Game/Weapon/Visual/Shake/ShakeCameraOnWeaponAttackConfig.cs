using DG.Tweening;
using UnityEngine;

namespace Project
{
    [CreateAssetMenu(fileName = nameof(ShakeCameraOnWeaponAttackConfig), menuName = "Config/Weapon/" + nameof(ShakeCameraOnWeaponAttackConfig))]
    public class ShakeCameraOnWeaponAttackConfig : ScriptableObject
    {
         public bool IsActive = true;

        [Space(10)]
        public float Duration = .15f;
        public float Strength = 1;
        public float Randomness = 90;
        public int Vibrato = 10;

        [Space(10)]
        public bool Snapping = false;
        public bool FadeOut = true;

        [Space(10)] public ShakeRandomnessMode Mode = ShakeRandomnessMode.Harmonic;
    }
}