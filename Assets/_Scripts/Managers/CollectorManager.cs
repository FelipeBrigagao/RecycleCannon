using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectorManager : SingletonBase<CollectorManager>
{
    #region Variables
    public SO_Trash _currentTrashCarrying { get; private set;}
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

    public event Action OnStartCarrying;

    public void StartCarrying()
    {
        OnStartCarrying?.Invoke();
    }

    public event Action OnDropTrash;

    public void DropTrash()
    {
        OnDropTrash?.Invoke();
    }

    public event Action OnStopCarrying;

    public void StopCarrying()
    {
        OnStopCarrying?.Invoke();
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

    public void SetCurrentCollector(GameObject currentCollector)
    {
        _currentCollector = currentCollector;
    }

    public void SetCarryingTrash(SO_Trash trash)
    {
        if(_currentTrashCarrying == null)
        {
            _currentTrashCarrying = trash;
            StartCarrying();

        }else
        {
            DropTrash();
            _currentTrashCarrying = trash;
            StartCarrying();
        }
    }
    
    public void DisposeTrash()
    {
        StopCarrying();
        _currentTrashCarrying = null;
    }

    public void CollectorBeingAttacked(float attackDuration)
    {
        StartCoroutine(InvulnerabilityCountdown(attackDuration));
    }
    IEnumerator InvulnerabilityCountdown(float duration)
    {
        DisposeTrash();
        Rigidbody rb = _currentCollector.GetComponent<Rigidbody>();
        Collider collider = _currentCollector.GetComponent<Collider>();
        collider.isTrigger = true;
        rb.isKinematic = true;
        canMove = false;
        collectorIsInvulnerable = true;

        yield return new WaitForSeconds(duration);
        if (!CollectorManager.Instance.isDead)
        {
            collider.isTrigger = false;
            rb.isKinematic = false;
            canMove = true; 
            yield return new WaitForSeconds(duration);
            collectorIsInvulnerable = false;

        }

    }

    #endregion
}
