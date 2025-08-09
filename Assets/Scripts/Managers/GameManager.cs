using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameManager
{
    [field: SerializeField] public Projectile projectilePrefab { get; private set; }
    [field: SerializeField] public GameObject enemySpawnPoint { get; private set; }
    [field: SerializeField] public GameObject dragonSpawnPoint { get; private set; }

    public EnemyController Enemy { get; private set; }
    public StageManager StageManager { get; private set; }

    public void Init()
    {
        StageManager = new StageManager();
    }

    
}
