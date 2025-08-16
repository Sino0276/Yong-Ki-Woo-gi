using System;
using System.Collections;
using System.Collections.Generic;
using Core;
using UnityEngine;

public class DragonController : MonoBehaviour
{
    private AttackHandler[] attackHandlers;
    private int currentAttackHandlerIndex = 0;
    public DragonStats DragonStats { get; private set; }
    public GameInfo_DragonsData DragonData { get; private set;}

    public void Start()
    {
        Init(1);
    }

    public void Init(int id)
    {
        DragonData = Managers.Data.DragonData.GetByKey(id);
        DragonStats = new DragonStats(DragonData);
        attackHandlers = GetComponentsInChildren<AttackHandler>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
    }

    public void Attack()
    {
        attackHandlers[currentAttackHandlerIndex].Attack();
        currentAttackHandlerIndex++;
        if (currentAttackHandlerIndex >= attackHandlers.Length)
        {
            currentAttackHandlerIndex = 0;
        }
    }
}

public class DragonStats
{
    public float dropPercent;
    public float damageRate;
    public int attackSpeed;
    public float criticalRate;
    public float minCriticalDamage;
    public float maxCriticalDamage;
    public int feverCount;
    public int feverTime;
    public float coinBonus;
    public float itemBonus;
    public float bluePotionDuration;
    public float yellowPotionDuration;
    public float redPotionDuration;
    public float allPotionDuration;

    public DragonStats(GameInfo_DragonsData gameInfo)
    {
        Init(gameInfo.drop, gameInfo.damage, gameInfo.atkSpeed, gameInfo.critRate, gameInfo.minCritDmg, gameInfo.maxCritDmg, gameInfo.fever, gameInfo.feverTime, gameInfo.coinBonus, gameInfo.itemBonus, gameInfo.bluePotionDuration, gameInfo.yellowPotionDuration, gameInfo.redPotionDuration, gameInfo.allPotionDuration);
    }

    public DragonStats(int id)
    {
        GameInfo_DragonsData gameInfo = Managers.Data.DragonData.GetByKey(id);
        Init(gameInfo.drop, gameInfo.damage, gameInfo.atkSpeed, gameInfo.critRate, gameInfo.minCritDmg, gameInfo.maxCritDmg, gameInfo.fever, gameInfo.feverTime, gameInfo.coinBonus, gameInfo.itemBonus, gameInfo.bluePotionDuration, gameInfo.yellowPotionDuration, gameInfo.redPotionDuration, gameInfo.allPotionDuration);
    }

    public DragonStats(float dropPercent, float damageRate, int attackSpeed, float criticalRate, float minCriticalDamage, float maxCriticalDamage, int feverCount, int feverTime, float coinBonus, float itemBonus, float bluePotionDuration, float yellowPotionDuration, float redPotionDuration, float allPotionDuration)
    {
        Init(dropPercent, damageRate, attackSpeed, criticalRate, minCriticalDamage, maxCriticalDamage, feverCount, feverTime, coinBonus, itemBonus, bluePotionDuration, yellowPotionDuration, redPotionDuration, allPotionDuration);
    }

    public void Init(float dropPercent, float damageRate, int attackSpeed, float criticalRate, float minCriticalDamage, float maxCriticalDamage, int feverCount, int feverTime, float coinBonus, float itemBonus, float bluePotionDuration, float yellowPotionDuration, float redPotionDuration, float allPotionDuration)
    {
        this.dropPercent = dropPercent;
        this.damageRate = damageRate;
        this.attackSpeed = attackSpeed;
        this.criticalRate = criticalRate;
        this.minCriticalDamage = minCriticalDamage;
        this.maxCriticalDamage = maxCriticalDamage;
        this.feverCount = feverCount;
        this.feverTime = feverTime;
        this.coinBonus = coinBonus;
        this.itemBonus = itemBonus;
        this.bluePotionDuration = bluePotionDuration;
        this.yellowPotionDuration = yellowPotionDuration;
        this.redPotionDuration = redPotionDuration;
        this.allPotionDuration = allPotionDuration;
    }
}
