using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DataManager
{
    public GameInfo_DragonsDataLoader DragonData;
    public GameInfo_EnemyDataLoader EnemyData;
    [field: SerializeField] public LevelSO LevelSO { get; private set; }

    public void Init()
    {
        DragonData = new GameInfo_DragonsDataLoader();
        EnemyData = new GameInfo_EnemyDataLoader();
    }
}
