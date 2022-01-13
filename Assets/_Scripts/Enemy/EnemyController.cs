using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    #region Variables
    [Header("Enemy references")]
    [SerializeField] private SO_Enemy _enemyStats;
    [SerializeField] private GameObject _destination;
    [SerializeField] private EnemyHealth _enemyHealth;
    [Header("Enemy attack references")]
    [SerializeField] private GameObject _currentCollector;
    [SerializeField] private Transform _wallAttackPoint;
    [SerializeField] private string _collectorTag;
    [SerializeField] private LayerMask _playerLayer;
    [SerializeField] private Transform _eatPoint;
    [SerializeField] private Transform _spitPoint;

    private NavMeshAgent _enemyAgent;

    private bool _canMove;

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
    private void Start()
    {
        _canMove = true;
        WallManager.Instance.GetWallAttackPoint();
        _destination = _wallAttackPoint.gameObject;
        _currentCollector = CollectorManager.Instance._currentCollector;
        _enemyAgent = GetComponent<NavMeshAgent>();
        _enemyAgent.speed = _enemyStats.speed;
        _enemyAgent.stoppingDistance = _enemyStats.stopDistance;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(_collectorTag))
        {
            _destination = _currentCollector;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(_collectorTag))
        {
            _destination = _wallAttackPoint.gameObject;
        }
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
    private void MoveToTarget()
    {
        if(_destination != null)
        {
            _enemyAgent.SetDestination(_destination.transform.position);
        }
    }

    private void CheckAttack()
    {
        if (Physics.CheckSphere(transform.position, _enemyStats.attackRange, _playerLayer) && !CollectorManager.Instance.collectorIsInvulnerable)
        {
            CollectorHealth collectorHealth = _currentCollector.GetComponent<CollectorHealth>();

            if (collectorHealth)
            {
                StartCoroutine(EatAndSpitCollector(collectorHealth));
            }
        }
    }

    private void StopEnemy()
    {
        _canMove = false;
        _enemyAgent.isStopped = true;

    }

    IEnumerator EatAndSpitCollector(CollectorHealth colectorHealth)
    {
        _canMove = false;
        _enemyAgent.velocity = Vector3.zero;
        _currentCollector.GetComponent<CollectorMovementBase>().CollectorBeingAttacked(_enemyStats.attackDuration);
        _currentCollector.transform.position = _eatPoint.position;
        colectorHealth.TakeDamage(_enemyStats.damage);
        yield return new WaitForSeconds(_enemyStats.attackDuration);
        if (!CollectorManager.Instance.isDead)
        {
            _currentCollector.transform.position = _spitPoint.position;
            _canMove = true;
        }

    }


    #endregion
}
