using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[Serializable]
public class GameInfo_EnemyData
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
    /// PrefabPath
    /// </summary>
    public string prefabPath;

    /// <summary>
    /// Hp
    /// </summary>
    public int hp;

    /// <summary>
    /// DropCoin
    /// </summary>
    public int coin;

}
public class GameInfo_EnemyDataLoader
{
    public List<GameInfo_EnemyData> ItemsList { get; private set; }
    public Dictionary<int, GameInfo_EnemyData> ItemsDict { get; private set; }

    public GameInfo_EnemyDataLoader(string path = "JSON/GameInfo_EnemyData")
    {
        string jsonData;
        jsonData = Resources.Load<TextAsset>(path).text;
        ItemsList = JsonUtility.FromJson<Wrapper>(jsonData).Items;
        ItemsDict = new Dictionary<int, GameInfo_EnemyData>();
        foreach (var item in ItemsList)
        {
            ItemsDict.Add(item.key, item);
        }
    }

    [Serializable]
    private class Wrapper
    {
        public List<GameInfo_EnemyData> Items;
    }

    public GameInfo_EnemyData GetByKey(int key)
    {
        if (ItemsDict.ContainsKey(key))
        {
            return ItemsDict[key];
        }
        return null;
    }
    public GameInfo_EnemyData GetByIndex(int index)
    {
        if (index >= 0 && index < ItemsList.Count)
        {
            return ItemsList[index];
        }
        return null;
    }
}
