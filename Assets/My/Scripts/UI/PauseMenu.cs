using N19;
using UnityEngine;
using UnityEngine.UI;

namespace Project
{
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField] private Button _enableButton;
        [SerializeField] private Button _disableButton;

        [SerializeField, Space(5)] private Button _restartButton;
        [SerializeField] private Button _mainMenutButton;

        [SerializeField, Space(10)] private GameObject _menu;

        private void OnEnable()
        {
            _enableButton.onClick.AddListener(Enable);
            _disableButton.onClick.AddListener(Disable);

            _restartButton.onClick.AddListener(Restart);
            _mainMenutButton.onClick.AddListener(MainMenu);
        }

        private void OnDisable()
        {
            _enableButton.onClick.RemoveListener(Enable);
            _disableButton.onClick.RemoveListener(Disable);

            _restartButton.onClick.RemoveListener(Restart);
            _mainMenutButton.onClick.RemoveListener(MainMenu);
        }

        private void Enable()
        {
            _menu.Activate();
        }

        private void Disable()
        {
            _menu.Deactivate();
        }

        private async void Restart() => await SceneLoader.LoadActiveSceneAsync();
        private async void MainMenu() => await SceneLoader.LoadAsync(Scene.MainMenu);
    }
}