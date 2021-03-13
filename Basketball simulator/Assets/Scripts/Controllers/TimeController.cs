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

    //Converte o valor de tempo de jogo para minutos
    void ConvertToMinutes()
    {
        gameplayTime = gameMinutes * 60;
    }

    //Adiciona tempo de jogo (Metodo usado sempre que o jogador marca um ponto)
    public void AddedTime(float time)
    {
        gameplayTime += time * 60;
        GameManager.GetUI().addedTimeText.text = (time * 60).ToString("00+");        
    }

    //Faz a contagem de tempo do jogo de forma decrescente 
    void GamePlayTime()
    {
        if(!endGame && canStartGame)
        {
            //Feedback de tempo se esgotando, colocando a cor da letra em vermelho
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

    //Verifica se o tempo de jogo e igual a 0 e se caso for o metodo define o fim de jogo
    void CheckEndGame()
    {
        if(gameplayTime <= 0f)
        {             
            endGame = true;
            GameManager.GetPlayer().ball.transform.position =  GameManager.GetPlayer().transform.position;
            GameManager.GetPlayer().ball.ResetTrailValues();
        }
    }

     //Apenas para facilitar a redefinição dos valores de tempo e de inicio/fim de jogo
    public void ResetValues()
    {
        endGame = false; 
        canStartGame = false;       
        ConvertToMinutes ();
    }

    //Faz com que o jogo inicie apenas depois da animação de inicio de jogo
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
                AudioManager.instance.Play("Start game");
                _countdownToStart = 0;
                GameManager.GetUI().countdownToStartText.SetActive(false);
                canStartGame = true;                
            }        
        }
    }
}