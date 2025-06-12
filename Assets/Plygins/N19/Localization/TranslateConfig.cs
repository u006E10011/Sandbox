using UnityEngine;

namespace N19
{
    [CreateAssetMenu(fileName = "Translate", menuName = "Config/TranslateConfig")]
    public class TranslateConfig : ScriptableObject
    {
        [TextArea] public string RU;
        [TextArea] public string EN;
        [TextArea] public string TR;

        [Tooltip("При нажатии на скрипт TranslateConfig, в инспекторе можно выбрать шрифт по умолчанию")]
        [Space(10)] public TMPro.TMP_FontAsset Font;
    }
}