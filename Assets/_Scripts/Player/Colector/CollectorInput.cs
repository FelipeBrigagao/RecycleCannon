using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectorInput : MonoBehaviour
{
    #region Variables
    [Header("Joystick reference")]
    [SerializeField] private FixedJoystick _joyStick;

    [Header("Player references")]
    [SerializeField] private CollectorMovementBase _movement; 
    private Vector3 _moveInput;
    private Vector3 _latestMoveInput;


    #endregion

    #region Unity Methods
    private void Awake()
    {
        _movement = GetComponent<CollectorMovementBase>();
    }
    private void Update()
    {
        GetMoveInput();
    }

    #endregion

    #region Methods
    
    private void GetMoveInput()
    {
        _moveInput = new Vector3(_joyStick.Horizontal, 0, _joyStick.Vertical);
        if(_moveInput != _latestMoveInput)
        {
            _movement.SetMoveInput(_moveInput);
            _latestMoveInput = _moveInput;
        }
    }
    
    public void SetJoystick(FixedJoystick joystick)
    {
        _joyStick = joystick;
    }
    #endregion

}
