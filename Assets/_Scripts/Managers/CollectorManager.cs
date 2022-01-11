using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectorManager : SingletonBase<CollectorManager>
{
    #region Variables
    [Header("Collector reference")]
    [SerializeField] private GameObject _currentCollector;
    public SO_Trash _trash { get; private set;}

    #endregion

    #region Events
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
    #endregion

    #region Methods
    public void SetCarryingTrash(SO_Trash trash)
    {
        if(_trash == null)
        {
            _trash = trash;
            StartCarrying();

        }else
        {
            DropTrash();
            _trash = trash;
            StartCarrying();
        }
    }
    
    public void DisposeTrash()
    {
        StopCarrying();
        _trash = null;
    }

    #endregion
}
