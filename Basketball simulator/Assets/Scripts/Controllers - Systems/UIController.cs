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
    public Text timeText;
    public Text countBallThrowingText;
    public Text verticalAngleText;
    public Text horizontalAngleText;
    public Text addedTimeText;
    public Color initialTimeColor;
    public float timeToDeactivateAddedTimeAnim;

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
        SetGameplayTime();
        SetEndGame();
    }

    void SetupUIValues ()
    {
        throwingForceSlider.minValue = 0f;
        throwingForceSlider.maxValue = GameManager.GetPlayer().maxThrowingForce;

        GameManager.instance.OnSetVerticalRotation(GameManager.GetPlayer().initialVerticalRotationValue);
        verticalAngleSlider.value = GameManager.GetPlayer().initialVerticalRotationValue;

        GameManager.instance.OnSetHorizontalRotation(GameManager.GetPlayer().initialHorizontalRotationValue);
        horizontalAngleSlider.value = GameManager.GetPlayer().initialHorizontalRotationValue;

        scoreText.text = GameManager.GetPlayer().initialScore.ToString();

        countBallThrowingText.text = GameManager.GetPlayer().initialAmountThrowing.ToString();
    }

    void InitializeListerners()
    {
        verticalAngleSlider.onValueChanged.AddListener(GameManager.instance.OnSetVerticalRotation);
        horizontalAngleSlider.onValueChanged.AddListener(GameManager.instance.OnSetHorizontalRotation);
        throwingForceSlider.onValueChanged.AddListener(GameManager.instance.OnSetThrowingForce);
        throwingButton.onClick.AddListener(GameManager.instance.OnThrowing);
        menuButton.onClick.AddListener(LoadMenuScene);
        playAgainButton.onClick.AddListener(PlayAgain);                
    }

    public void SetScore()
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
        GameManager.instance.SetState(new BeginState());
    }

    public IEnumerator ActiveAddedTimeAnim()
    {
        addedTimeText.gameObject.SetActive(true);

        yield return new WaitForSeconds(timeToDeactivateAddedTimeAnim);

        addedTimeText.gameObject.SetActive(false);                
    }

    public void ResetValues()
    {
        scoreText.text = GameManager.GetPlayer().initialScore.ToString();        
        countBallThrowingText.text = GameManager.GetPlayer().initialAmountThrowing.ToString(); 
        throwingForceSlider.value = 0f;    
        verticalAngleSlider.value = GameManager.GetPlayer().initialVerticalRotationValue;
        timeText.color = initialTimeColor;           
    }
}