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
    [SerializeField] private UserData userData = new UserData();
    [SerializeField] private UtilityManager utilityManager = new UtilityManager();
    [SerializeField] private GameManager gameManager = new GameManager();

    public static PoolManager Pool => Instance.poolManager;
    public static SoundManager Sound => Instance.soundManager;
    public static UIManager UI => Instance.uiManager;
    public static ResourceManager Resource => Instance.resourceManager;
    public static DataManager Data => Instance.dataManager;
    public static UserData UserData => Instance.userData;
    public static UtilityManager Utility => Instance.utilityManager;
    public static GameManager Game => Instance.gameManager;

    protected override void Awake()
    {
        base.Awake();
        
        Init();
    }

    private void Init()
    {
        dataManager.Init();
        userData.Init();
        soundManager.Init();
        poolManager.Init();
        uiManager.Init();
        resourceManager.Init();
        utilityManager.Init();
        gameManager.Init();
    }
}

