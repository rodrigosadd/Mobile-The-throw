using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Player Instance")]
    public PlayerController playerInstance;

    [Header("Score Instance")]
    public ScoreController scoreInstance;

    [Header("Time Instance")]
    public TimeController timeInstance; 

    [Header("UI Instance")]
    public UIController uiInstance;
    
    [Header("Audio Instance")]
    public AudioController AudioInstance;
 
    void Awake()
    {
        instance = this;
    }

    public static PlayerController GetPlayer()
    {
        return instance.playerInstance;
    }

    public static ScoreController GetScore()
    {
        return instance.scoreInstance;
    }

    public static TimeController GetTime()
    {
        return instance.timeInstance;
    }

    public static UIController GetUI()
    {
        return instance.uiInstance;
    }

    public static AudioController GetAudio()
    {
        return instance.AudioInstance;
    }

    public void ResetAll()
    {
        GetUI().ResetUIValues();
        GetPlayer().ResetValues();
        GetPlayer().ball.ResetTrailValues();
        GetTime().ResetValues();
    }
}