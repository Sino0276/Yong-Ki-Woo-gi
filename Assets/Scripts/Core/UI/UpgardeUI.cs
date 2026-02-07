using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeUI : MonoBehaviour
{
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI statText;
    public TextMeshProUGUI costText;

    public Button button;

    public void SetUpgradeUI(int level, float currentStat, float nextStat, float cost)
    {
        levelText.text = level.ToString();
        statText.text = $"{nextStat.ToKoreanUnitString()} (+{nextStat - currentStat})";
        costText.text = cost.ToKoreanUnitString() + "코인";
    }
}