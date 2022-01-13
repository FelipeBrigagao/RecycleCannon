using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectorHealth : HealthBase
{
    #region Variables
    [Header("Collector references")]
    [SerializeField] private SO_CollectorStats _collectorStats;

    #endregion

    #region Unity Methods
    protected override void Start()
    {
        _maxHealth = _collectorStats.maxHealth;
        base.Start();
        UIManager.Instance.SetCollectorInitialHealthUI(_maxHealth);
    }
    #endregion

    #region Methods
    protected override void HurtReaction()
    {
        base.HurtReaction();
        UIManager.Instance.UpdateCollectorHealthUI(_currentHealth);

    }
    public override void Heal(int healingTaken)
    {
        base.Heal(healingTaken);
        UIManager.Instance.UpdateCollectorHealthUI(_currentHealth);
    }

    protected override void Die()
    {
        CollectorManager.Instance.CollectorDied();
        base.Die();
    }



    #endregion
}
