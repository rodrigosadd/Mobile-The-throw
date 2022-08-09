using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
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

    void Awake()
    {
        instance = this;
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
    #endregion

    public void ResetAll()
    {
        GetUI().ResetValues();
        GetPlayer().ResetValues();
    }
}