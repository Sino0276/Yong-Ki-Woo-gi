using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UserData
{
    public StatData statData = new StatData();
    public StageData stageData = new StageData();

    public int selectedDragonId = 1;

    public void Init()
    {
        Load();
    }

    public void Reset()
    {
        statData = new StatData();
        stageData = new StageData();
        selectedDragonId = 1;
        Save();
    }

    public void Save()
    {
        PlayerPrefs.SetString("UserData", JsonUtility.ToJson(this));
    }

    public void Load()
    {
        if (PlayerPrefs.HasKey("UserData"))
        {
            JsonUtility.FromJsonOverwrite(PlayerPrefs.GetString("UserData"), this);
        }
    }
}

[System.Serializable]
public class StatData
{
    [Header("Currency")]
    public int coin = 0;
    public int ruby = 0;

    [Header("Dragon")]
    public List<int> dragonList = new List<int>(){1};

    [Header("Potion")]
    public int bluePotion = 0;
    public int yellowPotion = 0;
    public int redPotion = 0;

    [Header("Upgrade")]
    public int atkLevel = 1;
    public int atkSpeedLevel = 1;
    public int critRateLevel = 1;
    public int critDmgLevel = 1;
    public int feverLevel = 1;
    public int feverTimeLevel = 1;
}

[System.Serializable]
public class StageData
{
    public int stage = 1;
    public int count  = 0;
}