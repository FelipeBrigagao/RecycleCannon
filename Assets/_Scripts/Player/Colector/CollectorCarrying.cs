using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectorCarrying : MonoBehaviour
{
    #region Variables
    [Header("Carrying references")]
    [SerializeField] private Transform _carryingPoint;
    [SerializeField] private Transform _dropingPoint;

    private GameObject _trash;

    private CollectorManager _collectorManager;
    #endregion

    #region Unity Methods
    private void Awake()
    {
        _collectorManager = CollectorManager.Instance;
    }


    private void OnEnable()
    {
        _collectorManager.OnStartCarrying += StartCarrying;
        _collectorManager.OnDropTrash += DropTrash;
        _collectorManager.OnStopCarrying += StopCarrying;
    }

    private void OnDisable()
    {
        _collectorManager.OnStartCarrying -= StartCarrying;
        _collectorManager.OnDropTrash -= DropTrash;
        _collectorManager.OnStopCarrying -= StopCarrying;
    }
    #endregion

    #region Methods
    private void StartCarrying()
    {
        _trash = Instantiate(_collectorManager._trash.carryingPrefab, _carryingPoint.position, Quaternion.identity, _carryingPoint);
    }

    private void StopCarrying()
    {
        if (_trash != null)
            Destroy(_trash.gameObject);
    }

    private void DropTrash()
    {
        StopCarrying();
        Instantiate(_collectorManager._trash.interactablePrefab, _dropingPoint.position, Quaternion.identity);
    }

    #endregion
}