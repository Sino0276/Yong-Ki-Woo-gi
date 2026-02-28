using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FeverUI : BaseUI
{
    [SerializeField] private Image fillImage;
    [SerializeField] private TextMeshProUGUI feverText;

    private StatValue<float> maxFever;
    private StatValue<float> currentFever;

    private void Start()
    {
        maxFever = Managers.User.CurrentStat.MaxFever;
        currentFever = Managers.User.CurrentStat.CurrentFever;

        currentFever.OnValueChange += UpdateUI;
        maxFever.OnValueChange += UpdateUI;
    }

    private void OnDestroy()
    {
        currentFever.OnValueChange -= UpdateUI;
        maxFever.OnValueChange -= UpdateUI;
    }

    private void UpdateUI(float oldValue, float newValue)
    {
        fillImage.fillAmount = currentFever.Value / maxFever.Value;
        feverText.text = currentFever.Value.ToString() + "/" + maxFever.Value.ToString();
    }
}