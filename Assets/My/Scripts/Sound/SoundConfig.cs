using UnityEngine;
using UnityEngine.Audio;

namespace Project
{
    [CreateAssetMenu(fileName = nameof(SoundConfig), menuName = "Config/System/" + nameof(SoundConfig))]
    public class SoundConfig : ScriptableObject
    {
        public Mixer Mixer;
    }

    [System.Serializable]
    public class Mixer
    {
        public AudioMixerGroup Dead;
        public AudioMixerGroup Foot;
        public AudioMixerGroup Explosion;

        [Header("Weapon")]
        public AudioMixerGroup Raycast;
        public AudioMixerGroup GravirtGun;
        public AudioMixerGroup PortalGun;
        public AudioMixerGroup RaycastItemCreater;
    }
}