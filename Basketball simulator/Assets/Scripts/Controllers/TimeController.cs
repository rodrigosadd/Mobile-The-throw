using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{   
    [Header("Timer variables")]
    public float gameplayTime;
    public float gameMinutes;
    public bool canStartGame;
    public bool endGame;
    private float _countdownToStart;

    void Start()
    {
        ConvertToMinutes ();
    }

    void Update()
    {
        GamePlayTime();
        CheckEndGame();
        CountdownToStart();
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
                GameManager.GetUI().timeText.color = Color.red;
            }
            else
            {
                GameManager.GetUI().timeText.color = Color.white;
            }

            gameplayTime -= Time.deltaTime * 1;
        }
    }

    void CheckEndGame()
    {
        if(gameplayTime <= 0f)
        {             
            endGame = true;
            GameManager.GetPlayer().ball.transform.position =  GameManager.GetPlayer().transform.position;
            GameManager.GetPlayer().ball.ResetTrailValues();
        }
    }

    public void ResetValues()
    {
        endGame = false; 
        canStartGame = false;       
        ConvertToMinutes ();
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

                _countdownToStart += Time.deltaTime / 3.4f;
            }
            else
            {
                GameManager.GetAudio().Play("Start game");
                _countdownToStart = 0;
                GameManager.GetUI().countdownToStartText.SetActive(false);
                canStartGame = true;                
            }        
        }
    }
}