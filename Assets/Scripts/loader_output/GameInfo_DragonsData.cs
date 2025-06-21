using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[Serializable]
public class GameInfo_DragonsData
{
    /// <summary>
    /// ID
    /// </summary>
    public int key;

    /// <summary>
    /// DragonName
    /// </summary>
    public string name;

    /// <summary>
    /// Description
    /// </summary>
    public string description;

    /// <summary>
    /// SpritePath
    /// </summary>
    public string spritePath;

    /// <summary>
    /// PrefabPath
    /// </summary>
    public string prefabPath;

    /// <summary>
    /// Percent
    /// </summary>
    public float drop;

    /// <summary>
    /// DamageRate
    /// </summary>
    public float damage;

    /// <summary>
    /// AtackSpeed
    /// </summary>
    public int atkSpeed;

    /// <summary>
    /// CriticalRate
    /// </summary>
    public float critRate;

    /// <summary>
    /// MinCriticalDamage
    /// </summary>
    public float minCritDmg;

    /// <summary>
    /// MaxCriticalDamage
    /// </summary>
    public float maxCritDmg;

    /// <summary>
    /// FeverCount
    /// </summary>
    public int fever;

    /// <summary>
    /// FeverDuring
    /// </summary>
    public int feverTime;

    /// <summary>
    /// CoinBonus
    /// </summary>
    public float coinBonus;

    /// <summary>
    /// itemBonus
    /// </summary>
    public float itemBonus;

    /// <summary>
    /// duration
    /// </summary>
    public float bluePotionDuration;

    /// <summary>
    /// duration
    /// </summary>
    public float yellowPotionDuration;

    /// <summary>
    /// duration
    /// </summary>
    public float redPotionDuration;

    /// <summary>
    /// duration
    /// </summary>
    public float allPotionDuration;

}
public class GameInfo_DragonsDataLoader
{
    public List<GameInfo_DragonsData> ItemsList { get; private set; }
    public Dictionary<int, GameInfo_DragonsData> ItemsDict { get; private set; }

    public GameInfo_DragonsDataLoader(string path = "json_output/GameInfo_DragonsData")
    {
        string jsonData;
        jsonData = Resources.Load<TextAsset>(path).text;
        ItemsList = JsonUtility.FromJson<Wrapper>(jsonData).Items;
        ItemsDict = new Dictionary<int, GameInfo_DragonsData>();
        foreach (var item in ItemsList)
        {
            ItemsDict.Add(item.key, item);
        }
    }

    [Serializable]
    private class Wrapper
    {
        public List<GameInfo_DragonsData> Items;
    }

    public GameInfo_DragonsData GetByKey(int key)
    {
        if (ItemsDict.ContainsKey(key))
        {
            return ItemsDict[key];
        }
        return null;
    }
    public GameInfo_DragonsData GetByIndex(int index)
    {
        if (index >= 0 && index < ItemsList.Count)
        {
            return ItemsList[index];
        }
        return null;
    }
}
