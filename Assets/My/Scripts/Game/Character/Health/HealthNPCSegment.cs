using UnityEngine;

namespace Project
{
    public class HealthNPCSegment : MonoBehaviour, IDamageble
    {
        [SerializeField] private HealthNPC _healthBase;
        [SerializeField] private bool _head;

        public void Init(HealthNPC healh) => _healthBase = healh;

        public void ApplyDamage(float damage)
        {
            if (_head)
                _healthBase.ApplyDamage(_healthBase.Value);
            else
                _healthBase.ApplyDamage(damage);
        }
    }
}