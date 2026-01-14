using System;
using UnityEngine;

[System.Serializable]
public class StatValue<T>
{
    [SerializeField] private T value;
    public T Value { get => value; set => SetValue(value); }
    public event Action<T, T> OnValueChange;

    public StatValue()
    {
        value = default(T);
    }

    public StatValue(T value)
    {
        this.value = value;
    }

    public void SetValue(T value)
    {
        T oldValue = this.value;
        this.value = value;
        OnValueChange?.Invoke(oldValue, this.value);
    }
}