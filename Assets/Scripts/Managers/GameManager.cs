using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameManager : Singleton<GameManager>
{
    [field: SerializeField] public Projectile projectilePrefab { get; private set; }
    [field: SerializeField] public GameObject enemySpawnPoint { get; private set; }
    [field: SerializeField] public GameObject dragonSpawnPoint { get; private set; }

    [field: SerializeField] public StageManager StageManager { get; private set; }


    [field: SerializeField] public DragonController Dragon { get; private set; }

    public static StageManager Stage => Instance.StageManager;
    public static GameObject EnemySpawnPoint => Instance.enemySpawnPoint;
    public static GameObject DragonSpawnPoint => Instance.dragonSpawnPoint;

    public void Start()
    {
        SpawnDragon(Managers.User.CurrentDragonId);
        StageManager.Init(this);
    }

    public void Update()
    {
        StageManager.Update();
    }

    public void SpawnDragon(int id)
    {
        GameInfo_DragonsData dragonData = Managers.Data.DragonData.GetByKey(id);
        DragonController dragon = Managers.Resource.Load<DragonController>(dragonData.prefabPath);
        Dragon = Object.Instantiate(dragon, dragonSpawnPoint.transform.position, Quaternion.identity);
        Dragon.Init(id);
    }
}
