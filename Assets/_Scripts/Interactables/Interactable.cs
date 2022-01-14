using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    #region Variables
    [Header("Interaction Icon Reference")]
    [SerializeField] protected GameObject _interactionIcon;
    [SerializeField] private string _interactionTag;

    #endregion

    #region Unity Methods
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(_interactionTag))
        {
            _interactionIcon.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(_interactionTag))
        {
            _interactionIcon.SetActive(false);
        }
    }
    #endregion

    #region Methods
    public abstract void Interact();
    #endregion


}
