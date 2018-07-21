using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class WaveSpawner : MonoBehaviour
{
    public static Action WaveStartedEvent;

    [SerializeField] private Wave[] waves;
    [SerializeField] private Transform[] spawnPoints;
    
    private int waveCount = 0;

    
    //Should be called by AllPlayerReadyEvent (To be created)
    public void StartNextWave()
    {
        if (spawnPoints.Length == 0) { Debug.LogError("No spawnpoints"); return; }

        StartCoroutine(SpawnWave());
    }

    private IEnumerator SpawnWave()
    {
        WaitForSeconds _wait = new WaitForSeconds(waves[waveCount].spawnInterfal);
        List<Enemy> _enemiesInWave = PoolEnemies();

        int _spawnCount = 0;
        int _enemyCount = _enemiesInWave.Count;

        for (int i = 0; i < _enemyCount; i++)
        {
            Enemy _enemyToSpawn = _enemiesInWave[Random.Range(0, _enemiesInWave.Count)];
            _enemiesInWave.Remove(_enemyToSpawn);

            Transform _randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

            Instantiate(_enemyToSpawn.gameObject, _randomSpawnPoint.position, Quaternion.identity);

            _spawnCount = _spawnCount + 1;
            if (_spawnCount == waves[waveCount].packCount)
            {
                _spawnCount = 0;
                yield return _wait;
            }
        }

        FinishWave();
    }

    private void FinishWave()
    {
        waveCount = waveCount + 1;

        if (WaveStartedEvent != null)
        {
            WaveStartedEvent();
        }
    }

    private List<Enemy> PoolEnemies()
    {
        List<Enemy> enemyPool = new List<Enemy>();

        for (int i = 0; i < waves[waveCount].enemyBase.Length; i++)
        {
            for (int j = 0; j < waves[waveCount].enemyBase[i].count; j++)
            {
                enemyPool.Add(waves[waveCount].enemyBase[i].enemy);
            }
        }

        return enemyPool;
    }

    private int CountEnemies(Wave wave)
    {
        int _count = 0;

        for (int i = 0; i < wave.enemyBase.Length; i++)
        {
            _count += wave.enemyBase[i].count;
        } 

        return _count;
    }

    //Debug
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartNextWave();
        }
    }
}