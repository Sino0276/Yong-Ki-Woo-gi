using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UserManager
{
    [field: SerializeField] public Currency Currency { get; private set; } = new Currency();
    [field: SerializeField] public StatLevel StatLevel { get; private set; } = new StatLevel();
    [field: SerializeField] public CurrentStat CurrentStat { get; private set; } = new CurrentStat();
    [field: SerializeField] public Stage Stage { get; private set; } = new Stage();
    [field: SerializeField] public Dragon Dragon { get; private set; } = new Dragon();
    [field: SerializeField] public Consumable Consumable { get; private set; } = new Consumable();

    [field: SerializeField] public int CurrentDragonId { get; private set; } = 1;
    public event Action<int, int> OnCurrentDragonIdChange;

    public void Init()
    {
        Load();
        CurrentStat.Init(this);
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
        if (PlayerPrefs.HasKey("CurrentDragonId")) CurrentDragonId = PlayerPrefs.GetInt("CurrentDragonId");

        Debug.Log(PlayerPrefs.GetString("Currency"));
        Debug.Log(PlayerPrefs.GetString("StatLevel"));
        Debug.Log(PlayerPrefs.GetString("CurrentStat"));
        Debug.Log(PlayerPrefs.GetString("StageData"));
        Debug.Log(PlayerPrefs.GetString("DragonData"));
        Debug.Log(PlayerPrefs.GetString("ConsumableData"));
        Debug.Log(PlayerPrefs.GetInt("CurrentDragonId"));
    }

    public void Reset()
    {
        Currency = new Currency();
        StatLevel = new StatLevel();
        CurrentStat = new CurrentStat();
        Stage = new Stage();
        Dragon = new Dragon();
        Consumable = new Consumable();
        CurrentDragonId = 1;
    }

    public void Save()
    {
        PlayerPrefs.SetString("Currency", JsonUtility.ToJson(Currency));
        PlayerPrefs.SetString("StatLevel", JsonUtility.ToJson(StatLevel));
        PlayerPrefs.SetString("CurrentStat", JsonUtility.ToJson(CurrentStat));
        PlayerPrefs.SetString("StageData", JsonUtility.ToJson(Stage));
        PlayerPrefs.SetString("DragonData", JsonUtility.ToJson(Dragon));
        PlayerPrefs.SetString("ConsumableData", JsonUtility.ToJson(Consumable));
        PlayerPrefs.SetInt("CurrentDragonId", CurrentDragonId);

        Debug.Log(PlayerPrefs.GetString("Currency"));
        Debug.Log(PlayerPrefs.GetString("StatLevel"));
        Debug.Log(PlayerPrefs.GetString("CurrentStat"));
        Debug.Log(PlayerPrefs.GetString("StageData"));
        Debug.Log(PlayerPrefs.GetString("DragonData"));
        Debug.Log(PlayerPrefs.GetString("ConsumableData"));
        Debug.Log(PlayerPrefs.GetInt("CurrentDragonId"));
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
    [SerializeField] private List<int> dragonList = new List<int>() { 1 };
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
    [field: SerializeField] public StatValue<int> CurrentStage { get; private set; } = new StatValue<int>(1);
    [field: SerializeField] public StatValue<int> CurrentCount { get; private set; } = new StatValue<int>(0);
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

    private UserManager userManager;

    public void Init(UserManager userManager)
    {
        this.userManager = userManager;

        userManager.OnCurrentDragonIdChange += OnCurrentDragonIdChange;

        userManager.StatLevel.Atk.OnValueChange += OnStatLevelAtkChange;
        userManager.StatLevel.AtkSpeed.OnValueChange += OnStatLevelAtkSpeedChange;
        userManager.StatLevel.CritRate.OnValueChange += OnStatLevelCritRateChange;
        userManager.StatLevel.CritDmg.OnValueChange += OnStatLevelCritDmgChange;
        userManager.StatLevel.Fever.OnValueChange += OnStatLevelFeverChange;
        userManager.StatLevel.FeverTime.OnValueChange += OnStatLevelFeverTimeChange;
    }

    public void OnCurrentDragonIdChange(int oldValue, int newValue)
    {
        CalculateStat();
    }

    public void OnStatLevelAtkChange(int oldValue, int newValue)
    {
        Atk.Value = Managers.Data.LevelSO.AtkSO.AtkCurve.Evaluate(newValue) * Managers.Data.DragonData.GetByKey(userManager.CurrentDragonId).damage;
    }

    public void OnStatLevelAtkSpeedChange(int oldValue, int newValue)
    {
        AtkSpeed.Value = Managers.Data.LevelSO.AtkSpeedSO.AtkSpeedCurve.Evaluate(newValue) * Managers.Data.DragonData.GetByKey(userManager.CurrentDragonId).atkSpeed;
    }

    public void OnStatLevelCritRateChange(int oldValue, int newValue)
    {
        CritRate.Value = Managers.Data.LevelSO.CritRateSO.CritRateCurve.Evaluate(newValue) * Managers.Data.DragonData.GetByKey(userManager.CurrentDragonId).critRate;
    }
    
    public void OnStatLevelCritDmgChange(int oldValue, int newValue)
    {
        CritDmg.Value = Managers.Data.LevelSO.CritDmgSO.CritDmgCurve.Evaluate(newValue) * Managers.Data.DragonData.GetByKey(userManager.CurrentDragonId).minCritDmg;
    }

    public void OnStatLevelFeverChange(int oldValue, int newValue)
    {
        Fever.Value = Managers.Data.LevelSO.FeverSO.FeverCurve.Evaluate(newValue) * Managers.Data.DragonData.GetByKey(userManager.CurrentDragonId).fever;
    }
    
    public void OnStatLevelFeverTimeChange(int oldValue, int newValue)
    {
        FeverTime.Value = Managers.Data.LevelSO.FeverTimeSO.FeverTimeCurve.Evaluate(newValue) * Managers.Data.DragonData.GetByKey(userManager.CurrentDragonId).feverTime;
    }

    public void CalculateStat()
    {
        OnStatLevelAtkChange(0, userManager.StatLevel.Atk.Value);
        OnStatLevelAtkSpeedChange(0, userManager.StatLevel.AtkSpeed.Value);
        OnStatLevelCritRateChange(0, userManager.StatLevel.CritRate.Value);
        OnStatLevelCritDmgChange(0, userManager.StatLevel.CritDmg.Value);
        OnStatLevelFeverChange(0, userManager.StatLevel.Fever.Value);
        OnStatLevelFeverTimeChange(0, userManager.StatLevel.FeverTime.Value);
    }
}