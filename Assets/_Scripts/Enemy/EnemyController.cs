using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : EnemyControllerBase
{
    #region Variables
    [SerializeField] private GameObject _currentCollector;
    [SerializeField] private GameObject _currentWall;
    [SerializeField] private string _collectorTag;
    [SerializeField] private LayerMask _playerLayer;
    [SerializeField] private Transform _eatPoint;
    [SerializeField] private Transform _spitPoint;

    #endregion

    #region Unity Methods
    protected override void Start()
    {
        _wallAttackPoint = WallManager.Instance.GetWallAttackPoint();
        _currentCollector = CollectorManager.Instance._currentCollector;
        _currentWall = WallManager.Instance.currentWall;
        base.Start();
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

    #endregion

    #region Methods
    protected override void MoveToTarget()
    {
        base.MoveToTarget();
    }

    protected override void CheckAttack()
    {
        base.CheckAttack();

        if (Physics.CheckSphere(transform.position, _enemyStats.attackRange, _playerLayer) && !CollectorManager.Instance.collectorIsInvulnerable)
        {
            HealthBase health = _currentCollector.GetComponent<HealthBase>();

            if (health)
            {
                StartCoroutine(EatAndSpitCollector(health));
            }

        }else if (Physics.CheckSphere(transform.position, _enemyStats.attackRange, _wallLayer))
        {
            HealthBase health = _currentWall.GetComponent<HealthBase>();

            if (health)
            {
                health.TakeDamage(_enemyStats.damage);
            }
        }
    }

    protected override void StopEnemy()
    {
        base.StopEnemy();
    }

    IEnumerator EatAndSpitCollector(HealthBase health)
    {
        _canMove = false;
        _enemyAgent.velocity = Vector3.zero;
        _currentCollector.GetComponent<CollectorMovementBase>().CollectorBeingAttacked(_enemyStats.attackDuration);
        _currentCollector.transform.position = _eatPoint.position;
        health.TakeDamage(_enemyStats.damage);
        yield return new WaitForSeconds(_enemyStats.attackDuration);
        if (!CollectorManager.Instance.isDead)
        {
            _currentCollector.transform.position = _spitPoint.position;
            _canMove = true;
        }

    }


    #endregion
}
