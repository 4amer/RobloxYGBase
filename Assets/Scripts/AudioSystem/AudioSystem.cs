using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class AudioSystem : MonoBehaviour
{
    [SerializeField] private AudioSource _sfxAudio, _musicAudio;
    [SerializeField] private Sound[] _sfxSounds, _musicSounds;

    public static AudioSystem instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
        }
    }

    public void PlayMusic(AudioNames name)
    {
        Play(name, _musicAudio, _musicSounds);
    }

    public void PlaySFX(AudioNames name) 
    {
        Play(name, _sfxAudio, _sfxSounds);
    }

    public void MuteSFX(bool isMute)
    {
        _sfxAudio.mute = isMute;
    }

    public void MuteMusic(bool isMute)
    {
        _musicAudio.mute = isMute;
    }
    public void SFXVolume(float value)
    {
        _sfxAudio.volume = value;
    }

    public void MuteVolume(float value)
    {
        _musicAudio.volume = value;
    }

    private void Play(AudioNames name, AudioSource audioSource, Sound[] sounds)
    {
        Sound sound = Array.Find(sounds, x => x.Name == name);
        if (sound != null) 
        {
            audioSource.clip = sound.Clip;
            audioSource.Play();
        }
    }
}
