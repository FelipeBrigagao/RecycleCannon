using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : SingletonBase<UIManager>
{
    #region Variables
    public FixedJoystick _moveCollectorJoystick { get; private set; }
    public FixedJoystick _moveCannonJoystick { get; private set; }
    private CollectorHeartsUI _collectorHeartsUI;
    #endregion

    #region Unity Methods
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

    #endregion
}
