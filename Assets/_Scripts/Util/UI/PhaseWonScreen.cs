using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseWonScreen : MonoBehaviour
{
    public void NextPhase()
    {
        GameManager.Instance.NextPhase();
    }

    public void ReturnToMenu()
    {
        Debug.Log("Returning to menu.");
    }
}
