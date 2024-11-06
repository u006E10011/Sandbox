using System.Collections;
using UnityEngine;

using static Project.PlayerInput;

namespace Project
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Transform _camera;

        private float _rotationX;
        private float _speed;

        private Vector3 _direction;

        [Space(10)] public PhysicsPlayerController Physics;

        private PlayerConfig _config;
        private CharacterController _controller;
        private Coroutine _coroutine;

        private void Start() => Init();

        private void Update()
        {
            Physics.MathInertia();
            Physics.MathVelocity();

            Move();

            if (!CursorController.Visible)
                Rotate();

            Jump();
        }

        private void Init()
        {
            _config = LoaderConfig.PlayerConfig;
            _controller = GetComponent<CharacterController>();

            Physics.Init(_config);
        }

        private void Move()
         {
            _direction = transform.forward * Instance.Direction.y + transform.right * Instance.Direction.x;

            if ((Physics.IsGround || !Physics.CheckIsFlying()))
            {

                _speed = Instance.IsAcceleration ? _config.Acceleration : _config.Speed;
                _controller.Move(_direction * _speed * Time.deltaTime);
            }
            else
                _coroutine ??= StartCoroutine(Drag());
        }

        private void Rotate()
        {
            _rotationX -= Instance.MouseDirection.y * _config.Sensitivity * Time.deltaTime;
            _rotationX = Mathf.Clamp(_rotationX, _config.RotateMinMax.Min, _config.RotateMinMax.Max);

            _camera.localRotation = Quaternion.Euler(_rotationX, _camera.localRotation.y, _camera.localRotation.z);
            transform.Rotate((Vector3.up * Instance.MouseDirection.x * _config.Sensitivity) * Time.deltaTime);
        }

        private void Jump()
        {
            if (Physics.IsGround && Instance.IsJump)
                Physics.Velocity.y = Mathf.Sqrt(_config.JumpHeight * -2f * _config.Gravity);

            _controller.Move(Physics.Velocity * Time.deltaTime);
        }

        private IEnumerator Drag()
        {
            while (!Physics.IsGround && Physics.CheckIsFlying())
            {
                var direction = transform.forward + transform.right * Instance.Direction.x;

                _speed -= (_config.MaxInertia - Physics.Inertia) * Time.deltaTime;
                _speed = Mathf.Clamp(_speed, _config.MinSpeed, _config.Acceleration);
                _controller.Move(direction *  _speed* Time.deltaTime);

                yield return null;
            }

            _speed = Instance.IsAcceleration ? _config.Acceleration : _config.Speed;
            _coroutine = null;
        }



#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            if (!Application.isPlaying || !_config.VisibleGizmos)
                return;

            if (Physics.CheckIsFlying())
                Gizmos.color = Color.yellow;
            else
                Gizmos.color = Color.red;

            Gizmos.DrawRay(Physics.IsGroundPoint.position, Vector3.down * _config.JumpHeight);

            Gizmos.color = Color.green;
            Gizmos.DrawSphere(Physics.IsGroundPoint.position, _config.Radius);
        }
    }
#endif
}