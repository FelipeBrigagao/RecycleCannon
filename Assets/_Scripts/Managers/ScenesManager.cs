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

    public void LoadNextPhase()
    {
        Scene _nextScene;

        _nextScene = SceneManager.GetSceneByBuildIndex(GameManager.Instance.GetCurrentPhase() + 1);

        if (_nextScene != null)
            SceneManager.LoadScene(GameManager.Instance.GetCurrentPhase() + 1);
        else
            Debug.Log("No more phases after this.");
    }
    #endregion
}
