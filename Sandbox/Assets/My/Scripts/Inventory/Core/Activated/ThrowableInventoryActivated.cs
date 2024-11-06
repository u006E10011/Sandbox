using N19;
using UnityEngine;

namespace Project
{
    public class ThrowableInventoryActivated : ItemInventoryCreated, IItemInventoryActivated
    {
        [SerializeField] private Vector3 _offset;

        private bool _isReadyToThrow = true;

        private ThrowableConfig _config;
        private Transform _attackPoint;
        private GameObject _item;
        private GameObjectPool _objectPool;

        private void OnEnable() => PlayerInput.OnShoot += Throw;
        private void OnDisable() => PlayerInput.OnShoot -= Throw;

        public override void Init(Transform position)
        {
            base.Init(_attackPoint);
        }

        public void SetData(ThrowableConfig config)
        {
            _config = config;
            _isReadyToThrow = true;
        }

        public IItemInventory Get()
        {
            gameObject.Activate();

            return this;
        }

        public override void Return()
        {
            gameObject.Deactivate();
        }

        private void Throw()
        {
            if (_isReadyToThrow && gameObject.activeSelf)
            {
                _isReadyToThrow = false;

                _item = ObjectPool.Get();
                _item.transform.position = _attackPoint.position + _offset;

                var projectile = _item.GetComponent<Rigidbody>();
                var force = _attackPoint.transform.forward * _config.ThrowForce + Vector3.up * _config.ThrowUpForce;

                projectile.AddForce(force, ForceMode.Impulse);

                Invoke(nameof(Reload), _config.ThrowCooldown);

            }
        }

      //  private void Explorer(Throwable item) => item

        private void Reload() => _isReadyToThrow = true;
    }
}