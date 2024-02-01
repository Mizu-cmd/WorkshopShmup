using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private LevelScriptableObject _Level;
    [SerializeField] private int currentWave = 0;

    [SerializeField] private Array2DGameObject spawnPoints;

    [SerializeField] private GameObject Drone, Tank, Minion, Turret;

    private void SpawnWave()
    {
        var enemySequence = _Level.EnemyWaves[currentWave];
        for (int y = 0; y < enemySequence.GridSize.y; y++)
        {
            for (int x = 0; x < enemySequence.GridSize.x; x++)
            {
                var enemy = GetEnemy(enemySequence.GetCell(x, y));
                var position = spawnPoints.GetCell(x, y).transform.position;
                if (position != null && enemy != null)
                {
                    var go = Instantiate(enemy, position, Quaternion.identity).GetComponent<Enemy>();
                    go.Health *= _Level.HPMultiplicator.Evaluate((float) currentWave / 10);
                }
            }
        }
    }

    private void Start()
    {
        SpawnWave();
    }

    private GameObject GetEnemy(EnemyEnum enemyEnum)
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
