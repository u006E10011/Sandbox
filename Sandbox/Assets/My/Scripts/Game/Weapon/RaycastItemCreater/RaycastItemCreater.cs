using UnityEngine;

using static Project.InputPC;

namespace Project
{
    public class RaycastItemCreater : MonoBehaviour
    {
        [SerializeField] private Transform _shotPoint;

        private RaycastHit _hitInfo;

        private Inventory _inventory;
        private RaycastItemCreaterConfig _config;

        private void OnEnable() => IInputPlayer.OnShot += Create;
        private void OnDisable() => IInputPlayer.OnShot -= Create;

        public void Init(Inventory inventory)
        {
            _inventory = inventory;
            _config = LoaderConfig.RaycastItemCreaterConfig;
        }

        private void Create()
        {
            if ((bool)EventBus.Instance.OnInventoryIsOpen?.Invoke())
                return;

            if (Raycast() && _inventory.GetItem() is IItemInventoryCreatedRaycast item)
            {
                item.Get(_hitInfo.point);

                SoundController.Instance.Play2D(_config.ShotSound, LoaderConfig.SoundConfig.Mixer.RaycastItemCreater);
            }
        }

        private bool Raycast()
        {
            var ray = new Ray(_shotPoint.position, transform.forward);
            var isHit = Physics.Raycast(ray, out _hitInfo, _config.Distance.Max, _config.Layer);

            if (isHit && _config.Distance.Min < Vector3.Distance(_shotPoint.position, _hitInfo.point))
                return true;

            return false;
        }

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            if (!Application.isPlaying)
                return;

            var ray = new Ray(_shotPoint.position, _shotPoint.forward);
            Physics.Raycast(ray, out RaycastHit hitInfo, _config.Distance.Max, _config.Layer);

            if (_config.Distance.Min < Vector3.Distance(_shotPoint.position, hitInfo.point))
            {
                N19.Draw.DrawRay(ray, hitInfo.point, _config.Distance.Max, Color.blue, Color.yellow);
                N19.Draw.DrawRay(ray, _config.Distance.Min, Color.yellow);
            }
            else
                N19.Draw.DrawRay(ray, hitInfo.point, _config.Distance.Max, Color.cyan, Color.cyan);
        }
#endif
    }
}