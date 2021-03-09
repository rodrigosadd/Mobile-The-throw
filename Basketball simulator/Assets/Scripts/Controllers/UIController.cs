using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{   
    public GameObject endGamePanel;
    public Slider angleSlider;
    public Slider throwingForceSlider;
    public Button throwingButton;
    public Text scoreText;
    public Text timeText;
    public Text countBallThrowingText;
    public Text angleText;
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
        throwingForceSlider.maxValue = PlayerController.instance.maxThrowingForce;

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
        if(!TimeController.instance.endGame)
        {
            PlayerController.instance.amountThrowing++;
            countBallThrowingText.text = PlayerController.instance.amountThrowing.ToString();
            PlayerController.instance.SetBallDirection();
        }
    }

    public void SetThrowingForce(float value)
    {
        throwingForceSlider.value = value;        
        PlayerController.instance.currentThrowingForce = value;
    }

    public void SetRotationValue(float value)
    {
        angleText.text = value.ToString("0º");
        PlayerController.instance.SetRotation(value);
    }

    void SetScore()
    {
        if(scoreText.text != PlayerController.instance.score.ToString() &&
           !TimeController.instance.endGame)
        {
            scoreText.text = PlayerController.instance.score.ToString();
        }
    }   

    void SetGameplayTime()
    {
        timeText.text = TimeController.instance.gameplayTime.ToString("00.0");
    }

    void SetEndGame()
    {
        if(TimeController.instance.endGame)
        {
            endGamePanel.SetActive(true);
        }        
    }

    void LoadMenuScene()
    {
         SceneManager.LoadScene(0);
    }
    void PlayAgain()
    {
        ResetUIValues();
        PlayerController.instance.ResetValues();
        TimeController.instance.ResetTime();
        ScoreController.instance.ResetPositionHood();
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
}