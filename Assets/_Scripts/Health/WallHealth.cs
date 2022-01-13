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
    }
    #endregion

    #region Methods
    protected override void HurtReaction()
    {
        base.HurtReaction();
        Debug.Log("Wall hitted");

        //tira vida da ui
        //faz som de batida num muro
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
