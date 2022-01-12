using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageCollectorInteractable : Interactable
{
    #region Variables
    [SerializeField] private TrashType _collectorType;
    #endregion

    #region Unity Methods
    #endregion

    #region Methods
    public override void Interact()
    {
        if(CollectorManager.Instance._currentTrashCarrying != null)
        {
            if(CollectorManager.Instance._currentTrashCarrying.trashType == _collectorType)
            {
                CannonManager.Instance.ReloadCannon(CollectorManager.Instance._currentTrashCarrying);
                CollectorManager.Instance.DisposeTrash();
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
