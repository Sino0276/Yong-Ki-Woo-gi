using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class DragonIconUI : MonoBehaviour
{
    [SerializeField] private Image iconImage;
    [field: SerializeField] public Button Button { get; private set; }
    public int ID { get; private set; }

    public void SetUpIcon(int id)
    {
        ID = id;
        GameInfo_DragonsData dragonData = Managers.Data.DragonData.GetByKey(id);
        iconImage.sprite = Managers.Resource.Load<Sprite>(dragonData.iconPath);
        iconImage.SetNativeSize();
        SetIconShadow(Managers.User.Dragon.DragonList.Contains(id));
    }

    public void SetIconShadow(bool isShadow)
    {
        iconImage.color = isShadow ? Color.white : Color.black;
    }
}
