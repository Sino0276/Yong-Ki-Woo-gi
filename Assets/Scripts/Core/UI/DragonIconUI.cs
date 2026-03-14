using System;
using UnityEngine;
using UnityEngine.UI;

public class DragonIconUI : MonoBehaviour
{
    [SerializeField] private Image iconImage;
    [field: SerializeField] public Button Button { get; private set; }

    public void SetUpIcon(Sprite sprite)
    {
        iconImage.sprite = sprite;
        iconImage.SetNativeSize();
    }
}
