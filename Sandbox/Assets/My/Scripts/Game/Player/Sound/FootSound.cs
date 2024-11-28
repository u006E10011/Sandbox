using N19;
using UnityEngine;

namespace Project
{
    public class FootSound : MonoBehaviour
    {
        [SerializeField] private AudioSource _audio;

        private float _time;
        private FootSoundConfig _config;

        private void OnEnable()
        {
            PlayerController.OnRunningMove += Run;
            PlayerController.OnIdleMove += Idle;
        }

        private void OnDisable()
        {
            PlayerController.OnRunningMove -= Run;
            PlayerController.OnIdleMove -= Idle;
        }

        private void Start() => _config = LoaderConfig.FootSoundConfig;
        private void Update() => _time += Time.deltaTime;

        private void Play(MinMax interval)
        {
            if (_time >= Random.Range(interval.Min, interval.Max))
            {
                var index = Random.Range(0, _config.Clip.Count);
                var clip = _config.Clip[index];

                _audio.clip = clip;
                _audio.pitch = Random.Range(_config.Pich.Min, _config.Pich.Max);

                _time = 0;
                _audio.Play();
            }
        }

        private void Idle() => Play(_config.IntervalIdle);
        private void Run() => Play(_config.IntervalRunning);
    }
}