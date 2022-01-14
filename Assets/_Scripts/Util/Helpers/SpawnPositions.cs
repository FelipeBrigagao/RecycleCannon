using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPositions : MonoBehaviour
{
    [SerializeField] private Transform _collectorSpawnPosition;
    [SerializeField] private Transform _cannonSpawnPosition;
    [SerializeField] private Transform _enemiesSpawnHolder;

    private void Awake()
    {
        SpawnManager.Instance.SetCollectorSpawnPosition(_collectorSpawnPosition);
        SpawnManager.Instance.SetCannonSpawnPosition(_cannonSpawnPosition);
        WaveManager.Instance.SetSpawnsHolder(_enemiesSpawnHolder);
    }

}
