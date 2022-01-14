using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickHelpers : MonoBehaviour
{
    [SerializeField] private FixedJoystick _collectorJoystick;
    [SerializeField] private FixedJoystick _cannonJoystick;

    private void Awake()
    {
        SetJoysticks();
    }

    private void SetJoysticks()
    {
        UIManager.Instance.SetJoysticks(_collectorJoystick, _cannonJoystick);
    }
}
