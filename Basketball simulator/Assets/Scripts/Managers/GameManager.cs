using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : StateMachine
{
    public static GameManager instance;

    [Header("Player Instance")]
    [SerializeField] private PlayerController _playerInstance;

    [Header("UI Instance")]
    [SerializeField] private UIController _uiInstance;

    [Header("Pool System Instance")]
    [SerializeField] private PoolSystem _poolSystemInstance;

    [Header("Audio Manager Instance")]
    [SerializeField] private AudioManager _audioInstance;
    
    [Header("Time Controller Instance")]
    [SerializeField] private TimeController _timeInstance;

    State state;

    void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        SetState(new Begin());
    }

    #region Instances
    public static PlayerController GetPlayer()
    {
        return instance._playerInstance;
    }

    public static UIController GetUI()
    {
        return instance._uiInstance;
    }

    public static PoolSystem GetPoolSystem()
    {
        return instance._poolSystemInstance;
    }

    public static AudioManager GetAudioManager()
    {
        return instance._audioInstance;
    }
    
    public static TimeController GetTime()
    {
        return instance._timeInstance;
    }
    #endregion

    #region States
    public void OnThrowingButton()
    {
        currentState.Throwing();
    }
    #endregion

    public void ResetAll()
    {
        GetUI().ResetValues();
        GetPlayer().ResetValues();
        GetTime().ResetValues();
    }
}