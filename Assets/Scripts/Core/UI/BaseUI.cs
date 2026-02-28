using UnityEngine;

public abstract class BaseUI : MonoBehaviour
{
    public virtual void ToggleUI()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }
}