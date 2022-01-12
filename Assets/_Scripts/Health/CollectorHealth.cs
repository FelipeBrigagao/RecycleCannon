using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectorHealth : HealthBase
{
    #region Variables
    [Header("Collector references")]
    [SerializeField] private SO_CollectorStats _collectorStats;
    [SerializeField] private CollectorHeartsUI _heartsUI;
    public bool _isInvulnerable { get; private set; }
    #endregion

    #region Unity Methods
    protected override void Start()
    {
        _maxHealth = _collectorStats.maxHealth;
        base.Start();
        _heartsUI.SetCollectorHearts(_currentHealth);
    }
    #endregion

    #region Methods
    protected override void HurtReaction()
    {
        base.HurtReaction();
        _heartsUI.UpdateHealthUI(_currentHealth);

    }
    public override void Heal(int healingTaken)
    {
        base.Heal(healingTaken);
        _heartsUI.UpdateHealthUI(_currentHealth);
    }

    protected override void Die()
    {
        base.Die();
        CollectorManager.Instance.CollectorDied();
    }
    #endregion
}
