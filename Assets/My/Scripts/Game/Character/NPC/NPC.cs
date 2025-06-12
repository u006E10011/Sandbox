using System.Collections.Generic;
using UnityEngine;

using static N19.Constant;

namespace Project
{
    public class NPC : MonoBehaviour
    {
        [SerializeField, Space(10)] private Animator _animator;
        [SerializeField, Space(10)] private Health _health;
        [SerializeField] private List<Rigidbody> _rb;

        private void OnEnable()
        {
            _animator.enabled = true;

            _health.OnDied += Dead;
        }
        private void OnDisable()
        {
            ActivateKinematic();

            _health.OnDied -= Dead;
        }

        private void Dead()
        {
            DeactivateKinematic();

            _animator.enabled = false;
        }

        public void SetIdle()
        {
            _animator.SetBool(IDLE_ANIMATION, true);
        }
        public void SetWalk()
        {
            _animator.SetBool(IDLE_ANIMATION, false);
        }

        #region Rigidbody
        [ContextMenu(nameof(DeactivateKinematic))]
        private void DeactivateKinematic()
        {
            foreach (var rb in _rb)
                rb.isKinematic = false;
        }

        [ContextMenu(nameof(ActivateKinematic))]
        private void ActivateKinematic()
        {
            foreach (var rb in _rb)
                rb.isKinematic = true;
        }

        [ContextMenu(nameof(GetRigidbody))]
        private void GetRigidbody() => GetRigidbodyParent(transform);

        private void GetRigidbodyParent(Transform parent)
        {
            for (int i = 0; i < parent.childCount; i++)
            {
                if (parent.childCount <= 0)
                    continue;

                var isRb = parent.GetChild(i).TryGetComponent(out Rigidbody rb);

                if (isRb)
                    _rb.Add(rb);

                GetRigidbodyParent(parent.GetChild(i));
            }
        }
        #endregion
    }
}