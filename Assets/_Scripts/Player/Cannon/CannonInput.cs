using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonInput : MonoBehaviour
{
    #region Variables
    [Header("Joystick reference")]
    [SerializeField] private FixedJoystick _joyStick;

    [Header("Cannon References")]
    [SerializeField] private CannonMovement _cannonMovement;

    private float _cannonMoveInput;
    private float _cannonLastMoveInput;

    #endregion

    #region Unity Methods
    private void Awake()
    {
        _joyStick = UIManager.Instance._moveCannonJoystick;
        _cannonMovement = GetComponent<CannonMovement>();
    }
    private void Update()
    {
        GetCannonMovement();
    }
    #endregion

    #region Methods
    private void GetCannonMovement()
    {
        _cannonMoveInput = _joyStick.Horizontal;
        if(_cannonMoveInput != _cannonLastMoveInput)
        {
            _cannonMovement.SetMoveInput(_cannonMoveInput);
            _cannonLastMoveInput = _cannonMoveInput;
        }
    }
    #endregion

}
