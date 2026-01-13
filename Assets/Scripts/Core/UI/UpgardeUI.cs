using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeUI : MonoBehaviour
{
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI statText;
    public TextMeshProUGUI costText;

    public Button button;

    public void SetUpgradeUI(int level, float stat, float cost)
    {
        levelText.text = level.ToString();
        statText.text = stat.ToString();
        costText.text = cost.ToString();
    }
}