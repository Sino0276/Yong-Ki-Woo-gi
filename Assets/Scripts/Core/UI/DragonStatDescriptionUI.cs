using System.Linq;
using TMPro;
using UnityEngine;

public class DragonStatDescriptionUI : MonoBehaviour
{
    [SerializeField] private Transform content;
    [SerializeField] private TextMeshProUGUI textMeshProUGUIPrefab;

    public void Start()
    {
        SetUpStatDescription(16);
    }

    public void SetUpStatDescription(int id)
    {
        ResetDescription();
        GameInfo_DragonsData dragonData = Managers.Data.DragonData.GetByKey(id);
        CreateStatDescription(dragonData);
    }

    private void ResetDescription()
    {
        while(content.childCount != 0) 
        {
            Destroy(content.GetChild(0));
        }
    }

    private void CreateStatDescription(GameInfo_DragonsData data)
    {
        if(data.damage != 1) CreateTextUI($"공격력 {(data.damage - 1) * 100}% 증가");
        if(data.atkSpeed != 0) CreateTextUI($"공속 {data.atkSpeed} 증가");
        if(data.critRate != 1) CreateTextUI($"크리율 {(data.critRate - 1) * 100}% 증가");
        if(data.minCritDmg != 1 || data.maxCritDmg != 1) CreateTextUI($"크리데미지 {(data.minCritDmg - 1) * 100}~{(data.maxCritDmg - 1) * 100}% 증가");
        if(data.fever != 0) CreateTextUI($"분노 게이지 필요 터치 {data.fever}회 감소");
        if(data.feverTime != 0) CreateTextUI($"분노 지속 시간 {data.feverTime}초 증가");
    }

    private void CreateTextUI(string text)
    {
        TextMeshProUGUI textUI = Instantiate(textMeshProUGUIPrefab, content);
        textUI.text = text;
    }
}
