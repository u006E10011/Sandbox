using Project;
using UnityEngine;

public class Throwable : MonoBehaviour, IItemInventoryCreated
{
    private bool _isreadyToThrow = true;

    private ThrowableConfig _config;
    private Transform _attackPoint;

    private void OnEnable()
    {
        PlayerInput.OnShoot += Throw;
    }

    private void OnDisable()
    {
        PlayerInput.OnShoot -= Throw;
    }

    public void SetData(ThrowableConfig config)
    {
        _config = config;
    }

    private void Throw()
    {
        if (_isreadyToThrow)
        {
            _isreadyToThrow = false;


        }
    }

    public IItemInventory Get(Vector3 position)
    {
        throw new System.NotImplementedException();
    }

    public void Return()
    {
        throw new System.NotImplementedException();
    }
}
