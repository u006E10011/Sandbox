using N19;
using UnityEngine;
using UnityEngine.UI;

namespace Project
{
    public class InputPlayer : MonoBehaviour
    {
        #region Instance
        private static IInputPlayer _instance;
        public static IInputPlayer Instance
        {
            get => _instance;
            set => _instance = value;
        }
        #endregion

        #region Mobile
        [SerializeField] private Canvas _inputMobile;
        [SerializeField] private Joystick _joystick;

        [SerializeField, Space(10)] private SelectButton _jumpButton;
        [SerializeField] private SelectButton _accelerationButton;
        [SerializeField] private Button _shotButton;
        [SerializeField] private Button _reloadGunButton;
        [SerializeField] private Button _inventoryButton;
        #endregion

        private void Awake()
        {
            PlatformController.OnShowPlatform?.Invoke();

            _instance = PlatformController.Type == PlatformType.PC 
                ? new InputPC() 
                : new InputMobile(_joystick, _jumpButton, _accelerationButton, _shotButton, _reloadGunButton, _inventoryButton);
        }

        private void OnEnable()
        {
            if (_instance is InputMobile input)
            {
                input.AddListener();
                _inputMobile.gameObject.Activate();
                _inventoryButton.gameObject.Activate();
            }
        }

        private void OnDisable()
        {
            if (_instance is InputMobile input)
                input.RemoveListener();
        }

        private void Update() => _instance.Update();
    }
}