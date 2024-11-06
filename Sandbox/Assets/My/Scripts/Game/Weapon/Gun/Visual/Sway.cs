using UnityEngine;

namespace Project
{
    public class Sway : MonoBehaviour
    {
        [SerializeField] private SwayConfig _config;

        private void LateUpdate()
        {
            var inverseX = _config.InverseX ? -1 : 1;
            var inverseY = _config.InverseY ? -1 : 1;

            float MX = PlayerInput.Instance.MouseDirection.x * _config.Force.x;
            float MY = PlayerInput.Instance.MouseDirection.y * _config.Force.y;

            MX = Mathf.Clamp(MX, _config.MinMaxSwayX.x, _config.MinMaxSwayX.y);
            MY = Mathf.Clamp(MY, _config.MinMaxSwayY.x, _config.MinMaxSwayY.y);

            var temp = transform.localEulerAngles;

            temp.x = Mathf.LerpAngle(temp.x, MY * inverseX, _config.Speed * Time.deltaTime);
            temp.y = Mathf.LerpAngle(temp.y, MX * inverseY, _config.Speed * Time.deltaTime);

            transform.localEulerAngles = temp;
        }
    }
}