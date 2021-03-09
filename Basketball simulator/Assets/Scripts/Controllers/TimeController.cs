using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{   
    [Header("Timer variables")]
    public float gameplayTime;
    public float gameMinutes;
    public float timeDeactiveCountdownToStart;
    public bool canStartGame;
    public bool endGame;
    private float _countdownToStart;

    void Update()
    {
        GameplayTime();
        CheckEndGame();
        CountdownToStart();
    }

    void GameplayTime()
    {
        if(!endGame && canStartGame)
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

    public void ResetValues()
    {
        Time.timeScale = 1;
        endGame = false; 
        gameplayTime = 0;
        canStartGame = false;       
    }

        void CountdownToStart()
    {
        if(!canStartGame)
        {
            if(_countdownToStart < 1)
            {           
                if(!GameManager.GetUI().countdownToStartText.activeSelf)
                {
                    GameManager.GetUI().countdownToStartText.SetActive(true);
                }

                _countdownToStart += Time.deltaTime / timeDeactiveCountdownToStart;
            }
            else
            {
                _countdownToStart = 0;
                GameManager.GetUI().countdownToStartText.SetActive(false);
                canStartGame = true;
            }        
        }
    }
}