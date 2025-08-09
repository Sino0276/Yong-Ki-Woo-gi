using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager
{
    private GameManager gameManager;
    public EnemyController Enemy { get; private set; }

    public StageManager(GameManager gameManager)
    {
        this.gameManager = gameManager;
    }
    
    private void SpawnEnemy(int id)
    {
        Enemy = Object.Instantiate(Managers.Resource.Load<EnemyController>("Enemy"), gameManager.enemySpawnPoint.transform.position, Quaternion.identity);
    }
}
