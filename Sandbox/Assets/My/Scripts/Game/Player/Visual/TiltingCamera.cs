using N19;
using UnityEngine;

namespace Project
{
    public class TiltingCamera : MonoBehaviour
    {
        [SerializeField] private float _smoothing;
        [SerializeField] private MinMax _minMax = new(-5, 5);

        private float value;
        private Vector3 _eulerAngles;

        private void LateUpdate()
        {
            value += Time.deltaTime;
            _eulerAngles = transform.localEulerAngles;

            if (Input.GetKey(KeyCode.D))
                value -= _smoothing * Time.deltaTime;
            else if (Input.GetKey(KeyCode.A))
                value += _smoothing * Time.deltaTime;
            else
            {
                if (value > 0)
                {
                    value -= _smoothing * Time.deltaTime;

                    if (value <= 0)
                        value = 0;
                }
                else
                {
                    value += _smoothing * Time.deltaTime;

                    if (value >= 0)
                        value = 0;
                }
            }

            value = Mathf.Clamp(value, _minMax.Min, _minMax.Max);

            _eulerAngles.z = value;
            transform.localEulerAngles = _eulerAngles;
        }
    }
}