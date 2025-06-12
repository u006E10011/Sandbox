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
        
        public string Value
        {
            get
            {
                return Value == string.Empty ? GetValue() : Value;
            }
            private set => Value = value;
        }

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

        /// <summary>
        /// Вставляет в поле с текстом текст, который находится в конфиге, в зависимости он выбранного языка
        /// </summary>
        public void Set()
        {
            GetValue();

            _text.text = Value;
        }

        /// <summary>
        /// Добавляет к текущему тексту ваш текст
        /// 
        /// <br> </br>
        /// <br>Примечание</br>
        /// <br>Если метод Set ниразу не вызывался, то он вызывится</br>
        /// </summary>
        /// <param name="value">Ваш текст</param>
        public void Add(object value)
        {
            if(Value == string.Empty)
                Set();

            _text.text += value;
        }

        #region Replase
        /// <summary>
        /// Заменяет специльаный симвов, на переданный текст
        /// </summary>
        /// <param name="value">Текст</param>
        /// <param name="path">Специальный символ</param>
        /// <returns></returns>
        public string Replace(object value, string path = REPLACE_SYMBOL)
        {
            GetValue();

            _text.text = Value.Replace(path, value.ToString());

            return Value;
        }

        /// <summary>
        /// Заменяет специльаный символ, на переданный список текстов. Замена происходит в хронологическом порядке
        /// </summary>
        /// <param name="value">Список текстов</param>
        /// <param name="path">Специальный символ</param>
        /// <returns></returns>
        public string Replace(List<object> value, string path = REPLACE_SYMBOL)
        {
            GetValue();

            for (int i = 0; i < value.Count ; i++)
                Value.Replace(path, value[i].ToString());

            _text.text = Value;

            return Value;
        }
        #endregion

        #region Data
        /// <summary>
        /// Задаёт конфиг
        /// </summary>
        /// <param name="config">Конфиг с переводом</param>
        public void SetTranslateConfig(TranslateConfig config) => _config = config;
        private string GetValue()
        {
            Value = Language.Value switch
            {
                LanguageType.RU => _config.RU,
                LanguageType.EN => _config.EN,
                LanguageType.TR => _config.TR,
                _ => _config.EN
            };

            return Value;
        }
        #endregion

    }
}