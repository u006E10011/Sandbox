using N19;
using System.Collections.Generic;
using UnityEngine;

namespace Project
{
    [CreateAssetMenu(fileName = nameof(FootSoundConfig), menuName = "Config/Character/" + nameof(FootSoundConfig))]
    public class FootSoundConfig : ScriptableObject
    {
        public MinMax IntervalIdle;
        public MinMax IntervalRunning;

        [Space(5)] public MinMax Pich = new(0.95f, 1.05f);

        [Space(5)] public List<AudioClip> Clip = new();
    }
}