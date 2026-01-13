using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeSystem : MonoBehaviour
{
    [field: SerializeField] public LevelSO LevelSO { get; private set; }

    public bool Upgrade(StatType statType)
    {
        switch (statType)
        {
            case StatType.Atk:
                if(ValidataUpgrade(statType))
                {
                    Managers.UserData.statData.atkLevel++;
                    Managers.UserData.statData.Coin -= (int)(100 *LevelSO.DamageCurve.Evaluate(Managers.UserData.statData.atkLevel + 1));
                    return true;
                }
                break;
            case StatType.AtkSpeed:
                if(ValidataUpgrade(statType))
                {
                    Managers.UserData.statData.atkSpeedLevel++;
                    Managers.UserData.statData.Coin -= (int)(100 *LevelSO.AttackSpeedCurve.Evaluate(Managers.UserData.statData.atkSpeedLevel + 1));
                    return true;
                }
                break;
            case StatType.CritRate:
                if(ValidataUpgrade(statType))
                {
                    Managers.UserData.statData.critRateLevel++;
                    Managers.UserData.statData.Coin -= (int)(100 *LevelSO.CriticalRateCurve.Evaluate(Managers.UserData.statData.critRateLevel + 1));
                    return true;
                }
                break;
            case StatType.CritDmg:
                if(ValidataUpgrade(statType))
                {
                    Managers.UserData.statData.critDmgLevel++;
                    Managers.UserData.statData.Coin -= (int)(100 *LevelSO.CriticalDamageCurve.Evaluate(Managers.UserData.statData.critDmgLevel + 1));
                    return true;
                }
                break;
            case StatType.Fever:
                if(ValidataUpgrade(statType))
                {
                    Managers.UserData.statData.feverLevel++;
                    Managers.UserData.statData.Coin -= (int)(100 *LevelSO.FeverCurve.Evaluate(Managers.UserData.statData.feverLevel + 1));
                    return true;
                }
                break;
            case StatType.FeverTime:
                if(ValidataUpgrade(statType))
                {
                    Managers.UserData.statData.feverTimeLevel++;
                    Managers.UserData.statData.Coin -= (int)(100 *LevelSO.FeverTimeCurve.Evaluate(Managers.UserData.statData.feverTimeLevel + 1));
                    return true;
                }
                break;
        }
        return false;
    }

    private bool ValidataUpgrade(StatType statType)
    {
        switch (statType)
        {
            case StatType.Atk:
                if(Managers.UserData.statData.Coin < 100 *LevelSO.DamageCurve.Evaluate(Managers.UserData.statData.atkLevel + 1)) return false;
                break;
            case StatType.AtkSpeed:
                if(Managers.UserData.statData.Coin < 100 *LevelSO.AttackSpeedCurve.Evaluate(Managers.UserData.statData.atkSpeedLevel + 1)) return false;
                break;
            case StatType.CritRate:
                if(Managers.UserData.statData.Coin < 100 *LevelSO.CriticalRateCurve.Evaluate(Managers.UserData.statData.critRateLevel + 1)) return false;
                break;
            case StatType.CritDmg:
                if(Managers.UserData.statData.Coin < 100 *LevelSO.CriticalDamageCurve.Evaluate(Managers.UserData.statData.critDmgLevel + 1)) return false;
                break;
            case StatType.Fever:
                if(Managers.UserData.statData.Coin < 100 *LevelSO.FeverCurve.Evaluate(Managers.UserData.statData.feverLevel + 1)) return false;
                break;
            case StatType.FeverTime:
                if(Managers.UserData.statData.Coin < 100 *LevelSO.FeverTimeCurve.Evaluate(Managers.UserData.statData.feverTimeLevel + 1)) return false;
                break;
            default: return false;
        }

        return true;
    }
}

public enum StatType
{
    Atk,
    AtkSpeed,
    CritRate,
    CritDmg,
    Fever,
    FeverTime,
}
