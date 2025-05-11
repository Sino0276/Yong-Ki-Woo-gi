using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Managers : Singleton<Managers>
{
    [SerializeField] private PoolManager poolManager;
    [SerializeField] private SoundManager soundManager;
    [SerializeField] private UIManager uiManager;
    [SerializeField] public ResourceManager resourceManager;

    public static PoolManager Pool => Instance.poolManager;
    public static SoundManager Sound => Instance.soundManager;
    public static UIManager UI => Instance.uiManager;
    public static ResourceManager Resource => Instance.resourceManager;

    protected override void Awake()
    {
        base.Awake();

        Init();
    }

    private void Init()
    {
        Pool.Init();
        resourceManager = GetComponentInChildren<ResourceManager>();
    }
}

[Serializable]
public class PoolManager
{
    public void Init()
    {

    }
}

public class SoundManager
{
    public SFX SFX { get; private set; }
    public AmbientSound AmbientSound { get; private set; }
    public BGM BGM { get; private set; }

    public float volume { get; private set; }
}

public class SFX
{
    public AudioSource AudioSource { get; private set; }
    public float Volume { get; private set; }

    public void PlaySound(AudioClip clip, Vector3 pos)
    {
        AudioSource.transform.position = pos;
        AudioSource.PlayOneShot(clip);
    }

    public void SetVolume(float volume)
    {
        AudioSource.volume = volume;
        Volume = volume;
    }
}

public class AmbientSound
{
    public void PlaySound(AudioClip clip)
    {

    }
}

public class BGM
{
    public float Volume { get; private set; }
    public AudioSource AudioSource { get; private set; }

    public void Play(AudioClip clip)
    {
        AudioSource.loop = true;
        AudioSource.clip = clip;
        AudioSource.Play();
    }

    public void SetVolume(float volume)
    {
        AudioSource.volume = volume;
        Volume = volume;
    }
}

public class UIManager
{

}

public class DataManager
{

}
