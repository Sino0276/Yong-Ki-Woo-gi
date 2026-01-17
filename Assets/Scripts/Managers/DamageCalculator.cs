using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCalculator
{
    public float CalculateDamage(DragonController dragonController, out bool isCritical)
    {
        int atkLevel = Managers.User.StatLevel.Atk.Value;
        float damage = Managers.Data.LevelSO.AtkSO.AtkCurve.Evaluate(atkLevel) * dragonController.DragonStats.damageRate;

        int critRateLevel = Managers.User.StatLevel.CritRate.Value;
        float critRate = Managers.Data.LevelSO.CritRateSO.CritRateCurve.Evaluate(critRateLevel) * dragonController.DragonStats.criticalRate;

        if (critRate > Random.Range(0f, 100f))
        {
            int critDmgLevel = Managers.User.StatLevel.CritDmg.Value;
            float critDmg = Managers.Data.LevelSO.CritDmgSO.CritDmgCurve.Evaluate(critDmgLevel) + Random.Range(dragonController.DragonStats.minCriticalDamage, dragonController.DragonStats.maxCriticalDamage);
            damage *= critDmg;
            isCritical = true;
        }
        else
        {
            isCritical = false;
        }

        return damage;
    }
}
