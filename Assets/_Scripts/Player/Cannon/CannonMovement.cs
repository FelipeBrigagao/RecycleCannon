using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonMovement : MonoBehaviour
{
    #region Variables
    [Header("Cannon references")]
    [SerializeField] private SO_CannonStats _cannonStats;

    private float _moveInput;
    #endregion

    #region Unity Methods
    private void FixedUpdate()
    {
        if (GameManager.Instance.gameIsOver)
            return;

        Move();
    }

    #endregion

    #region Methods
    private void Move()
    {
        transform.Rotate(Vector3.up * _moveInput * _cannonStats.turnSpeed * Time.deltaTime);
    }

    public void SetMoveInput(float input)
    {
        _moveInput = input;
    }
    #endregion
}
