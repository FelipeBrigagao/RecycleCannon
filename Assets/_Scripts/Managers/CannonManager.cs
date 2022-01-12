using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonManager : SingletonBase<CannonManager>
{
    #region Variables
    #endregion

    #region Events
    public event Action<SO_Ammo> OnReload;

    public void Reload(SO_Ammo ammo)
    {
        OnReload?.Invoke(ammo);
    }
    #endregion

    #region Unity Methods
    #endregion

    #region Methods
    public void ReloadCannon(SO_Trash trash)
    {
        Reload(trash.ammo);
        //alterar as coisas do uimanager
    }

    #endregion
}
