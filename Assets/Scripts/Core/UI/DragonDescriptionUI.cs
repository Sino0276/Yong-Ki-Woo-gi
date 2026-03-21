using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DragonDescriptionUI : MonoBehaviour
{
    [SerializeField] private DragonIconUI dragonIconUI;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private TextMeshProUGUI dropRateText;

    public void SetUpDescription(int id)
    {
        GameInfo_DragonsData dragonData = Managers.Data.DragonData.GetByKey(id);
        dragonIconUI.SetUpIcon(id);
        nameText.text = dragonData.name;
        descriptionText.text = dragonData.description;
        dropRateText.text = $"보스 처치 시 {CalculateDropRate(id)}% 확률로 획득할 수 있습니다.";
    }

    private float CalculateDropRate(int id)
    {
        float dropRate = Managers.Data.DragonData.GetByKey(id).drop;
        List<GameInfo_DragonsData> dragonDataList = Managers.Data.DragonData.ItemsList;

        for(int i = 2; i < id; i++)
        {
            dropRate *= dragonDataList[i].drop;
        }

        return dropRate * 100f;
    }

    public void UseDragon()
    {
        if (Managers.User.Dragon.DragonList.Contains(dragonIconUI.ID))
            GameManager.Instance.SpawnDragon(dragonIconUI.ID);
        else
            Debug.Log($"ID:{dragonIconUI.ID} 용을 가지고 있지 않습니다.");
    }
}
