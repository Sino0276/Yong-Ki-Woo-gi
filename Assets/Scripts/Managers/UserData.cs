using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UserData
{
    [Header("Currency")]
    public int coin = 0;
    public int ruby = 0;

    [Header("Dragon")]
    public List<int> dragonList = new List<int>();

    [Header("Potion")]
    public int bluePotion = 0;
    public int yellowPotion = 0;
    public int redPotion = 0;

    [Header("Upgrade")]
    public int atkLevel = 0;
    public int atkSpeedLevel = 0;
    public int critRateLevel = 0;
    public int critDmgLevel = 0;
    public int feverLevel = 0;
    public int feverTimeLevel = 0;

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
