using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallHealth : HealthBase
{
    #region Variables
    #endregion

    #region Unity Methods
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

    protected override void Die()
    {
        Debug.Log("Wall breaked");
        GameManager.Instance.GameOver();
        base.Die();
        //quebra o muro
    }
    #endregion
}
