using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    [Header("End game variables")]
    public GameObject endGamePanel;
    public Text finalScoreText;
    public Text amountBallThrowingText;
    public Button menuButton;
    public Button playAgainButton;
    public Button quitButton; 

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
    }

    void SetupUIValues ()
    {
        throwingForceSlider.minValue = 1;
        throwingForceSlider.maxValue = GameManager.GetPlayer().maxThrowingForce;

        SetRotationValue(angleSlider.maxValue);
        angleSlider.value = angleSlider.maxValue;
    }

    void InitializeListerners()
    {
        angleSlider.onValueChanged.AddListener(SetRotationValue);
        throwingForceSlider.onValueChanged.AddListener(SetThrowingForce);
        throwingButton.onClick.AddListener(BallThrowing);
        menuButton.onClick.AddListener(LoadMenuScene);
        playAgainButton.onClick.AddListener(PlayAgain);
        quitButton.onClick.AddListener(Quit);                    
    }

    void BallThrowing()
    {
        if(!GameManager.GetTime().endGame && GameManager.GetTime().canStartGame)
        {
            if(!GameManager.GetPlayer().ball.canStartTrail)
            {
                GameManager.GetPlayer().amountThrowing++;
                countBallThrowingText.text = GameManager.GetPlayer().amountThrowing.ToString();
                GameManager.GetPlayer().SetBallDirection();            
            }
        }
    }

    public void SetThrowingForce(float value)
    {
        throwingForceSlider.value = value;        
        GameManager.GetPlayer().currentThrowingForce = value;
    }

    public void SetRotationValue(float value)
    {
        angleText.text = value.ToString("0º");
        GameManager.GetPlayer().SetRotation(value);
    }

    void SetScore()
    {
        if(scoreText.text != GameManager.GetPlayer().score.ToString() &&
           !GameManager.GetTime().endGame)
        {
            scoreText.text = GameManager.GetPlayer().score.ToString();
        }
    }   

    void SetGameplayTime()
    {
        timeText.text = GameManager.GetTime().gameplayTime.ToString("00.0");
    }

    void SetEndGame()
    {
        if(GameManager.GetTime().endGame)
        {
            endGamePanel.SetActive(true);
            finalScoreText.text = GameManager.GetPlayer().score.ToString();
            amountBallThrowingText.text = GameManager.GetPlayer().amountThrowing.ToString();
        }        
    }

    void LoadMenuScene()
    {
        ResetAll();
        SceneManager.LoadScene(0);
    }
    void PlayAgain()
    {
        ResetAll();       
    }

    void Quit()
    {
        Debug.Log("Quit game!");
        Application.Quit();
    }

    void ResetUIValues()
    {
        scoreText.text = 0.ToString();        
        countBallThrowingText.text = 0.ToString(); 
        throwingForceSlider.value = 1;    
        angleSlider.value = angleSlider.maxValue;   
    }
    void ResetAll()
    {
        ResetUIValues();
        GameManager.GetPlayer().ResetValues();
        GameManager.GetTime().ResetValues();
        GameManager.GetPlayer().ball.ResetTrailValues();
    }
}