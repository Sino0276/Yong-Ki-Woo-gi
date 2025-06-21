using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UserDataManager
{
    // 골드, 루비, 드레곤 도감, 물약 종류, 스탯, 모험 진도, 스테이지 ...
    [Header("Currency")]
    public int coin = 0;
    public int ruby = 0;
    
    [Header("Dragon")]
    public List<int> dragonList = new List<int>();
    
    [Header("Potion")]
    public int blucPotion = 0;
    public int yellowPotion = 0;
    public int redPotion = 0;
    
    [Header("Upgrade")]
    public int atkLevel = 0;
    public int atkSpeedLevel = 0;
    public int critRateLevel = 0;
    public int critDmgLevel = 0;
    public int feverLevel = 0;
    public int feverTimeLevel = 0;
    
}
