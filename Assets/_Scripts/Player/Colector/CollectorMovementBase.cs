using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectorMovementBase : MonoBehaviour
{
    #region Variables
    [Header("Collector references")]
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Collider _collider;
    [SerializeField] private SO_CollectorStats _collectorStats;

    [Header("Movement References")]
    [SerializeField] private Transform _camera;
    private Vector3 _moveInput;
    private Vector3 _direction;
    private Vector3 _moveAmount;

    #endregion

    #region Unity Methods
    private void Start()
    {
        _camera = Camera.main.transform;
        _rigidbody = GetComponent<Rigidbody>();
        _collider = GetComponent<Collider>();
    }

    private void FixedUpdate()
    {
        if(CollectorManager.Instance.canMove && !GameManager.Instance.gameIsOver)
            Move();
    }
    #endregion

    #region Methods

    private void Move()
    {
        _rigidbody.MovePosition(transform.position + _moveAmount);

        if(_moveInput.magnitude >= 0.001)
        {
            Rotate();
        }

    }

    public void SetMoveInput(Vector3 moveInput)
    {
        _moveInput = moveInput;
        _direction = Quaternion.Euler(0f, _camera.transform.eulerAngles.y, 0f) * moveInput.normalized;
        _moveAmount = _direction * _collectorStats.speed * Time.fixedDeltaTime;
    }

    private void Rotate()
    {
        Quaternion smoothedRotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(_direction, Vector3.up), _collectorStats.turnDamp * Time.deltaTime);
        _rigidbody.MoveRotation(smoothedRotation);

    }

    public void CollectorBeingAttacked(float attackDuration)
    {
        StartCoroutine(InvulnerabilityCountdown(attackDuration));
    }

    IEnumerator InvulnerabilityCountdown(float duration)
    {
        _collider.isTrigger = true;
        _rigidbody.isKinematic = true;
        GetComponent<CollectorCarrying>().DisposeTrash();
        CollectorManager.Instance.CollectorCanMove(false);
        CollectorManager.Instance.CollectorInvulnerable(true);

        yield return new WaitForSeconds(duration);
        if (!CollectorManager.Instance.isDead)
        {
            _collider.isTrigger = false;
            _rigidbody.isKinematic = false;
            CollectorManager.Instance.CollectorCanMove(true);
            yield return new WaitForSeconds(duration);
            CollectorManager.Instance.CollectorInvulnerable(false);

        }

    }

    #endregion
}
