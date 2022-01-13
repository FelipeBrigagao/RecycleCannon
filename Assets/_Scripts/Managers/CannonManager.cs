using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonManager : SingletonBase<CannonManager>
{
    #region Variables
    public GameObject _currentCannon { get; private set; }
    #endregion

    #region Events
    #endregion

    #region Unity Methods
    #endregion

    #region Methods
    public void SetCurrentCannon(GameObject currentCannon)
    {
        _currentCannon = currentCannon;
    }
    #endregion
}
