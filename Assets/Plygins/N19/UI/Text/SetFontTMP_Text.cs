using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace N19
{
    public class SetFontTMP_Text : MonoBehaviour
    {
#if UNITY_EDITOR
        [SerializeField] private TMP_FontAsset _font;

        [SerializeField, Min(0), Space(10)] private int _index;
        [SerializeField] private List<TMP_FontAsset> _fonts;

        [SerializeField, Space(5)] private List<TMP_Text> _text;

        private int _oldIndex;

        private void Reset() => Get();

        private void OnValidate()
        {
            ShowNull();

            if (_oldIndex != _index)
            {
                if (!Validate())
                    return;

                Set(_fonts[_index]);
                _oldIndex = _index;
            }
            else if (_text[0].font != _font)
                Set(_font);
        }


        [ContextMenu(nameof(Get))]
        public void Get() => _text = new List<TMP_Text>(FindObjectsByType<TMP_Text>(FindObjectsInactive.Include, FindObjectsSortMode.None));


        [ContextMenu(nameof(Set))]
        public void Set(TMP_FontAsset font)
        {
            ShowNull();

            for (int i = 0; i < _text.Count; i++)
            {
                if (_text[i] == null)
                    _text.Remove(_text[i]);

                _text[i].font = font;
            }

            _font = font;
        }

        private bool Validate()
        {
            if (_index >= _fonts.Count)
            {
                _index = _fonts.Count - 1;
                return false;
            }

            return true;
        }

        private void ShowNull()
        {
            for (int i = 0; i < _text.Count; i++)
            {
                if (_text[i] == null)
                    _text.Remove(_text[i]);
            }
        }
#endif
    }
}