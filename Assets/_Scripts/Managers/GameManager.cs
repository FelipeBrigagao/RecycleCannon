using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonBase<GameManager>
{
    #region Variables
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
    #endregion
}
