using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Manager : MonoBehaviour
{
    private static Manager instance;
    
    // 입력 => 반환                      // if (instance == null) return null;
    public static Manager Instance => instance ?? null;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        
        instance = this; 
        DontDestroyOnLoad(this.gameObject); 
        
    }
}
