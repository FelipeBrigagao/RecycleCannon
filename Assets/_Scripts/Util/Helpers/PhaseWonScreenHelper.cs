using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseWonScreenHelper : MonoBehaviour
{
    [SerializeField] private GameObject _phaseWonScreen;

    private void Awake()
    {
        SetPhaseWonScreenUI();
    }

    private void SetPhaseWonScreenUI()
    {
        UIManager.Instance.SetPhaseWonScreen(_phaseWonScreen);
    }
}
