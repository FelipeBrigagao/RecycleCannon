using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashDropEffect : MonoBehaviour
{
    #region Variables
    [Header("Enemy references")]
    [SerializeField] private SO_Enemy _enemyStats;
    [SerializeField] private EnemyHealth _enemyHealth;

    private GameObject drop;
    #endregion

    #region Unity Methods
    private void OnEnable()
    {
        _enemyHealth.OnEnemyDeath += EnemyDied;
    }
    private void OnDisable()
    {
        _enemyHealth.OnEnemyDeath -= EnemyDied;
    }
    private void Start()
    {
        _enemyHealth = GetComponent<EnemyHealth>();
        StartCoroutine(WalkingTrashDrop());
    }
    #endregion

    #region Methods
    IEnumerator WalkingTrashDrop()
    {
        float possibility = Random.Range(0, 100);

        while (true)
        {
            yield return new WaitForSeconds(_enemyStats.dropTime);

            if (possibility <= _enemyStats.largeDropPossibility)
            {
                drop = _enemyStats.largeTrashDrop.interactablePrefab;
            }
            else
            {
                drop = _enemyStats.smallTrashDrop.interactablePrefab;
            }

            DropTrash();
        }
    }

    private void EnemyDied()
    {
        StopAllCoroutines();
        drop = _enemyStats.largeTrashDrop.interactablePrefab;

        for(int i = 0; i < _enemyStats.deathDropAmount; i++)
            DropTrash();

    }

    private void DropTrash()
    {
        Instantiate(drop, this.transform.position, Quaternion.identity);
    }


    #endregion



}
