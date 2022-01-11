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
        CollectorManager.Instance.SetCarryingTrash(trashInfo);
        Destroy(gameObject);
    }
    #endregion
}


