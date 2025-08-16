using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager
{
    public GameInfo_DragonsDataLoader DragonData;
    public GameInfo_EnemyDataLoader EnemyData;

    public void Init()
    {
        DragonData = new GameInfo_DragonsDataLoader();
        EnemyData = new GameInfo_EnemyDataLoader();
    }
}
