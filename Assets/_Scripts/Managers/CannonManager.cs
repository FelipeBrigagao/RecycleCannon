using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonManager : SingletonBase<CannonManager>
{
    #region Variables
    [SerializeField] private GameObject _cannonPrefab;
    public GameObject _currentCannon { get; private set; }
    #endregion

    #region Events
    #endregion

    #region Unity Methods
    #endregion

    #region Methods
    public void SetCannonPrefab(GameObject cannonPrefab)
    {
        _cannonPrefab = cannonPrefab;
    }

    public void InitiateCannon()
    {
        _currentCannon = SpawnManager.Instance.SpawnCannon(_cannonPrefab);
    }
    #endregion
}
