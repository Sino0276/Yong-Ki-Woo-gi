using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

[Serializable]
public class StageManager
{
    private GameManager gameManager;
    [field: SerializeField] public EnemyController Enemy { get; private set; }

    public StageManager(GameManager gameManager)
    {
        this.gameManager = gameManager;
        SpawnEnemy(GetRandomEnemyId());
    }
    
    private void SpawnEnemy(int id)
    {
        GameInfo_EnemyData enemyData = Managers.Data.EnemyData.GetByKey(id);
        EnemyController enemy = Managers.Resource.Load<EnemyController>(enemyData.prefabPath);
        Enemy = Object.Instantiate(enemy, gameManager.enemySpawnPoint.transform.position, Quaternion.identity);
        Enemy.Init(enemyData.hp * Managers.UserData.stageData.stage);
        Enemy.OnDeath += OnEnemyDeath;
    }

    private void OnEnemyDeath()
    {
        Managers.UserData.stageData.count++;
        if(Managers.UserData.stageData.count >= 10)
        {
            Managers.UserData.stageData.count = 0;
            Managers.UserData.stageData.stage++;
        }
        Managers.UserData.Save();
        SpawnEnemy(GetRandomEnemyId());
    }

    private int GetRandomEnemyId()
    {
        return 1000 + Random.Range(1, Managers.Data.EnemyData.ItemsList.Count + 1);
    }
}
