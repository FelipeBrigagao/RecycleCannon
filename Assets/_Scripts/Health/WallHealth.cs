using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallHealth : HealthBase
{
    #region Variables
    [SerializeField] private int _waveHeal;
    #endregion

    #region Unity Methods
    private void OnEnable()
    {
        WaveManager.Instance.OnWaveEnd += WallWaveHeal;
    }
    private void OnDisable()
    {
        WaveManager.Instance.OnWaveEnd -= WallWaveHeal;
    }

    protected override void Start()
    {
        base.Start();
        UIManager.Instance.SetWallMaxHealth(_maxHealth);
    }
    #endregion

    #region Methods
    protected override void HurtReaction()
    {
        base.HurtReaction();
        UIManager.Instance.SetWallCurrentHealth(_currentHealth);
        //faz som de batida num muro
    }

    public override void Heal(int healingTaken)
    {
        base.Heal(healingTaken);
        UIManager.Instance.SetWallCurrentHealth(_currentHealth);
    }

    private void WallWaveHeal()
    {
        Heal(_waveHeal);
    }

    protected override void Die()
    {
        Debug.Log("Wall breaked");
        GameManager.Instance.GameOver();
        base.Die();
        //quebra o muro
    }
    #endregion
}
