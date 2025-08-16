using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCalculator
{
    public float CalculateDamage(DragonController dragonController, out bool isCritical)
    {
        int atkLevel = Managers.UserData.statData.atkLevel;
        float damage = (atkLevel + (atkLevel * 0.6f)) * dragonController.DragonStats.damageRate;

        int critRateLevel = Managers.UserData.statData.critRateLevel;
        float critRate = (critRateLevel * 1.5f) * dragonController.DragonStats.criticalRate;

        if (critRate > Random.Range(0f, 100f))
        {
            int critDmgLevel = Managers.UserData.statData.critDmgLevel;
            float critDmg = (critDmgLevel * 3.5f) + Random.Range(dragonController.DragonStats.minCriticalDamage, dragonController.DragonStats.maxCriticalDamage);
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
