using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using N19;

namespace Project
{
    [RequireComponent(typeof(AudioSource))]
    public class BackgroundSound : MonoBehaviour
    {
        public static BackgroundSound Instance { get; private set; }

        [SerializeField] private AudioSource _audioSource;

        private AudioMixerGroup _menuMixer;
        private AudioMixerGroup _gameMixer;

        private AudioClip _menuMusic;
        private AudioClip _gameMusic;

        private void OnValidate() => _audioSource = _audioSource != null ? _audioSource : GetComponent<AudioSource>();
        private void OnEnable() => SceneManager.sceneLoaded += SetSound;
        private void OnDisable() => SceneManager.sceneLoaded -= SetSound;

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

        /*private void Start()
        {
            _audioSource.volume = SaveSystem.GetFloat(Key.SOUND_VOLUME, 1);

            var config = LoaderConfig.SoundConfig;

            _menuMixer = config.UIMixer;
            _gameMixer = config.GameMixer;
            _menuMusic = config.MenuMusic;
            _gameMusic = config.GameMusic;

            _audioSource.clip = _menuMusic;
            _audioSource.outputAudioMixerGroup = _menuMixer;
            _audioSource.Play();
        }*/

        private void SetSound(UnityEngine.SceneManagement.Scene scene, LoadSceneMode mode)
        {
            _audioSource.clip = scene.buildIndex >= OffsetScene.OFFSET_LOGICK ? _gameMusic : _menuMusic;
            _audioSource.outputAudioMixerGroup = scene.buildIndex >= OffsetScene.OFFSET_LOGICK ? _gameMixer : _menuMixer;

            if (!_audioSource.isPlaying)
                _audioSource.Play();
        }

        public void VolumeChange(Slider slider, float volume)
        {
            if (slider)
                _audioSource.volume = volume;
        }

        public void ToggleSound(bool toggle)
        {
            _audioSource.mute = !toggle;
        }

    }
}