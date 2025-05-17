using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Managers : Singleton<Managers>
{
    [SerializeField] private PoolManager poolManager = new PoolManager();
    [SerializeField] private SoundManager soundManager = new SoundManager();
    [SerializeField] private UIManager uiManager = new UIManager();
    [SerializeField] public ResourceManager resourceManager = new ResourceManager();

    public static PoolManager Pool => Instance.poolManager;
    public static SoundManager Sound => Instance.soundManager;
    public static UIManager UI => Instance.uiManager;
    public static ResourceManager Resource => Instance.resourceManager;

    protected override void Awake()
    {
        base.Awake();
    }
}

[Serializable]
public class PoolManager
{
    public void Init()
    {

    }
}

public class UIManager
{

}

public class DataManager
{

}
