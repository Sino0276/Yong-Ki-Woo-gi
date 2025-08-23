using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameManager
{
    [field: SerializeField] public Projectile projectilePrefab { get; private set; }
    [field: SerializeField] public GameObject enemySpawnPoint { get; private set; }
    [field: SerializeField] public GameObject dragonSpawnPoint { get; private set; }

    [field: SerializeField] public StageManager StageManager { get; private set; }

    [field: SerializeField] public DragonController Dragon { get; private set; }

    public void Init()
    {
        SpawnDragon(Managers.UserData.selectedDragonId);
        StageManager = new StageManager(this);
    }

    public void SpawnDragon(int id)
    {
        GameInfo_DragonsData dragonData = Managers.Data.DragonData.GetByKey(id);
        DragonController dragon = Managers.Resource.Load<DragonController>(dragonData.prefabPath);
        Dragon = Object.Instantiate(dragon, dragonSpawnPoint.transform.position, Quaternion.identity);
        Dragon.Init(id);
    }
}
