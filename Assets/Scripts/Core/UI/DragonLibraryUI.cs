using UnityEngine;

public class DragonLibraryUI : MonoBehaviour
{
    private DragonIconUI dragonIconPrefab;
    [SerializeField] private Transform content;

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
            dragonIcon.SetUpIcon(Managers.Resource.Load<Sprite>(dragon.iconPath));
        }
    }
}
