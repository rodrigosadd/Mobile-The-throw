using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{   
    [Header("Input variables")]
    public Slider verticalAngleSlider;
    public Slider horizontalAngleSlider;
    public Slider throwingForceSlider;
    public Button throwingButton;

    [Header("In game variables")]
    public GameObject countdownToStartText;
    public Text scoreText;
    public Text countBallThrowingText;
    public Text verticalAngleText;
    public Text horizontalAngleText;

    [Header("End game variables")]
    public GameObject endGamePanel;
    public Text finalScoreText;
    public Text amountBallThrowingText;
    public Button menuButton;
    public Button playAgainButton;

    void Start()
    {
        InitializeListerners();        
        SetupUIValues();        
    }

    void SetupUIValues ()
    {
        throwingForceSlider.minValue = 0f;
        throwingForceSlider.maxValue = GameManager.GetPlayer().maxThrowingForce;
        scoreText.text = GameManager.GetPlayer().initialScore.ToString();
        countBallThrowingText.text = GameManager.GetPlayer().initialAmountThrowing.ToString();
    }

    void InitializeListerners()
    {
        verticalAngleSlider.onValueChanged.AddListener(GameManager.GetPlayer().SetVerticalRotation);
        horizontalAngleSlider.onValueChanged.AddListener(GameManager.GetPlayer().SetHorizontalRotation);
        throwingForceSlider.onValueChanged.AddListener(GameManager.GetPlayer().SetThrowingForce);
        throwingButton.onClick.AddListener(GameManager.GetPlayer().SetBallDirection);
        menuButton.onClick.AddListener(LoadMenuScene);
        playAgainButton.onClick.AddListener(PlayAgain);                
    }

    public void SetScore()
    {
        if(scoreText.text != GameManager.GetPlayer().score.ToString())
        {
            scoreText.text = GameManager.GetPlayer().score.ToString();
        }
    }   

    void SetEndGame()
    {
        if(!endGamePanel.activeSelf)
        {
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
 
    void PlayAgain()
    {
        GameManager.instance.ResetAll();
    }

    public void ResetValues()
    {
        scoreText.text = GameManager.GetPlayer().initialScore.ToString();        
        countBallThrowingText.text = GameManager.GetPlayer().initialAmountThrowing.ToString(); 
        throwingForceSlider.value = 0f;    
        verticalAngleSlider.value = GameManager.GetPlayer().initialVerticalRotationValue;          
    }
}