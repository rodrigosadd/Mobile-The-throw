using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
     [Header("Audio Instance")]
    public static AudioManager instance;
    public Sound[] sounds;

    void Awake()
    {
        instance = this;
        SetSounds();
    }

    void Start()
    {
        Play("Theme");
    }

    void SetSounds()
    {
        foreach(Sound sound in  sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
            sound.source.loop = sound.loop;
        }
    }

    //Procura dentro do array de sons o nome do som passado por parâmetro e toca ele
    public void Play(string name)
    {
        Sound sound = Array.Find(sounds, sound => sound.name == name);

        if(sound == null)
        {
            Debug.LogWarning("Sound: " + name + " not found");
            return;
        }

        sound.source.Play();
    }
}
