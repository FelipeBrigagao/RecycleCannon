using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScreen : MonoBehaviour
{
    public void RestartPhase()
    {
        GameManager.Instance.RestartPhase();
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Leaving game");
    }
}
