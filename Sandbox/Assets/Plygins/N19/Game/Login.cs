using UnityEngine;
using YG;
using N19;

namespace Project
{
    public class Login : MonoBehaviour
    {
        private void OnEnable()
        {
            YandexGame.GetDataEvent += Language.Check;
        }

        private void OnDisable()
        {
            YandexGame.GetDataEvent -= Language.Check;
        }

        private void Start()
        {
            if (YandexGame.SDKEnabled)
                Language.Check();
        }
    }
}