using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectorManager : SingletonBase<CollectorManager>
{
    #region Variables
    [SerializeField] private GameObject _collectorPrefab;
    public GameObject _currentCollector { get; private set; }
    public bool collectorIsInvulnerable { get; private set;}
    public bool canMove { get; private set;}
    public bool isDead { get; private set;}
    #endregion

    #region Events
    public event Action OnCollectorDeath;

    public void CollectorDied()
    {
        canMove = false;
        isDead = true;
        GameManager.Instance.GameOver();
        OnCollectorDeath?.Invoke();
    }

    #endregion

    #region Unity Methods
    protected override void Awake()
    {
        base.Awake();
        canMove = true;
    }
    #endregion



    #region Methods

    public void SetCollectorPrefab(GameObject collector)
    {
        _collectorPrefab = collector;
    }

    public void InitiateCollector()
    {
        _currentCollector = SpawnManager.Instance.SpawnCollector(_collectorPrefab);
    }

   
    public void CollectorCanMove(bool canMove)
    {
        this.canMove = canMove;
    }

    public void CollectorInvulnerable(bool invulnerable)
    {
        collectorIsInvulnerable = invulnerable;
    }


    #endregion
}
