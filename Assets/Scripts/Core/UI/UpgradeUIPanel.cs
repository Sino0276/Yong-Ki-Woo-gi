using TMPro;
using UnityEngine;

public class UpgradeUIPanel : MonoBehaviour
{
    private UpgradeSystem upgradeSystem;

    public UpgradeUI atkUI;
    public UpgradeUI atkSpeedUI;
    public UpgradeUI critRateUI;
    public UpgradeUI critDmgUI;
    public UpgradeUI feverUI;
    public UpgradeUI feverTimeUI;

    private void Awake()
    {
        upgradeSystem = GetComponent<UpgradeSystem>();

        atkUI.SetUpgradeUI(Managers.UserData.statData.atkLevel, Managers.UserData.statData.atkLevel * 1.6f, 100 * upgradeSystem.LevelSO.DamageCurve.Evaluate(Managers.UserData.statData.atkLevel + 1));
        atkSpeedUI.SetUpgradeUI(Managers.UserData.statData.atkSpeedLevel, Managers.UserData.statData.atkSpeedLevel * 1.6f, 100 * upgradeSystem.LevelSO.AttackSpeedCurve.Evaluate(Managers.UserData.statData.atkSpeedLevel + 1));
        critRateUI.SetUpgradeUI(Managers.UserData.statData.critRateLevel, Managers.UserData.statData.critRateLevel * 1.5f, 100 * upgradeSystem.LevelSO.CriticalRateCurve.Evaluate(Managers.UserData.statData.critRateLevel + 1));
        critDmgUI.SetUpgradeUI(Managers.UserData.statData.critDmgLevel, Managers.UserData.statData.critDmgLevel * 3.5f, 100 * upgradeSystem.LevelSO.CriticalDamageCurve.Evaluate(Managers.UserData.statData.critDmgLevel + 1));
        feverUI.SetUpgradeUI(Managers.UserData.statData.feverLevel, Managers.UserData.statData.feverLevel * 1.5f, 100 * upgradeSystem.LevelSO.FeverCurve.Evaluate(Managers.UserData.statData.feverLevel + 1));
        feverTimeUI.SetUpgradeUI(Managers.UserData.statData.feverTimeLevel, Managers.UserData.statData.feverTimeLevel * 1.5f, 100 * upgradeSystem.LevelSO.FeverTimeCurve.Evaluate(Managers.UserData.statData.feverTimeLevel + 1));
    }

    private void Start()
    {
        atkUI.button.onClick.AddListener(() => Upgrade(StatType.Atk));
        atkSpeedUI.button.onClick.AddListener(() => Upgrade(StatType.AtkSpeed));
        critRateUI.button.onClick.AddListener(() => Upgrade(StatType.CritRate));
        critDmgUI.button.onClick.AddListener(() => Upgrade(StatType.CritDmg));
        feverUI.button.onClick.AddListener(() => Upgrade(StatType.Fever));
        feverTimeUI.button.onClick.AddListener(() => Upgrade(StatType.FeverTime));
    }

    private void Upgrade(StatType statType)
    {
        switch (statType)
        {
            case StatType.Atk:
                if(upgradeSystem.Upgrade(StatType.Atk))
                    atkUI.SetUpgradeUI(Managers.UserData.statData.atkLevel, Managers.UserData.statData.atkLevel * 1.6f, 100 * upgradeSystem.LevelSO.DamageCurve.Evaluate(Managers.UserData.statData.atkLevel + 1));
                break;
            case StatType.AtkSpeed:
                atkSpeedUI.SetUpgradeUI(Managers.UserData.statData.atkSpeedLevel, Managers.UserData.statData.atkSpeedLevel * 1.6f, 100 * upgradeSystem.LevelSO.AttackSpeedCurve.Evaluate(Managers.UserData.statData.atkSpeedLevel + 1));
                break;
            case StatType.CritRate: 
                if(upgradeSystem.Upgrade(StatType.CritRate))
                    critRateUI.SetUpgradeUI(Managers.UserData.statData.critRateLevel, Managers.UserData.statData.critRateLevel * 1.5f, 100 * upgradeSystem.LevelSO.CriticalRateCurve.Evaluate(Managers.UserData.statData.critRateLevel + 1));
                break;
            case StatType.CritDmg:
                if(upgradeSystem.Upgrade(StatType.CritDmg))
                    critDmgUI.SetUpgradeUI(Managers.UserData.statData.critDmgLevel, Managers.UserData.statData.critDmgLevel * 3.5f, 100 * upgradeSystem.LevelSO.CriticalDamageCurve.Evaluate(Managers.UserData.statData.critDmgLevel + 1));
                break;
            case StatType.Fever:
                if(upgradeSystem.Upgrade(StatType.Fever))
                    feverUI.SetUpgradeUI(Managers.UserData.statData.feverLevel, Managers.UserData.statData.feverLevel * 1.5f, 100 * upgradeSystem.LevelSO.FeverCurve.Evaluate(Managers.UserData.statData.feverLevel + 1));
                break;
            case StatType.FeverTime:
                if(upgradeSystem.Upgrade(StatType.FeverTime))
                    feverTimeUI.SetUpgradeUI(Managers.UserData.statData.feverTimeLevel, Managers.UserData.statData.feverTimeLevel * 1.5f, 100 * upgradeSystem.LevelSO.FeverTimeCurve.Evaluate(Managers.UserData.statData.feverTimeLevel + 1));
                break;
        }
    }
}
