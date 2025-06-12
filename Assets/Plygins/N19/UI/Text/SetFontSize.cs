using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace N19
{
    public class SetFontSize : MonoBehaviour
    {
        [SerializeField] private TMP_Text _referenceText;
        [SerializeField] private List<TMP_Text> _setText;

        private float _fontSize;

        private void Update() => Set();

        [ContextMenu(nameof(Set))]
        private void Set()
        {
            if (_fontSize != _referenceText.fontSize)
            {
                for (int i = 0; i < _setText.Count; i++)
                {
                    _setText[i].enableAutoSizing = false;
                    _setText[i].fontSize = _referenceText.fontSize;
                }

                _fontSize = _referenceText.fontSize;
            }
        }
    }
}
