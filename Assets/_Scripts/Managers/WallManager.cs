using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallManager : SingletonBase<WallManager>
{
    #region Variables
    public GameObject currentWall;
    private Wall _wall;
    #endregion

    #region Unity Methods
    protected override void Awake()
    {
        base.Awake();
        _wall = currentWall.GetComponent<Wall>();
    }
    #endregion

    #region Methods
    public Transform GetWallAttackPoint()
    {
        return _wall.GetRandomAttackPoint();
    }

    public Transform GetWallBossAttackPoint()
    {
        return _wall.GetBoosAttackPoint();
    }

    #endregion
}
