using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI atk;
    [SerializeField] private TextMeshProUGUI atkSpeed;
    [SerializeField] private TextMeshProUGUI critRate;
    [SerializeField] private TextMeshProUGUI critDmg;
    [SerializeField] private TextMeshProUGUI fever;
    [SerializeField] private TextMeshProUGUI feverTime;

    private void Start()
    {
        Managers.User.CurrentStat.OnAtkChange += OnAtkChange;
        Managers.User.CurrentStat.OnAtkSpeedChange += OnAtkSpeedChange;
        Managers.User.CurrentStat.OnCritRateChange += OnCritRateChange;
        Managers.User.CurrentStat.OnCritDmgChange += OnCritDmgChange;
        Managers.User.CurrentStat.OnFeverChange += OnFeverChange;
        Managers.User.CurrentStat.OnFeverTimeChange += OnFeverTimeChange;
        
        Managers.User.CurrentStat.CalculateStat();
    }

    private void OnAtkChange(float arg1, float arg2)
    {
        atk.text = "공격력: " + arg1.ToString().ToKoreanUnitString() + " + " + arg2.ToString().ToKoreanUnitString();
    }

    private void OnAtkSpeedChange(float arg1, float arg2)
    {
        atkSpeed.text = "공격속도: " + arg1.ToString().ToKoreanUnitString() + " + " + arg2.ToString().ToKoreanUnitString();
    }

    private void OnCritRateChange(float arg1, float arg2)
    {
        critRate.text = "치명타 확률: " + arg1.ToString().ToKoreanUnitString() + " + " + arg2.ToString().ToKoreanUnitString();
    }

    private void OnCritDmgChange(float arg1, float arg2)
    {
        critDmg.text = "치명타 대미지: " +  arg1.ToString().ToKoreanUnitString() + " + " + arg2.ToString().ToKoreanUnitString();    
    }

    private void OnFeverChange(float arg1, float arg2)
    {
        fever.text = "폭주 필요 터치: " + arg1 + " + " + arg2.ToString().ToKoreanUnitString() +  " + " + arg2.ToString().ToKoreanUnitString();
    }

    private void OnFeverTimeChange(float arg1, float arg2)
    {
        feverTime.text = "폭주 시간: " + arg1.ToString().ToKoreanUnitString() +  " + " + arg2.ToString().ToKoreanUnitString();
    }
}
