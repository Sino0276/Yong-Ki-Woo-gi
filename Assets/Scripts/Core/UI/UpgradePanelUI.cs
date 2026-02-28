using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradePanelUI : BaseUI
{
    private UserManager userManager;

    [SerializeField] private UpgradeUI atkUpgradeUI;
    [SerializeField] private UpgradeUI atkSpeedUpgradeUI;
    [SerializeField] private UpgradeUI critRateUpgradeUI;
    [SerializeField] private UpgradeUI critDmgUpgradeUI;
    [SerializeField] private UpgradeUI feverUpgradeUI;
    [SerializeField] private UpgradeUI feverTimeUpgradeUI;

    private void Start()
    {
        userManager = Managers.User;
        Init();
    }

    public void Init()
    {
        atkUpgradeUI.SetUpgradeUI(userManager.StatLevel.Atk.Value, userManager.CurrentStat.Atk.Value, Managers.Data.LevelSO.AtkSO.AtkCurve.Evaluate(userManager.StatLevel.Atk.Value + 1), Managers.Data.LevelSO.AtkSO.AtkPriceCurve.Evaluate(userManager.StatLevel.Atk.Value + 1));
        atkSpeedUpgradeUI.SetUpgradeUI(userManager.StatLevel.AtkSpeed.Value, userManager.CurrentStat.AtkSpeed.Value, Managers.Data.LevelSO.AtkSpeedSO.AtkSpeedCurve.Evaluate(userManager.StatLevel.AtkSpeed.Value + 1), Managers.Data.LevelSO.AtkSpeedSO.AtkSpeedPriceCurve.Evaluate(userManager.StatLevel.AtkSpeed.Value + 1));
        critRateUpgradeUI.SetUpgradeUI(userManager.StatLevel.CritRate.Value, userManager.CurrentStat.CritRate.Value, Managers.Data.LevelSO.CritRateSO.CritRateCurve.Evaluate(userManager.StatLevel.CritRate.Value + 1), Managers.Data.LevelSO.CritRateSO.CritRatePriceCurve.Evaluate(userManager.StatLevel.CritRate.Value + 1));
        critDmgUpgradeUI.SetUpgradeUI(userManager.StatLevel.CritDmg.Value, userManager.CurrentStat.CritDmg.Value, Managers.Data.LevelSO.CritDmgSO.CritDmgCurve.Evaluate(userManager.StatLevel.CritDmg.Value + 1), Managers.Data.LevelSO.CritDmgSO.CritDmgPriceCurve.Evaluate(userManager.StatLevel.CritDmg.Value + 1));
        feverUpgradeUI.SetUpgradeUI(userManager.StatLevel.Fever.Value, userManager.CurrentStat.MaxFever.Value, Managers.Data.LevelSO.FeverSO.FeverCurve.Evaluate(userManager.StatLevel.Fever.Value + 1), Managers.Data.LevelSO.FeverSO.FeverPriceCurve.Evaluate(userManager.StatLevel.Fever.Value + 1));
        feverTimeUpgradeUI.SetUpgradeUI(userManager.StatLevel.FeverTime.Value, userManager.CurrentStat.FeverTime.Value, Managers.Data.LevelSO.FeverTimeSO.FeverTimeCurve.Evaluate(userManager.StatLevel.FeverTime.Value + 1), Managers.Data.LevelSO.FeverTimeSO.FeverTimePriceCurve.Evaluate(userManager.StatLevel.FeverTime.Value + 1));
    }

    public void OnUpgradeButtonClick(string statName)
    {
        int level;
        float currentStat, nextStat, cost;
        Keyframe lastKeyframe;

        switch(statName)
        {
            case "Atk":
                level = userManager.StatLevel.Atk.Value + 1;
                currentStat = userManager.CurrentStat.Atk.Value;
                lastKeyframe = Managers.Data.LevelSO.AtkSO.AtkCurve[Managers.Data.LevelSO.AtkSO.AtkCurve.length - 1];

                if(level > lastKeyframe.time) return;

                nextStat = Managers.Data.LevelSO.AtkSO.AtkCurve.Evaluate(level);
                cost = Managers.Data.LevelSO.AtkSO.AtkPriceCurve.Evaluate(level);
                if(userManager.Currency.Coin.Value >= (int)cost)
                {
                    userManager.Currency.Coin.Value -= (int)cost;
                    userManager.StatLevel.Atk.Value++;
                    atkUpgradeUI.SetUpgradeUI(level, currentStat, nextStat, cost);
                }
                break;
            case "AtkSpeed":
                level = userManager.StatLevel.AtkSpeed.Value + 1;
                currentStat = userManager.CurrentStat.AtkSpeed.Value;

                lastKeyframe = Managers.Data.LevelSO.AtkSpeedSO.AtkSpeedCurve[Managers.Data.LevelSO.AtkSpeedSO.AtkSpeedCurve.length - 1];
                if(level > lastKeyframe.time) return;

                nextStat = Managers.Data.LevelSO.AtkSpeedSO.AtkSpeedCurve.Evaluate(level);
                cost = Managers.Data.LevelSO.AtkSpeedSO.AtkSpeedPriceCurve.Evaluate(level);
                if(userManager.Currency.Coin.Value >= (int)cost)
                {
                    userManager.Currency.Coin.Value -= (int)cost;
                    userManager.StatLevel.AtkSpeed.Value++;
                    atkSpeedUpgradeUI.SetUpgradeUI(level, currentStat, nextStat, cost);
                }
                break;
            case "CritRate":
                level = userManager.StatLevel.CritRate.Value + 1;
                currentStat = userManager.CurrentStat.CritRate.Value;

                lastKeyframe = Managers.Data.LevelSO.CritRateSO.CritRateCurve[Managers.Data.LevelSO.CritRateSO.CritRateCurve.length - 1];
                if(level > lastKeyframe.time) return;

                nextStat = Managers.Data.LevelSO.CritRateSO.CritRateCurve.Evaluate(level);
                cost = Managers.Data.LevelSO.CritRateSO.CritRatePriceCurve.Evaluate(level);
                if(userManager.Currency.Coin.Value >= (int)cost)
                {
                    userManager.Currency.Coin.Value -= (int)cost;
                    userManager.StatLevel.CritRate.Value++;
                    critRateUpgradeUI.SetUpgradeUI(level, currentStat, nextStat, cost);
                }
                break;
            case "CritDmg":
                level = userManager.StatLevel.CritDmg.Value + 1;
                currentStat = userManager.CurrentStat.CritDmg.Value;

                lastKeyframe = Managers.Data.LevelSO.CritDmgSO.CritDmgCurve[Managers.Data.LevelSO.CritDmgSO.CritDmgCurve.length - 1];
                if(level > lastKeyframe.time) return;

                nextStat = Managers.Data.LevelSO.CritDmgSO.CritDmgCurve.Evaluate(level);
                cost = Managers.Data.LevelSO.CritDmgSO.CritDmgPriceCurve.Evaluate(level);
                if(userManager.Currency.Coin.Value >= (int)cost)
                {
                    userManager.Currency.Coin.Value -= (int)cost;
                    userManager.StatLevel.CritDmg.Value++;
                    critDmgUpgradeUI.SetUpgradeUI(level, currentStat, nextStat, cost);
                }
                break;
            case "Fever":
                level = userManager.StatLevel.Fever.Value + 1;
                currentStat = userManager.CurrentStat.MaxFever.Value;

                lastKeyframe = Managers.Data.LevelSO.FeverSO.FeverCurve[Managers.Data.LevelSO.FeverSO.FeverCurve.length - 1];
                if(level > lastKeyframe.time) return;

                nextStat = Managers.Data.LevelSO.FeverSO.FeverCurve.Evaluate(level);
                cost = Managers.Data.LevelSO.FeverSO.FeverPriceCurve.Evaluate(level);
                if(userManager.Currency.Coin.Value >= (int)cost)
                {
                    userManager.Currency.Coin.Value -= (int)cost;
                    userManager.StatLevel.Fever.Value++;
                    feverUpgradeUI.SetUpgradeUI(level, currentStat, nextStat, cost);
                }
                break;
            case "FeverTime":
                level = userManager.StatLevel.FeverTime.Value + 1;
                currentStat = userManager.CurrentStat.FeverTime.Value;

                lastKeyframe = Managers.Data.LevelSO.FeverTimeSO.FeverTimeCurve[Managers.Data.LevelSO.FeverTimeSO.FeverTimeCurve.length - 1];
                if(level > lastKeyframe.time) return;

                nextStat = Managers.Data.LevelSO.FeverTimeSO.FeverTimeCurve.Evaluate(level);
                cost = Managers.Data.LevelSO.FeverTimeSO.FeverTimePriceCurve.Evaluate(level);
                if(userManager.Currency.Coin.Value >= (int)cost)
                {
                    userManager.Currency.Coin.Value -= (int)cost;
                    userManager.StatLevel.FeverTime.Value++;
                    feverTimeUpgradeUI.SetUpgradeUI(level, currentStat, nextStat, cost);
                }
                break;
        }
    }
}
