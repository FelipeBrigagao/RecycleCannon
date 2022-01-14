using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectorCarrying : MonoBehaviour
{
    #region Variables
    [Header("Carrying references")]
    [SerializeField] private Transform _carryingPoint;
    [SerializeField] private Transform _dropingPoint;
    public SO_Trash _currentTrashCarrying { get; private set; }

    private GameObject _trashCarryingUI;
    #endregion

    #region Unity Methods
    #endregion

    #region Methods
    private void StartCarrying()
    {
        _trashCarryingUI = Instantiate(_currentTrashCarrying.carryingPrefab, _carryingPoint.position, Quaternion.LookRotation(transform.forward), _carryingPoint);
    }

    private void StopCarrying()
    {
        if (_trashCarryingUI != null)
            Destroy(_trashCarryingUI.gameObject);
    }

    private void DropTrash()
    {
        StopCarrying();
        Instantiate(_currentTrashCarrying.interactablePrefab, _dropingPoint.position, Quaternion.identity);
    }

    public void SetCarryingTrash(SO_Trash trash)
    {
        if (_currentTrashCarrying == null)
        {
            _currentTrashCarrying = trash;
            StartCarrying();

        }
        else
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

    #endregion
}
