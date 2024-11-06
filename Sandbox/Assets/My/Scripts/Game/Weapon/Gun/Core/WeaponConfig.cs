using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "WeaponConfig", menuName = "Config/Weapon/WeaponConfig")]
public class WeaponConfig : ScriptableObject
{
    public string Name;

    [Header("Settings")]
    public float Damage = 15;
    public float DamageForce = 1;
    public int MagazineSize = 30;

    [Space(5)] public bool IsAutomatic = true;

    [Header("Reload")]
    public float ReloadTime = 1f;
    public float FireTime = 0.15f;

    [Header("Ray")]
    public LayerMask ShowLayer;
    public LayerMask DamagebleLayer;

    [Min(0)] public float Distance = Mathf.Infinity;
    [Min(1)] public int ShotCount = 1;

    [Header("Spread")]
    public bool UseSpread;
    [Min(0)] public float SpreadFactor = 1f;

    [Header("Recoil")]
    public float Snappiness;
    public float ReturnSpeed;
    [Space(10)] public Vector3 Recoil;

    [Header("Effect")]
    [Min(0)] public float LifeTime;
    public ParticleSystem HitEffect;
    public ParticleSystem OtherEffect;

    [Header("Sound")]
    public AudioClip AudioClip;

}