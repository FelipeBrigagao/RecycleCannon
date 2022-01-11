using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonShoot : MonoBehaviour
{
    #region Variables
    [Header("Cannon references")]
    [SerializeField] private SO_CannonStats _cannonStats;
    [SerializeField] private Transform _shotPosition;
    private SO_Ammo _ammo;
    private int _shots;
    private float _nextShot = 0;
    #endregion

    #region Unity Methods
    private void OnEnable()
    {
        CannonManager.Instance.OnReload += ReloadCannon;
    }
    private void OnDisable()
    {
        CannonManager.Instance.OnReload -= ReloadCannon;
    }
    #endregion

    #region Methods
    public void Shoot()
    {
        if(_shots > 0 && Time.deltaTime >=_nextShot)
        {
            Instantiate(_ammo.bulletPrefab, _shotPosition.position, Quaternion.identity);
            _shots--;
            _nextShot = Time.deltaTime + _cannonStats.fireRate;
            //cada vez que atira atualiza o uimanager
        }
    }

    public void ReloadCannon(SO_Ammo ammo)
    {
        _ammo = ammo;
        _shots = ammo.ammoAmount;
    }
    #endregion
}
