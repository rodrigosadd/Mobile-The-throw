using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimeController : MonoBehaviour
{
    [Header("Timer variables")]
    public float timeToStart;
    public float gameplayTime;
    public float gameMinutes;
    public Color endTimeColor;
    public Color normalTimeColor;
    public bool canStartGame;
    public bool endGame;

    [Header("Events")]
    public UnityEvent onFinishCountdownToStart;

    void Start()
    {
        ConvertToMinutes(); 
    }

    void Update()
    {
        GamePlayTime();
        CheckEndGame();
    }

    void ConvertToMinutes()
    {
        gameplayTime = gameMinutes * 60;
    }

    public void AddedTime(float time)
    {
        gameplayTime += time * 60;
        GameManager.GetUI().addedTimeText.text = (time * 60).ToString("00+");        
    }

    void GamePlayTime()
    {
        if(!endGame && canStartGame)
        {
            if(gameplayTime < 10)
            {
                GameManager.GetUI().timeText.color = endTimeColor;
            }
            else
            {
                GameManager.GetUI().timeText.color = normalTimeColor;
            }

            gameplayTime -= Time.deltaTime * 1;
        }
    }

    void CheckEndGame()
    {
        if(gameplayTime <= 0f)
        {             
            endGame = true;            
        }
    }

    public void ResetValues()
    {
        endGame = false;
        canStartGame = false;
        ConvertToMinutes();        
    }
}