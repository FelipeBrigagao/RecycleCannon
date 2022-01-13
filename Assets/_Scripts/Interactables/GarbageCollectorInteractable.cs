using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageCollectorInteractable : Interactable
{
    #region Variables
    [SerializeField] private TrashType _collectorType;
    [SerializeField] private CollectorCarrying _carrying;
    #endregion

    #region Unity Methods
    private void Awake()
    {
        _carrying = CollectorManager.Instance._currentCollector.GetComponent<CollectorCarrying>();
    }
    #endregion

    #region Methods
    public override void Interact()
    {
        if(_carrying._currentTrashCarrying != null)
        {
            if(_carrying._currentTrashCarrying.trashType == _collectorType)
            {
                CannonShoot cannonShoot = CannonManager.Instance._currentCannon.GetComponent<CannonShoot>();
                cannonShoot?.ReloadCannon(_carrying._currentTrashCarrying.ammo);
                _carrying.DisposeTrash();
            }
            else
            {
                Debug.Log("Wrong collector");
                //pisca o interact vermelho e faz um barulho de negativo
            }
        }
    }
    #endregion
}
