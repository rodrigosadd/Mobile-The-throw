using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{   
    [Header("Input variables")]
    public Slider angleSlider;
    public Slider throwingForceSlider;
    public Button throwingButton;

    [Header("In game variables")]
    public GameObject countdownToStartText;
    public Text scoreText;
    public Text timeText;
    public Text countBallThrowingText;
    public Text angleText;
    public Text addedTimeText;
    public bool canStartAddedTimeAnim;
    private float _countdownAddedTime;

    [Header("End game variables")]
    public GameObject endGamePanel;
    public Text finalScoreText;
    public Text amountBallThrowingText;
    public Button menuButton;
    public Button playAgainButton;

    [Header("Events")]
    public UnityEvent onBallThrowing;
    public UnityEvent onSetEndGame;

    void Start()
    {
        InitializeListerners();        
        SetupUIValues();        
    }

    void Update()
    {
        SetScore();
        SetGameplayTime();
        SetEndGame();
        ActiveAddedTimeAnim();
    }

    //Define os valores máximos e mínimos da UI
    void SetupUIValues ()
    {
        throwingForceSlider.minValue = 1;
        throwingForceSlider.maxValue = GameManager.GetPlayer().maxThrowingForce;

        SetRotationValue(angleSlider.maxValue);
        angleSlider.value = angleSlider.maxValue;
    }

     //Inicializa os Listerners da UI
    void InitializeListerners()
    {
        angleSlider.onValueChanged.AddListener(SetRotationValue);
        throwingForceSlider.onValueChanged.AddListener(SetThrowingForce);
        throwingButton.onClick.AddListener(BallThrowing);
        menuButton.onClick.AddListener(LoadMenuScene);
        playAgainButton.onClick.AddListener(PlayAgain);                
    }

    //Define o arremesso da bola, soma a quantidade de jogadas na UI e toca o som de arremesso
    void BallThrowing()
    {
        if(!GameManager.GetTime().endGame && GameManager.GetTime().canStartGame)
        {
            if(!GameManager.GetPlayer().ball.canStartTrail)
            {
                GameManager.GetPlayer().amountThrowing++;
                countBallThrowingText.text = GameManager.GetPlayer().amountThrowing.ToString();
                GameManager.GetPlayer().SetBallDirection();
                //AudioManager.instance.Play("Throwing");
                onBallThrowing?.Invoke();
            }
        }
    }

    //Define a força de arremeso na UI e no player
    public void SetThrowingForce(float value)
    {
        throwingForceSlider.value = value;        
        GameManager.GetPlayer().currentThrowingForce = value;
    }

    //Define a rotação do player na UI e no player
    public void SetRotationValue(float value)
    {
        angleText.text = (value * -1).ToString("0º");
        GameManager.GetPlayer().SetRotation(value);
    }

    //Define os valores de ponto do jogador na UI
    void SetScore()
    {
        if(scoreText.text != GameManager.GetPlayer().score.ToString() &&
           !GameManager.GetTime().endGame)
        {
            scoreText.text = GameManager.GetPlayer().score.ToString();
        }
    }   

    //Define o valor de tempo na UI
    void SetGameplayTime()
    {
        timeText.text = GameManager.GetTime().gameplayTime.ToString("00.0");
    }

    //Ativa o painel de fim de jogo, toca o som de fim de jogo e 
    //define os valores de quantidade de arremesos e de quantidade de pontos no painel de fim de jogo 
    void SetEndGame()
    {
        if(GameManager.GetTime().endGame && !endGamePanel.activeSelf)
        {
            //AudioManager.instance.Play("Finish game");
            onSetEndGame?.Invoke();
            endGamePanel.SetActive(true);
            finalScoreText.text = GameManager.GetPlayer().score.ToString();
            amountBallThrowingText.text = GameManager.GetPlayer().amountThrowing.ToString();
        }        
    }

    void LoadMenuScene()
    {
        GameManager.instance.ResetAll();
        SceneManager.LoadScene(0);
    }

    //Reinicia o jogo 
    void PlayAgain()
    {
        GameManager.instance.ResetAll();      
    }

    //Apenas para dar o tempo necessário para tocar a animação de adicinar tempo
    //e evitar que ela sejá tocada em loop
    void ActiveAddedTimeAnim()
    {
        if(canStartAddedTimeAnim)
        {
            if(_countdownAddedTime < 1)
            {           
                if(!addedTimeText.gameObject.activeSelf)
                {
                    addedTimeText.gameObject.SetActive(true);
                }

                _countdownAddedTime += Time.deltaTime / 1f;
            }
            else
            {
                _countdownAddedTime = 0;
                addedTimeText.gameObject.SetActive(false);                
                canStartAddedTimeAnim = false;
            }        
        }
    }

    //Apenas para facilitar a redefinição dos valores da UI
    public void ResetUIValues()
    {
        scoreText.text = 0.ToString();        
        countBallThrowingText.text = 0.ToString(); 
        throwingForceSlider.value = 1;    
        angleSlider.value = angleSlider.maxValue;
        timeText.color = Color.white;           
    }
}