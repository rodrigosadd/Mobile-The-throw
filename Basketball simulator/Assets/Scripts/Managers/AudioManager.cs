using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AudioManager : MonoBehaviour
{
    [Header("Audio variables")]
    public List<SoundSO> sounds;
    public PlaySoundSO playSound;

    [Header("Events")]
    public UnityEvent onStart;

    void Awake()
    {
        SetSoundConfigs();
    }

    void OnEnable()
    {
        playSound.OnPlaySound += Play;
    }

    void OnDisable()
    {
        playSound.OnPlaySound -= Play;        
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

    void Play(SoundSO sound)
    {
        if (sound == null)
        {
            Debug.LogWarning("Sound not found!");
            return;
        }
                
        sound.source.Play();
    }
}
