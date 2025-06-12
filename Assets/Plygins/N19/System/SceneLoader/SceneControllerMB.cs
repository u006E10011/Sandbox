using UnityEngine;
using UnityEngine.UI;

namespace N19
{
    public class SceneControllerMB : MonoBehaviour
    {
        [SerializeField] private Scene _scene;
        [SerializeField] private Button _button;

        private void Reset() => _button = _button != null ? _button : GetComponent<Button>();

        private void OnEnable() => _button.onClick.AddListener(Load);
        private void OnDisable() => _button.onClick.RemoveListener(Load);

        private async void Load() => await SceneLoader.LoadAsync(_scene);
    }
}