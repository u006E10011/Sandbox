using N19;
using UnityEngine;
using Project.Inventory;

namespace Project
{
    public class ThrowableGrenade : MonoBehaviour, IInventoryItemActivated
    {
        [SerializeField] private InventoryItemCreater _itemCreater;
        [SerializeField] private GrenadeConfig _config;
        [SerializeField] private Transform _itemPosition;

        private bool _isReadyToThrow = true;
        private GameObject _item;

        private void OnEnable() => IInputPlayer.OnShot += Throw;
        private void OnDisable() => IInputPlayer.OnShot -= Throw;

        public void Throw()
        {
            if ((bool)EventBus.Instance.OnInventoryIsOpen?.Invoke())
                return;

            if (_isReadyToThrow)
            {
                _item.transform.parent = _itemCreater.transform;
                _isReadyToThrow = false;

                var projectile = _item.GetComponent<Rigidbody>();
                projectile.isKinematic = false;

                if (Grenade.GetValue(_item, out var grenade))
                    grenade.StartCoroutine(_item.GetComponent<IExplosion>().Explosion(_itemCreater.Pool, _config.Data.DelayToExplosion));

                var force = transform.forward * _config.ThrowForce + transform.up * _config.ThrowUpForce;
                projectile.AddForce(force, ForceMode.Impulse);

                Invoke(nameof(Reload), _config.ThrowCooldown);
            }
        }

        private void Reload()
        {
            _isReadyToThrow = true;
            _item = _itemCreater.Get(_itemPosition.position);
            _item.transform.parent = transform;
        }

        public IInventoryItem Get()
        {
            gameObject.Activate();

            if (_item == null)
            {
                _item = _itemCreater.Get(_itemPosition.position);
                _item.transform.parent = transform;
            }

            return this;
        }

        public void Return()
        {
            gameObject.Deactivate();
            _item.Deactivate();
            _item.transform.parent = _itemCreater.transform;
            _item = null;
        }
    }
}
