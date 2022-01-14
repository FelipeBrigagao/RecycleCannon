using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    #region Variables
    [SerializeField] private Transform _attackPointsHolder;
    private Transform[] _attackPoints;
    [SerializeField] private Transform _bossAttackPoint;
    #endregion

    #region Unity Methods
    private void Awake()
    {
        _attackPoints = new Transform[_attackPointsHolder.childCount];

        for(int  i= 0; i < _attackPointsHolder.childCount; i++)
        {
            _attackPoints[i] = _attackPointsHolder.GetChild(i);
        }
    }
    #endregion

    #region Methods
    public Transform GetRandomAttackPoint()
    {
        int index = Random.Range(0, _attackPoints.Length);

        return _attackPoints[index];
    }

    public Transform GetBoosAttackPoint()
    {
        return _bossAttackPoint;
    }

    #endregion
}
