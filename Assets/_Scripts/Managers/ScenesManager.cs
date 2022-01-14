using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : SingletonBase<ScenesManager>
{
    #region Variables
    #endregion

    #region Unity Methods
    #endregion

    #region Methods
    public void RestartCurrentPhase()
    {
        SceneManager.LoadScene(GameManager.Instance.GetCurrentPhase());
    }
    #endregion
}
