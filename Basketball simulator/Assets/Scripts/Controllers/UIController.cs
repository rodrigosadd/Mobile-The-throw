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
    }

    void SetupUIValues ()
    {
        throwingForceSlider.minValue = 1;
        throwingForceSlider.maxValue = GameManager.GetPlayer().maxThrowingForce;

        SetRotationValue(-40f);
        angleSlider.value = -40f;
    }

    void InitializeListerners()
    {
        angleSlider.onValueChanged.AddListener(SetRotationValue);
        throwingForceSlider.onValueChanged.AddListener(SetThrowingForce);
        throwingButton.onClick.AddListener(BallThrowing);
        menuButton.onClick.AddListener(LoadMenuScene);
        playAgainButton.onClick.AddListener(PlayAgain);                
    }

    void BallThrowing()
    {
        if(!GameManager.GetTime().endGame && GameManager.GetTime().canStartGame)
        {
            GameManager.GetPlayer().amountThrowing++;
            countBallThrowingText.text = GameManager.GetPlayer().amountThrowing.ToString();
            GameManager.GetPlayer().SetBallDirection();
            onBallThrowing?.Invoke();
        }
    }

    public void SetThrowingForce(float value)
    {
        throwingForceSlider.value = value;        
        GameManager.GetPlayer().currentThrowingForce = value;
    }

    public void SetRotationValue(float value)
    {
        angleText.text = (value * -1).ToString("0º");
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
        if(GameManager.GetTime().endGame && !endGamePanel.activeSelf)
        {
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
 
    void PlayAgain()
    {
        GameManager.instance.ResetAll();      
    }

    public IEnumerator ActiveAddedTimeAnim()
    {
        addedTimeText.gameObject.SetActive(true);

        yield return new WaitForSeconds(1f);

        addedTimeText.gameObject.SetActive(false);                
    }

    public void ResetUIValues()
    {
        scoreText.text = 0.ToString();        
        countBallThrowingText.text = 0.ToString(); 
        throwingForceSlider.value = 1;    
        angleSlider.value = angleSlider.maxValue;
        timeText.color = Color.white;           
    }
}