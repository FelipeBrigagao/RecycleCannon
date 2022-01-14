using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonShoot : MonoBehaviour
{
    #region Variables
    [Header("Cannon references")]
    [SerializeField] private SO_CannonStats _cannonStats;
    [SerializeField] private Transform _shootPosition;
    [SerializeField] private SO_Ammo _ammo;
    [SerializeField]private int _shots;
    private float _nextShot = 0;
    #endregion

    #region Unity Methods
    #endregion

    #region Methods
    public void Shoot()
    {
        if (GameManager.Instance.gameIsOver)
            return;

        if(_shots > 0 && Time.time >=_nextShot)
        {
            Instantiate(_ammo.bulletPrefab, _shootPosition.position, Quaternion.LookRotation(transform.forward));
            _shots--;
            _nextShot = Time.time + _cannonStats.fireRate;
            UIManager.Instance.UpdateDescription(_shots.ToString());
        }
        else
        {
            Debug.Log($"Não atirou, \n nextShot:{_nextShot} \n time: {Time.time}");
        }

        if (_shots == 0)
            UIManager.Instance.ClearAmmoUI();
    }

    public void ReloadCannon(SO_Ammo ammo)
    {
        _ammo = ammo;
        _shots = ammo.ammoAmount;

        UIManager.Instance.UpdateAmmoUI(_ammo.ammoTypeIcon, _shots.ToString());
    }
    #endregion
}
