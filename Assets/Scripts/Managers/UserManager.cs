using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UserManager
{
    [field: SerializeField] public Currency Currency { get; private set; }
    [field: SerializeField] public StatLevel StatLevel { get; private set; }
    [field: SerializeField] public CurrentStat CurrentStat { get; private set; }
    [field: SerializeField] public Stage Stage { get; private set; }
    [field: SerializeField] public Dragon Dragon { get; private set; }
    [field: SerializeField] public Consumable Consumable { get; private set; }

    [field: SerializeField] public int CurrentDragonId { get; private set; }
    public event Action<int, int> OnCurrentDragonIdChange;

    public void Init()
    {
        Load();
    }

    public void ChangeDragon(int dragonId)
    {
        int oldValue = CurrentDragonId;
        CurrentDragonId = dragonId;
        OnCurrentDragonIdChange?.Invoke(oldValue, CurrentDragonId);
    }

    public void Load()
    {
        if (PlayerPrefs.HasKey("Currency")) JsonUtility.FromJsonOverwrite(PlayerPrefs.GetString("Currency"), Currency);
        if (PlayerPrefs.HasKey("StatLevel")) JsonUtility.FromJsonOverwrite(PlayerPrefs.GetString("StatLevel"), StatLevel);
        if (PlayerPrefs.HasKey("CurrentStat")) JsonUtility.FromJsonOverwrite(PlayerPrefs.GetString("CurrentStat"), CurrentStat);
        if (PlayerPrefs.HasKey("StageData")) JsonUtility.FromJsonOverwrite(PlayerPrefs.GetString("StageData"), Stage);
        if (PlayerPrefs.HasKey("DragonData")) JsonUtility.FromJsonOverwrite(PlayerPrefs.GetString("DragonData"), Dragon);
        if (PlayerPrefs.HasKey("ConsumableData")) JsonUtility.FromJsonOverwrite(PlayerPrefs.GetString("ConsumableData"), Consumable);
    }

    public void Reset()
    {
        Currency = new Currency();
        StatLevel = new StatLevel();
        CurrentStat = new CurrentStat();
        Stage = new Stage();
    }

    public void Save()
    {
        PlayerPrefs.SetString("Currency", JsonUtility.ToJson(Currency));
        PlayerPrefs.SetString("StatLevel", JsonUtility.ToJson(StatLevel));
        PlayerPrefs.SetString("CurrentStat", JsonUtility.ToJson(CurrentStat));
        PlayerPrefs.SetString("StageData", JsonUtility.ToJson(Stage));
        PlayerPrefs.SetString("DragonData", JsonUtility.ToJson(Dragon));
        PlayerPrefs.SetString("ConsumableData", JsonUtility.ToJson(Consumable));
    }
}

[System.Serializable]
public class Consumable
{
    [field: SerializeField] public StatValue<int> BluePotion { get; private set; } = new StatValue<int>();
    [field: SerializeField] public StatValue<int> YellowPotion { get; private set; } = new StatValue<int>();
    [field: SerializeField] public StatValue<int> RedPotion { get; private set; } = new StatValue<int>();
}

[System.Serializable]
public class Dragon
{
    private List<int> dragonList = new List<int>();
    public event Action<List<int>, List<int>> OnDragonListChange;

    public IReadOnlyList<int> DragonList => dragonList;

    public void AddDragon(int dragonId)
    {
        dragonList.Add(dragonId);
        OnDragonListChange?.Invoke(dragonList, dragonList);
    }

    public void RemoveDragon(int dragonId)
    {
        dragonList.Remove(dragonId);
        OnDragonListChange?.Invoke(dragonList, dragonList);
    }
}

[System.Serializable]
public class Stage
{
    [field: SerializeField] public StatValue<int> CurrentStage { get; private set; } = new StatValue<int>();
    [field: SerializeField] public StatValue<int> CurrentCount { get; private set; } = new StatValue<int>();
}

[System.Serializable]
public class Currency
{
    [field: SerializeField] public StatValue<int> Coin { get; private set; } = new StatValue<int>();
    [field: SerializeField] public StatValue<int> Ruby { get; private set; } = new StatValue<int>();
}

[System.Serializable]
public class StatLevel
{
    [field: SerializeField] public StatValue<int> Atk { get; private set; } = new StatValue<int>();
    [field: SerializeField] public StatValue<int> AtkSpeed { get; private set; } = new StatValue<int>();
    [field: SerializeField] public StatValue<int> CritRate { get; private set; } = new StatValue<int>();
    [field: SerializeField] public StatValue<int> CritDmg { get; private set; } = new StatValue<int>();
    [field: SerializeField] public StatValue<int> Fever { get; private set; } = new StatValue<int>();
    [field: SerializeField] public StatValue<int> FeverTime { get; private set; } = new StatValue<int>();
}

[System.Serializable]
public class CurrentStat
{
    [field: SerializeField] public StatValue<float> Atk { get; private set; } = new StatValue<float>();
    [field: SerializeField] public StatValue<float> AtkSpeed { get; private set; } = new StatValue<float>();
    [field: SerializeField] public StatValue<float> CritRate { get; private set; } = new StatValue<float>();
    [field: SerializeField] public StatValue<float> CritDmg { get; private set; } = new StatValue<float>();
    [field: SerializeField] public StatValue<float> Fever { get; private set; } = new StatValue<float>();
    [field: SerializeField] public StatValue<float> FeverTime { get; private set; } = new StatValue<float>();
}