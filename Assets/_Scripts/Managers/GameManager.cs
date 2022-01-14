using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonBase<GameManager>
{
    #region Variables
    [SerializeField]private int _currentPhase;
    public bool gameIsOver { get; private set; }
    #endregion

    #region Events
    public event Action OnGameOver;

    public void GameOver()
    {
        gameIsOver = true;
        OnGameOver?.Invoke();
    }
    #endregion

    #region Unity Methods
    protected override void Awake()
    {
        base.Awake();
        gameIsOver = false;
    }
    #endregion

    #region Methods
    public int GetCurrentPhase()
    {
        return _currentPhase;
    }

    public void StartPhase()
    {

    }

    public void RestartPhase()
    {
        ScenesManager.Instance.RestartCurrentPhase();
    }

    #endregion
}
