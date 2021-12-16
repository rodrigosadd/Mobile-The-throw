using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Instance")]
    public static AudioManager instance;

    [Header("Events")]
    public UnityEvent onStart;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        onStart?.Invoke();
    }

    void SetSoundConfigs(Sound sound)
    {
        sound.source = gameObject.AddComponent<AudioSource>();
        sound.source.clip = sound.clip;
        sound.source.volume = sound.volume;
        sound.source.pitch = sound.pitch;
        sound.source.loop = sound.loop;
    }

    public void Play(Sound sound)
    {
        if (sound == null)
        {
            Debug.LogWarning("Sound not found!");
            return;
        }

        SetSoundConfigs(sound);
        sound.source.Play();
    }
}
