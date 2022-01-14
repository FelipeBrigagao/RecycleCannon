using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonBase<GameManager>
{
    #region Variables
    [SerializeField]private int _currentPhase;
    public bool gameIsOver { get; private set; }
    public bool phaseWon { get; private set; }
    #endregion

    #region Events
    public event Action OnGameOver;

    public void GameOver()
    {
        gameIsOver = true;
        OnGameOver?.Invoke();
    }

    public event Action OnPhaseWon;

    public void PhaseWon()
    {
        Debug.Log("Phase won!!!");
        phaseWon = true;
        OnPhaseWon?.Invoke();
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
        phaseWon = false;
        CollectorManager.Instance.InitiateCollector();
        CannonManager.Instance.InitiateCannon();
        WaveManager.Instance.InitiateWaves();
    }

    public void RestartPhase()
    {
        ScenesManager.Instance.RestartCurrentPhase();
    }

    public void NextPhase()
    {
        ScenesManager.Instance.LoadNextPhase();
    }

    #endregion
}
