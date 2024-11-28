using UnityEngine;
using UnityEngine.Audio;

namespace Project
{
    public class SoundController : MonoBehaviour
    {
        public static SoundController Instance { get; private set; }

        [SerializeField] private AudioSource _source2D;
        [SerializeField] private AudioSource _source3D;

        private void Awake()
        {
            transform.parent = null;

            if (!Instance)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);

                return;
            }

            Destroy(gameObject);
        }

        public void Play2D(AudioClip clip, float pitch = 1)
        {
            _source2D.outputAudioMixerGroup = null;
            _source2D.pitch = pitch;
            _source2D?.PlayOneShot(clip);
        }

        public void Play2D(AudioClip clip, AudioMixerGroup mixer, float pitch = 1)
        {
            _source2D.outputAudioMixerGroup = mixer;
            _source2D.pitch = pitch;
            _source2D?.PlayOneShot(clip);
        }

        public void Play3D(AudioClip clip, AudioMixerGroup mixer, Vector3 position, float spatiaBlend = .8f, float pitch = 1)
        {
            _source3D.transform.position = position;
            _source3D.outputAudioMixerGroup = mixer;
            _source3D.pitch = pitch;
            _source3D?.PlayOneShot(clip);
        }

    }
}