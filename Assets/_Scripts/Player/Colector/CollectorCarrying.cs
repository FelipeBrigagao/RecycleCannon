using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectorCarrying : MonoBehaviour
{
    #region Variables
    [Header("Carrying references")]
    [SerializeField] private Transform _carryingPoint;
    [SerializeField] private Transform _dropingPoint;

    private GameObject _trashCarryingUI;

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
        _trashCarryingUI = Instantiate(_collectorManager._currentTrashCarrying.carryingPrefab, _carryingPoint.position, Quaternion.LookRotation(transform.forward), _carryingPoint);
    }

    private void StopCarrying()
    {
        if (_trashCarryingUI != null)
            Destroy(_trashCarryingUI.gameObject);
    }

    private void DropTrash()
    {
        StopCarrying();
        Instantiate(_collectorManager._currentTrashCarrying.interactablePrefab, _dropingPoint.position, Quaternion.identity);
    }

    #endregion
}
