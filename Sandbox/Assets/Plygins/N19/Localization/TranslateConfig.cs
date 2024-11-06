using UnityEngine;

namespace N19
{
    [CreateAssetMenu(fileName = "Translate", menuName = "Config/TranslateConfig")]
    public class TranslateConfig : ScriptableObject
    {
        [TextArea] public string RU;
        [TextArea] public string EN;
        [TextArea] public string TR;

        [Space(10)] public TMPro.TMP_FontAsset Font;
    }
}