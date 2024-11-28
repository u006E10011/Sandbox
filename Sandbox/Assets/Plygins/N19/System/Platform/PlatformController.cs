using System;
using UnityEngine;
using YG;

namespace N19
{
    public class PlatformController : MonoBehaviour
    {
        public static Action OnShowPlatform;
        public static PlatformType Type { get; private set; }

        [SerializeField] private bool _isEditor;
        [SerializeField] private PlatformType _platformType;

        private void OnEnable()
        {
            OnShowPlatform += GetData;
            YandexGame.GetDataEvent += GetData;
        }
        private void OnDisable()
        {
            OnShowPlatform -= GetData;
            YandexGame.GetDataEvent -= GetData;
        }

        private void GetData()
        {
            PlatformType platformType = YandexGame.EnvironmentData.isMobile ? PlatformType.Mobile : PlatformType.PC;

            if (!_isEditor)
            {
                _platformType = platformType;
                Type = platformType;
            }
            else
                Type = _platformType;
        }
    }
}