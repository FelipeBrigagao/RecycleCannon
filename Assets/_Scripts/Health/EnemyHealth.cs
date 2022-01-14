using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : HealthBase
{
    #region Variables
    [Header("Enemy references")]
    [SerializeField] private SO_Enemy _enemyStats;
    public TrashType _enemyTrashType { get; private set; }
    #endregion

    #region Events
    public event Action OnEnemyDeath;
    public void EnemyDied()
    {
        OnEnemyDeath?.Invoke();
    }
    #endregion

    #region Unity Methods
    protected override void Start()
    {
        _maxHealth = _enemyStats.maxHealth;
        base.Start();
        _enemyTrashType = _enemyStats.enemyTrashType;
    }
    #endregion

    #region Methods
    protected override void HurtReaction()
    {
        base.HurtReaction();
    }

    protected override void Die()
    {
        WaveManager.Instance.RemoveSpawnedEnemy(_mainGameObject);
        EnemyDied();
        base.Die();
    }

    #endregion
}
