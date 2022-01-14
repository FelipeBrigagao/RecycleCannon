using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : SingletonBase<UIManager>
{
    #region Variables
    public FixedJoystick _moveCollectorJoystick { get; private set; }
    public FixedJoystick _moveCannonJoystick { get; private set; }

    private CollectorHeartsUI _collectorHeartsUI;
    private HealthBar _wallHealthBar;
    private IconUI _ammoUI;

    private GameObject _gameOverScreen;

    #endregion

    #region Unity Methods
    private void OnEnable()
    {
        GameManager.Instance.OnGameOver += GameIsOver;
    }

    private void OnDisable()
    {
        GameManager.Instance.OnGameOver -= GameIsOver;
    }
    #endregion

    #region Methods
    public void SetCollectorHearts(CollectorHeartsUI collectorHearts)
    {
        _collectorHeartsUI = collectorHearts;
    }
    public void SetCollectorInitialHealthUI(int initialHealth)
    {
        _collectorHeartsUI.SetCollectorHearts(initialHealth);
    }

    public void UpdateCollectorHealthUI(int currentHealth)
    {
        _collectorHeartsUI.UpdateHealthUI(currentHealth);
    }

    public void SetJoysticks(FixedJoystick collector, FixedJoystick cannon) 
    {
        _moveCollectorJoystick = collector;
        _moveCannonJoystick = cannon;
    }


    public void SetWallHealthBar(HealthBar wallBar)
    {
        _wallHealthBar = wallBar;
    }

    public void SetWallMaxHealth(int maxHealth)
    {
        _wallHealthBar.SetMaxHealth(maxHealth);
    }

    public void SetWallCurrentHealth(int maxHealth)
    {
        _wallHealthBar.SetCurrentHealth(maxHealth);
    }

    public void SetAmmoUI(IconUI ammoUI)
    {
        _ammoUI = ammoUI;
    }

    public void UpdateAmmoUI(Sprite icon, string description)
    {
        _ammoUI.UpdateIconUI(icon, description);
    }

    public void ClearAmmoUI()
    {
        _ammoUI.CleanIconUI();
    }

    public void UpdateDescription(string description)
    {
        _ammoUI.UpdateDescription(description);
    }

    public void SetGameOverScreen(GameObject gameOverScreen)
    {
        _gameOverScreen = gameOverScreen;
    }

    private void GameIsOver()
    {
        _moveCannonJoystick.gameObject.SetActive(false);
        _moveCollectorJoystick.gameObject.SetActive(false);
        _wallHealthBar.gameObject.SetActive(false);
        _collectorHeartsUI.gameObject.SetActive(false);
        _ammoUI.gameObject.SetActive(false);
        _gameOverScreen.SetActive(true);
    }

    #endregion
}
