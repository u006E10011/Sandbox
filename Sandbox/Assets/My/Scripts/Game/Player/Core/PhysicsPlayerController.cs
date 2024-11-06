using UnityEngine;

namespace Project
{
    [System.Serializable]
    public class PhysicsPlayerController
    {
        public float Inertia;
        public bool IsGround { get; private set; }
        public Vector3 Velocity;

        private PlayerConfig _config;

        [Space(10)] public Transform IsGroundPoint;

        public void Init(PlayerConfig config) => _config = config;

        public void MathVelocity()
        {
            CheckGround();

            if (IsGround && Velocity.y < 0)
                Velocity.y = _config.Gravity;

            Velocity.y += Time.deltaTime * _config.Gravity;

            if (IsGround)
                Velocity.y = 0;
        }

        public void MathInertia()
        {
            if (IsGround && (PlayerInput.Instance.Direction.x != 0 || PlayerInput.Instance.Direction.y != 0))
                Inertia += _config.InertiaMultiplier * Time.deltaTime;
            else
                Inertia -= _config.InertiaPeduction * Time.deltaTime;

            Inertia = Mathf.Clamp(Inertia, 0, _config.MaxInertia);
        }

        public bool CheckIsFlying()
        {
            return !Physics.Raycast(IsGroundPoint.position, Vector3.down * _config.JumpHeight, 8);
        }

        private void CheckGround()
        {
            //IsGround = Physics.CheckCapsule(IsGroundPoint.position, Vector3.down * _config.JumpHeight / 2, _config.Radius, _config.Ground);
            IsGround = Physics.CheckSphere(IsGroundPoint.position, _config.Radius, _config.Ground);
        }
    }
}