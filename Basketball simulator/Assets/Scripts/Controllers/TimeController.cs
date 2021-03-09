using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{   
    public static TimeController instance;
    public float gameplayTime;
    public float gameMinutes;
    public bool endGame;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        GameplayTime();
        CheckEndGame();
    }

    void GameplayTime()
    {
        if(!endGame)
        {
            gameplayTime += Time.deltaTime * 1;
        }
    }

    void CheckEndGame()
    {
        if(gameplayTime >= gameMinutes * 60)
        {
            endGame = true; 
            EndGame();
        }
    }

    void EndGame()
    {         
        Time.timeScale = 0;
    }

    public void ResetTime()
    {
        Time.timeScale = 1;
        endGame = false; 
        gameplayTime = 0;
    }
}