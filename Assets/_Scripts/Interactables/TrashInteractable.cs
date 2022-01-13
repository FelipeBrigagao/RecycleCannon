using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashInteractable : Interactable
{
    #region Variables
    [SerializeField] private SO_Trash trashInfo;
    #endregion

    #region Unity Methods
    #endregion

    #region Methods
    public override void Interact()
    {
        CollectorCarrying collectorCarrying = CollectorManager.Instance._currentCollector.GetComponent<CollectorCarrying>();
        collectorCarrying?.SetCarryingTrash(trashInfo);
        Destroy(gameObject);
    }
    #endregion
}


