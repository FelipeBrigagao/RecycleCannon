using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : SingletonBase<WaveManager>
{
    #region Variables
    [Header("Waves controller values")]
    [SerializeField] private Wave[] _waves;
    [SerializeField] private float _timeBetweenWaves;
    [SerializeField] private int _startingWave;
    [SerializeField] private int _currentWave;

    [SerializeField] private WavesStates _currentState;

    [Header("Enemy spawn reference")]
    [SerializeField] private Transform _spawnsHolder;
    private Vector3[] _spawnsPosition;
    private float _countdownSpawnWave;

    [SerializeField] private List<GameObject> _enemiesSpawned;


    #endregion

    #region Events
    public event Action OnWaveEnd;

    public void WaveEnded()
    {
        OnWaveEnd?.Invoke();
    }
    #endregion

    #region Unity Methods
    private void OnEnable()
    {
        GameManager.Instance.OnGameOver += StopSpawning;
        GameManager.Instance.OnPhaseWon += StopSpawning;
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnGameOver -= StopSpawning;
        GameManager.Instance.OnPhaseWon -= StopSpawning;
    }

    private void Update()
    {

        switch (_currentState)
        {
            case WavesStates.STARTING_WAVE:
                break;

            case WavesStates.SPAWNING:

                if (_countdownSpawnWave <= 0)
                {
                    _currentState = WavesStates.WAITING;
                    Debug.Log("Entered waiting state.");
                }
                else
                {
                    _countdownSpawnWave -= Time.deltaTime;

                }
                break;

            case WavesStates.WAITING:

                if (_enemiesSpawned.Count == 0)
                {
                    WaveEnded();
                    _currentState = WavesStates.STARTING_WAVE;
                    Debug.Log("Entered starting wave state.");
                    _currentWave++;
                    StartCoroutine(StartWave());
                }

                break;
            default:
                break;
        }


    }


    #endregion

    #region Methods

    public void InitiateWaves()
    {
        _enemiesSpawned = new List<GameObject>();

        _spawnsPosition = new Vector3[_spawnsHolder.childCount];

        for (int i = 0; i < _spawnsPosition.Length; i++)
        {
            _spawnsPosition[i] = _spawnsHolder.GetChild(i).transform.position;
        }

        _currentWave = _startingWave;

        StartCoroutine(StartWave());
    }

    IEnumerator StartWave()
    {
        //UIManager.Instance.ChangeWaveUITXT($"Wave {_currentWave + 1}");

        if (_currentWave >= _waves.Length)
        {
            GameManager.Instance.PhaseWon();
        }

        _countdownSpawnWave = _waves[_currentWave].waveDuration;

        yield return new WaitForSeconds(_timeBetweenWaves);

        _currentState = WavesStates.SPAWNING;

        Debug.Log("Entered spawning state.");

        foreach (var enemy in _waves[_currentWave].enemiesToSpawn)
        {
            StartCoroutine(SpawnEnemy(enemy));
        }

    }


    IEnumerator SpawnEnemy(SO_Enemy enemyToSpawn)
    {
        GameObject enemySpawned;

        while (_currentState == WavesStates.SPAWNING)
        {
            yield return new WaitForSeconds(enemyToSpawn.spawnTime);
            enemySpawned = SpawnManager.Instance.SpawnEnemy(enemyToSpawn.enemyPrefab, GetARandomSpawnPosition());
            _enemiesSpawned.Add(enemySpawned);
        }
    }


    private Vector3 GetARandomSpawnPosition()
    {
        int index = Random.Range(0, _spawnsPosition.Length);
        return _spawnsPosition[index];
    }


    public void RemoveSpawnedEnemy(GameObject deadEnemy)
    {
        _enemiesSpawned.Remove(deadEnemy);
    }

    public void SetSpawnsHolder(Transform spawnsHolder)
    {
        _spawnsHolder = spawnsHolder;
    }

    public void StopSpawning()
    {
        StopAllCoroutines();
        _currentState = WavesStates.NONE;
    }

    #endregion
}

public enum WavesStates
{
    NONE,
    STARTING_WAVE,
    SPAWNING,
    WAITING
}
