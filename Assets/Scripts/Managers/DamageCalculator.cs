using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCalculator
{
    public float CalculateDamage(out bool isCritical)
    {
        float damage = Managers.User.CurrentStat.Atk.Value;

        float critRate = Managers.User.CurrentStat.CritRate.Value;

        if (GameManager.Instance.Dragon.IsFevering || critRate > Random.Range(0f, 100f))
        {
            float critDmg = Managers.User.CurrentStat.CritDmg.Value;
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
