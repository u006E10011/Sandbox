using UnityEngine;

namespace Project
{
    public class TrailController : MonoBehaviour
    {
        [SerializeField] private TrailRenderer _trail;
        [SerializeField] private Damager _damager;
        [SerializeField] private Transform _point;
        [SerializeField] private Vector3 _offset;

        private void OnEnable() => _damager.OnShootEvent += Fire;
        private void OnDisable() => _damager.OnShootEvent -= Fire;

        private void Fire()
        {
            Instantiate(_trail, _point.position, Quaternion.Euler(transform.forward + _offset));
        }
    }
}