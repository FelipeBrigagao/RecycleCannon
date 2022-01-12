using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectorInteraction : MonoBehaviour
{
    #region Variables
    [Header("Interaction Values")]
    [SerializeField] private Vector3 _interactionBoxSize;
    [SerializeField] private Vector3 _interactionBoxOffset;
    #endregion

    #region Unity Methods
    #endregion

    #region Methods
    public void CheckInteraction()
    {
        if (CollectorManager.Instance.canMove && !GameManager.Instance.gameIsOver)
        {
            RaycastHit[] interactions = Physics.BoxCastAll(transform.position + _interactionBoxOffset, _interactionBoxSize / 2, transform.forward, Quaternion.identity, _interactionBoxSize.z);
        
            if(interactions.Length > 0)
            {
                Interactable interactable;

                foreach (RaycastHit hit in interactions)
                {
                    interactable = hit.transform.GetComponent<Interactable>();

                    if (interactable)
                    {
                        interactable.Interact();
                        return;
                    }
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position + _interactionBoxOffset, _interactionBoxSize);
    }
    #endregion
}
