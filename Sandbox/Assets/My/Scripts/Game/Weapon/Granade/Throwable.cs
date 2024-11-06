using Project;
using UnityEngine;

public class Throwable : MonoBehaviour
{
    [SerializeField] private ThrowableConfig _config;

    private ThrowableInventoryActivated _throwableMain;

    private void OnEnable()
    {
        _throwableMain = GetComponentInParent<ThrowableInventoryActivated>();
        Debug.Log("Throwable");
        _throwableMain.SetData(_config);
    }
}
