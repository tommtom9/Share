using System;
using UnityEngine;

[Serializable]
public class Wave
{
    [Space(5)] [Tooltip("Amount of enemies in each pack")] public int packCount = 2;
    [Tooltip("Time between each pack of enemies in a wave")] public float spawnInterfal = 2;
    [Space(5)] public EnemyBase[] enemyBase;
}

[Serializable]
public class EnemyBase
{
    public Enemy enemy;
    public int count;
}