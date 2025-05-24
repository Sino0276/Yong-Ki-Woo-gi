using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager
{
    [SerializeField] private AudioSource bgmSource;
    [SerializeField] private AudioSource sfxSource;

    private float bgmVolume = 1;
    private float sfxVolume = 1;

    private void Init()
    {

    }

    #region BGM
    public void SetBGM(AudioClip audioClip)
    {
        bgmSource.clip = audioClip;
    }

    public void SetBGM(string path)
    {
        AudioClip audioClip = Managers.Resource.Load<AudioClip>(path);
        SetBGM(audioClip);
    }

    public void PlayBGM()
    {
        bgmSource.Play();
    }

    public void StopBGM()
    {
        bgmSource.Stop();
    }

    public void PauseBGM()
    {
        bgmSource.Pause();
    }

    public void ResumeBGM()
    {
        bgmSource.UnPause();
    }

    public void SetBGMVolume(float volume)
    {
        bgmVolume = volume;
        bgmSource.volume = bgmVolume;
    }
    #endregion

    #region SFX
    public void PlaySFX(AudioClip audioClip, float volume = 1)
    {
        sfxSource.PlayOneShot(audioClip, volume);
    }

    public void PlaySFX(string path, float volume = 1)
    {
        AudioClip audioClip = Managers.Resource.Load<AudioClip>(path);
        PlaySFX(audioClip, volume);
    }

    public void SetSFXVolume(float volume)
    {
        sfxVolume = volume;
        sfxSource.volume = sfxVolume;
    }
    #endregion
}
