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
    public bool isStageClear = false;
    public bool allowBossSpawn = true;

    private Coroutine timerCoroutine;

    public StageManager(GameManager gameManager)
    {
        this.gameManager = gameManager;
        SpawnEnemy(GetRandomEnemyId());
    }

    private void SpawnEnemy(int id, bool isBoss = false)
    {
        if (isBoss)
        {
            timerCoroutine = Managers.Instance.StartCoroutine(Timer(10));
        }

        GameInfo_EnemyData enemyData = Managers.Data.EnemyData.GetByKey(id);
        EnemyController enemy = Managers.Resource.Load<EnemyController>(enemyData.prefabPath);
        Enemy = Object.Instantiate(enemy, gameManager.enemySpawnPoint.transform.position, Quaternion.identity);
        Enemy.Init(id, enemyData.hp * Managers.UserData.stageData.stage, isBoss);
        Enemy.OnDeath += OnEnemyDeath;
    }

    private void OnEnemyDeath(bool isBoss)
    {
        Enemy.OnDeath -= OnEnemyDeath;
        Reward(Enemy.id);
        if (isBoss)
        {
            OnClearStage();
            Managers.Instance.StopCoroutine(timerCoroutine);
        }
        else if (Managers.UserData.stageData.count < 10)
        {
            Managers.UserData.stageData.count++;
        }

        SpawnEnemy(GetRandomEnemyId(), Managers.UserData.stageData.count == 10 && allowBossSpawn);
        Managers.UserData.Save();
    }

    private void Reward(int enemyId)
    {
        GameInfo_EnemyData enemyData = Managers.Data.EnemyData.GetByKey(enemyId);
        Managers.UserData.statData.coin += (int)(enemyData.coin * gameManager.Dragon.DragonStats.coinBonus * Managers.UserData.stageData.stage);
        if(Enemy.isBoss) RandomDragonReward();
    }

    private void RandomDragonReward()
    {
        IReadOnlyList<GameInfo_DragonsData> dragonData = Managers.Data.DragonData.ItemsList;

        for (int i = 0; i < dragonData.Count; i++)
        {
            float drop = dragonData[i].drop + Managers.Data.EnemyData.GetByKey(Enemy.id).dropBonus;
            float random = Random.Range(0f, 1f);
            if (random > drop) 
            {
                Debug.Log("Dragon Drop Fail");
                break;
            }

            if (Managers.UserData.statData.dragonList.Contains(dragonData[i].key)) continue;

            Managers.UserData.statData.dragonList.Add(dragonData[i].key);
            Debug.Log("Dragon Drop Success");
            break;
        }
    }

    private void OnClearStage()
    {
        Managers.UserData.stageData.count = 0;
        Managers.UserData.stageData.stage++;
        isStageClear = true;
    }

    private int GetRandomEnemyId()
    {
        return 1000 + Random.Range(1, Managers.Data.EnemyData.ItemsList.Count + 1);
    }

    private IEnumerator Timer(int time)
    {
        Debug.Log("Timer Start");
        yield return new WaitForSeconds(time);
        Debug.Log("Timer End");
        allowBossSpawn = false;

        Enemy.OnDeath -= OnEnemyDeath;
        Object.Destroy(Enemy.gameObject);
        SpawnEnemy(GetRandomEnemyId());
    }
}
