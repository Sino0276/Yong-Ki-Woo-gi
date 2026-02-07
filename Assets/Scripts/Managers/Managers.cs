using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


// Manager관리 클래스
public class Managers : Singleton<Managers>
{
    [SerializeField] private PoolManager poolManager = new PoolManager();
    [SerializeField] private SoundManager soundManager = new SoundManager();
    [SerializeField] private UIManager uiManager = new UIManager();
    [SerializeField] private ResourceManager resourceManager = new ResourceManager();
    [SerializeField] private DataManager dataManager = new DataManager();
    [SerializeField] private UtilityManager utilityManager = new UtilityManager();
    [SerializeField] private UserManager userManager = new UserManager();

    public static PoolManager Pool => Instance.poolManager;
    public static SoundManager Sound => Instance.soundManager;
    public static UIManager UI => Instance.uiManager;
    public static ResourceManager Resource => Instance.resourceManager;
    public static DataManager Data => Instance.dataManager;
    public static UtilityManager Utility => Instance.utilityManager;
    public static UserManager User => Instance.userManager;
    
    public bool isInitialized = false;
    public static bool IsInitialized => Instance.isInitialized;
    public static event Action OnInitialized;

    protected override void Awake()
    {
        base.Awake();
        
        Init();
    }

    public void Init()
    {
        dataManager.Init();
        soundManager.Init();
        poolManager.Init();
        uiManager.Init();
        resourceManager.Init();
        utilityManager.Init();
        userManager.Init();

        isInitialized = true;
        OnInitialized?.Invoke();
    }

    public new Coroutine StartCoroutine(IEnumerator coroutine)
    {
        return base.StartCoroutine(coroutine);
    }

    public new void StopCoroutine(IEnumerator coroutine)
    {
        base.StopCoroutine(coroutine);
    }

    [ContextMenu("Reset")]
    public void Reset() => userManager.Reset();
    
    [ContextMenu("Save")]
    public void Save() => userManager.Save();

    [ContextMenu("Load")]
    public void Load() => userManager.Load();
}

