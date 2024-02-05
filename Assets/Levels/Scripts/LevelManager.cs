using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private LevelScriptableObject _Level;
    [SerializeField] private int currentWave = 0;
    [SerializeField] private Array2DGameObject spawnPoints;
    [SerializeField] private Enemy Drone, Tank, Minion, Turret;
    [SerializeField] private float delayBetweenWaves = 1f;

    private int _enemyCount;
    public static LevelManager Instance { get; private set; }
    public int EnemyCount
    {
        get { return _enemyCount;}
        set
        {
            _enemyCount = value;
            if (_enemyCount <= 0)
            {
                currentWave++;
                StartCoroutine(WaveSequence());
            }
        }
    }
    private void SpawnWave()
    {
        if (currentWave == _Level.EnemyWaves.Length)
        {
            SceneManager.LoadScene("MainMenu");
            return;
        }
        var enemySequence = _Level.EnemyWaves[currentWave];
        for (int y = 0; y < enemySequence.GridSize.y; y++)
        {
            for (int x = 0; x < enemySequence.GridSize.x; x++)
            {
                var enemy = GetEnemy(enemySequence.GetCell(x, y));
                var position = spawnPoints.GetCell(x, y).transform.position;
                if (position != null && enemy != null)
                {
                    _enemyCount++;
                    var go = Instantiate(enemy, position, enemy.transform.rotation);
                    go.Health *= _Level.HPMultiplicator.Evaluate((float) currentWave / 10);
                }
            }
        }
    }

    private void Start()
    {
        Instance = this;
        StartCoroutine(WaveSequence());
    }

    private IEnumerator WaveSequence()
    {
        yield return new WaitForSeconds(delayBetweenWaves);
        SpawnWave();
    }

    private Enemy GetEnemy(EnemyEnum enemyEnum)
    {
        switch (enemyEnum)
        {
            case EnemyEnum.None : return null;
            case EnemyEnum.Drone : return Drone;
            case EnemyEnum.Minion : return Minion;
            case EnemyEnum.Tank : return Tank;
            case EnemyEnum.Turret : return Turret;
        }

        return null;
    }
}
