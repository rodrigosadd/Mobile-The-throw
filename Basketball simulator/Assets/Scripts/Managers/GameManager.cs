using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : StateMachine
{
    public static GameManager instance;

    [Header("Player Instance")]
    [SerializeField] private PlayerController _playerInstance;

    [Header("Score Instance")]
    [SerializeField] private ScoreController _scoreInstance;

    [Header("Time Instance")]
    [SerializeField] private TimeController _timeInstance; 

    [Header("UI Instance")]
    [SerializeField] private UIController _uiInstance;

    [Header("Pool System Instance")]
    [SerializeField] private PoolSystem _poolSystemInstance;

    [Header("Audio Manager Instance")]
    [SerializeField] private AudioManager _audioInstance;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        SetState(new BeginState());
    }

    #region Instances
    public static PlayerController GetPlayer()
    {
        return instance._playerInstance;
    }

    public static ScoreController GetScore()
    {
        return instance._scoreInstance;
    }

    public static TimeController GetTime()
    {
        return instance._timeInstance;
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
    #endregion

    #region States Machine Methods 
    public void OnThrowing()
    {
        StartCoroutine(State.Throwing());
    }

    public void OnSetThrowingForce(float value)
    {
        StartCoroutine(State.SetThrowingForce(value));
    }
    public void OnSetVerticalRotation(float value)
    {
        StartCoroutine(State.SetVerticalRotation(value));
    }
    public void OnSetHorizontalRotation(float value)
    {
        StartCoroutine(State.SetHorizontalRotation(value));
    }
    public void OnMadeAPoint()
    {
        StartCoroutine(State.MadeAPoint());
    }
    #endregion

    public void ResetAll()
    {
        GetUI().ResetValues();
        GetPlayer().ResetValues();
        GetTime().ResetValues();
    }
}