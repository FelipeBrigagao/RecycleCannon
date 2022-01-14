using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonShootButton : MonoBehaviour
{
    private CannonShoot _cannonShoot;

    private void Awake()
    {
        _cannonShoot = CannonManager.Instance._currentCannon.GetComponent<CannonShoot>();
    }

    public void ShootCannon()
    {
        _cannonShoot?.Shoot();
    }
}
