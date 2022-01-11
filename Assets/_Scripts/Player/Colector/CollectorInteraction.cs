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
        RaycastHit[] interaction = Physics.BoxCastAll(transform.position + _interactionBoxOffset, _interactionBoxSize, transform.forward);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position + _interactionBoxOffset, _interactionBoxSize);
    }
    #endregion
}
