using UnityEngine;
using UnityEngine.UI;

public class DragonIconUI : MonoBehaviour
{
    [SerializeField] private Image iconImage;

    public void SetUpIcon(Sprite sprite)
    {
        iconImage.sprite = sprite;
        iconImage.SetNativeSize();
    }
}
