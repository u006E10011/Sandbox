using UnityEngine;

namespace Project
{
    [CreateAssetMenu(fileName = nameof(GrenadeConfig), menuName = "Config/Throwable/GrenadeConfig")]
    public class GrenadeConfig : ThrowableConfig
    {
        [Space(10)] public ExplosionData Data;
    }
}