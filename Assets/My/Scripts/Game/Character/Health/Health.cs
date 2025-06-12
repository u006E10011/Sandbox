using Project;
using System;
using UnityEngine;

public abstract class Health : MonoBehaviour, IDamageble
{
    public event Action OnDied;

    [SerializeField] private float _maxHealth;
    [SerializeField] private AudioClip _died;

    public float Value { get; private set; }
    public bool IsDead { get; private set; }

    private void OnEnable()
    {
        Value = _maxHealth;
        IsDead = false;
    }

    public void ApplyDamage(float damage)
    {
        Value = Mathf.Clamp(Value - Mathf.Abs(damage), 0, _maxHealth);

        if (Value <= 0 && !IsDead)
        {
            IsDead = true;
            SoundController.Instance.Play3D(_died, LoaderConfig.SoundConfig.Mixer.Dead, transform.position);
            Died();

            OnDied?.Invoke();
        }
    }

    public virtual void Died() { }
}
