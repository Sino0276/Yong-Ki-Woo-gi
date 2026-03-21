using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DragonLibraryUI : BaseUI
{
    private DragonIconUI dragonIconPrefab;
    [SerializeField] private Transform content;
    [SerializeField] private DragonDescriptionUI dragonDescriptionUI;
    [SerializeField] private DragonStatDescriptionUI dragonStatDescriptionUI;

    public void Start()
    {
        dragonIconPrefab = Managers.Resource.Load<DragonIconUI>("UI/DragonIcon");
        SetUp();
    }

    public void SetUp()
    {
        foreach(var dragon in Managers.Data.DragonData.ItemsList)
        {
            DragonIconUI dragonIcon = Instantiate(dragonIconPrefab, content);
            dragonIcon.SetUpIcon(dragon.key);
            dragonIcon.Button.onClick.AddListener(() => AddClickEvent(dragon.key));
            Managers.User.Dragon.OnDragonListChange += (List<int> dragonList) => OnDragonListChange(dragonList, dragonIcon);
        }
    }

    private void AddClickEvent(int id)
    {
        dragonDescriptionUI.SetUpDescription(id);
        dragonStatDescriptionUI.SetUpStatDescription(id);
    }

    private void OnDragonListChange(List<int> dragonList, DragonIconUI ui)
    {
        ui.SetIconShadow(dragonList.Contains(ui.ID));
    }
}
