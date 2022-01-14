using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScreenHelper : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverScreen;

    private void Awake()
    {
        SetGameOverScreenUI();
    }

    private void SetGameOverScreenUI()
    {
        UIManager.Instance.SetGameOverScreen(_gameOverScreen);
    }
}
