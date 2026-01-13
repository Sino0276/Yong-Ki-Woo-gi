using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;

    public static T Instance => instance ?? null;

    [SerializeField] private bool isDontDestroyOnLoad = true;

    protected virtual void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        
        instance = this as T;
        if(isDontDestroyOnLoad) DontDestroyOnLoad(this.gameObject);
    }
}