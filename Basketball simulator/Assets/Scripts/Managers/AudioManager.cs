using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [Header("Audio variables")]
    public List<SoundSO> sounds;

    [Header("Events")]
    public UnityEvent onStart;

    void Awake()
    {
        SetSoundConfigs();
    }

    void Start()
    {
        onStart?.Invoke();
    }

    void SetSoundConfigs()
    {
        foreach (SoundSO sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
            sound.source.playOnAwake = sound.playOnAwake;
            sound.source.loop = sound.loop;
        }
    }

    public void Play(SoundSO sound)
    {
        if (sound == null)
        {
            Debug.LogWarning("Sound not found!");
            return;
        }
                
        sound.source.Play();
    }
}
