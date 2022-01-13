using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyControllerBase : MonoBehaviour
{
    #region Variables
    [Header("Enemy references")]
    [SerializeField] protected SO_Enemy _enemyStats;
    [SerializeField] protected GameObject _destination;
    [SerializeField] protected EnemyHealth _enemyHealth;
    [Header("Enemy attack references")]
    [SerializeField] protected Transform _wallAttackPoint;
    [SerializeField] protected LayerMask _wallLayer;

    protected NavMeshAgent _enemyAgent;

    protected bool _canMove;

    #endregion

    #region Unity Methods
    private void OnEnable()
    {
        GameManager.Instance.OnGameOver += StopEnemy;
        _enemyHealth.OnEnemyDeath += StopEnemy;

    }

    private void OnDisable()
    {
        GameManager.Instance.OnGameOver -= StopEnemy;
        _enemyHealth.OnEnemyDeath -= StopEnemy;

    }
    protected virtual void Start()
    {
        _canMove = true;
        _destination = _wallAttackPoint.gameObject;
        _enemyHealth = GetComponent<EnemyHealth>();
        _enemyAgent = GetComponent<NavMeshAgent>();
        _enemyAgent.speed = _enemyStats.speed;
        _enemyAgent.stoppingDistance = _enemyStats.stopDistance;
    }

    
    private void FixedUpdate()
    {
        if (_canMove)
        {
            MoveToTarget();
            CheckAttack();
        }
    }
    #endregion

    #region Methods
    protected virtual void MoveToTarget()
    {
        if (_destination != null)
        {
            _enemyAgent.SetDestination(_destination.transform.position);
        }
    }

    protected virtual void CheckAttack()
    {
       
    }

    protected virtual void StopEnemy()
    {
        _canMove = false;
        _enemyAgent.isStopped = true;

    }

    #endregion
}
