using System.Collections.Generic;
using TMPro;
using UnityEngine;

using static N19.Language;

namespace N19
{
    public class Translate : MonoBehaviour
    {
        private const string REPLACE_SYMBOL = "&";

        [SerializeField] private bool _translateOnAwake = true;
        [SerializeField] private bool _translateOnEnable = true;

        [SerializeField, Space(10)] private TMP_Text _text;

        [SerializeField, Space(10)] private TranslateConfig _config;
        
        public string Value { get; private set; }

        private void Reset() => _text = _text != null ? _text : GetComponent<TMP_Text>();
        private void OnValidate() => _text.font = _config.Font;

        private void Awake()
        {
            if(_text.font != _config.Font)
                _text.font = _config.Font;

            if (_translateOnAwake)
                Set();
        }

        private void OnEnable()
        {
            OnTranslate += Set;

            if (_translateOnEnable)
                Set();
        }

        private void OnDestroy() => OnTranslate -= Set;

        public void Set()
        {
            GetValue();

            _text.text = Value;
        }

        public string Replace(string value, string path = REPLACE_SYMBOL)
        {
            GetValue();

            _text.text = Value.Replace(path + 0, value);

            return Value;
        }

        public string Replace(List<string> value)
        {
            GetValue();

            for (int i = 0; i < value.Count ; i++)
                Value.Replace(REPLACE_SYMBOL + i, value[i]);

            _text.text = Value;

            return Value;
        }

        public void SetTranslateConfig(TranslateConfig config) => _config = config;
        private void GetValue()
        {
            Value = Language.Value switch
            {
                LanguageType.RU => _config.RU,
                LanguageType.EN => _config.EN,
                LanguageType.TR => _config.TR,
                _ => _config.EN
            };
        }

    }
}