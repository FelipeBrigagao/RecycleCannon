using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : SingletonBase<SpawnManager>
{
    #region Variables
    [Header("Collector Spawn references")]
    [SerializeField] private Transform _collectorSpawnPosition;


    [Header("Cannon Spawn references")]
    [SerializeField] private Transform _cannonSpawnPosition;
    #endregion

    #region UnityMethods
    #endregion

    #region Methods
    public void SetCollectorSpawnPosition(Transform collectorSpawn)
    {
        _collectorSpawnPosition = collectorSpawn;
    }

    public GameObject SpawnCollector(GameObject collectorPrefab)
    {
        GameObject collector = Instantiate(collectorPrefab, _collectorSpawnPosition.position, Quaternion.identity);
        return collector;
    }

    public void SetCannonSpawnPosition(Transform cannonSpawn)
    {
        _cannonSpawnPosition = cannonSpawn;
    }

    public GameObject SpawnCannon(GameObject cannonPrefab)
    {
        GameObject cannon = Instantiate(cannonPrefab, _cannonSpawnPosition.position, Quaternion.identity);
        return cannon;
    }

    public GameObject SpawnEnemy(GameObject enemyPrefab, Vector3 spawnPosition)
    {
        GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        return enemy;
    }

    #endregion
}
