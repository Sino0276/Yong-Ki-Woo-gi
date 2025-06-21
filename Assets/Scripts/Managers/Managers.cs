using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;


// Manager관리 클래스
public class Managers : Singleton<Managers>
{
    [SerializeField] private PoolManager poolManager = new PoolManager();
    [SerializeField] private SoundManager soundManager = new SoundManager();
    [SerializeField] private UIManager uiManager = new UIManager();
    [SerializeField] private ResourceManager resourceManager = new ResourceManager();
    [SerializeField] private DataManager dataManager = new DataManager();
    [FormerlySerializedAs("userDataManager")] [SerializeField] private UserDataManager userData = new UserDataManager();

    public static PoolManager Pool => Instance.poolManager;
    public static SoundManager Sound => Instance.soundManager;
    public static UIManager UI => Instance.uiManager;
    public static ResourceManager Resource => Instance.resourceManager;
    public static DataManager Data => Instance.dataManager;
    public static UserDataManager UserData => Instance.userData;

    protected override void Awake()
    {
        Init();
    }

    private void Init()
    {
        dataManager.Init();
        Load();
    }
    
    [ContextMenu("Save")]
    public void Save()
    {
        PlayerPrefs.SetString("UserData", JsonUtility.ToJson(this));
    }

    [ContextMenu("Load")]
    public void Load()
    {
        if (PlayerPrefs.HasKey("UserData"))
        {
            JsonUtility.FromJsonOverwrite(PlayerPrefs.GetString("UserData"), this);
        }
    }
}

