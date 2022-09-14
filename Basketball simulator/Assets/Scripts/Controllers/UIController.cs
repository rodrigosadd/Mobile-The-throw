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
    public Button menuButton;
    public Button playAgainButton;

    [Header("Start game variables")]
    public GameObject menuInGame;
    public GameObject countdownToStartText;
    public float timeCountdownToStart;

    [Header("In game variables")]
    public Text scoreText;
    public Text ballThrowingCountText;
    public Text verticalAngleText;
    public Text horizontalAngleText;
    public Text timeText;
    public Color timeColor;
    public Color timeRunningOutColor;
    public Text addedTimeText;
    public float timeToDeactivateAddedTimeText;

    [Header("End game variables")]
    public GameObject endGamePanel;
    public Text finalScoreText;
    public Text amountBallThrowingText;

    void Start()
    {
        InitializeListerners();        
        SetupUIValues();        
    }

    void Update()
    {
        UpdateTimeText();
    }

    void OnEnable()
    {
        Actions.OnStartGameAction += InitializeCountdownToStart;
        Actions.OnMadePointAction += UpdateScore;
        Actions.OnMadePointAction += InitializeAddedTimeCountdown;
        Actions.OnEndGameAction += UpdateEndGamePanel;
        Actions.OnPlayAgainAction += ResetValues;
    }

    void OnDisable()
    {
        Actions.OnStartGameAction -= InitializeCountdownToStart;
        Actions.OnMadePointAction -= UpdateScore;        
        Actions.OnMadePointAction -= InitializeAddedTimeCountdown;               
        Actions.OnEndGameAction -= UpdateEndGamePanel;
        Actions.OnPlayAgainAction -= ResetValues;
    }

    void SetupUIValues ()
    {
        throwingForceSlider.minValue = 0f;
        throwingForceSlider.maxValue = GameManager.GetPlayer().maxThrowingForce;
        scoreText.text = GameManager.GetPlayer().initialScore.ToString();
        ballThrowingCountText.text = GameManager.GetPlayer().initialAmountThrowing.ToString();
    }

    void InitializeListerners()
    {
        //Temporary
        verticalAngleSlider.onValueChanged.AddListener(GameManager.GetPlayer().SetVerticalRotation);
        horizontalAngleSlider.onValueChanged.AddListener(GameManager.GetPlayer().SetHorizontalRotation);

        throwingForceSlider.onValueChanged.AddListener(GameManager.GetPlayer().SetThrowingForce);
        throwingButton.onClick.AddListener(GameManager.instance.OnThrowingButton);
        menuButton.onClick.AddListener(LoadMenuScene);
        playAgainButton.onClick.AddListener(GameManager.instance.OnPlayAgainButton);                
    }

    void UpdateScore()
    {        
        scoreText.text = GameManager.GetPlayer().score.ToString();        
    }

    public void UpdateBallThrowingCount()
    {
        ballThrowingCountText.text = GameManager.GetPlayer().amountThrowing.ToString();
    }

    void UpdateEndGamePanel()
    {
        endGamePanel.SetActive(true);
        finalScoreText.text = GameManager.GetPlayer().score.ToString();
        amountBallThrowingText.text = GameManager.GetPlayer().amountThrowing.ToString();
    }

    void LoadMenuScene()
    {
        GameManager.instance.ResetAll();
        SceneManager.LoadScene(0);
    }
 
    void InitializeCountdownToStart()
    {
        StartCoroutine(CountdownToStart());
    }

    IEnumerator CountdownToStart()
    {
        endGamePanel.SetActive(false);
        menuInGame.SetActive(false);
        countdownToStartText.SetActive(true);
        yield return new WaitForSeconds(timeCountdownToStart);        
        menuInGame.SetActive(true);
        countdownToStartText.SetActive(false);
        GameManager.instance.SetState(new Pitches());
    }

    void UpdateTimeText()
    {
        timeText.text = GameManager.GetTime().currentTime.ToString("00.0");

        if (GameManager.GetTime().currentTime < 10f)
        {
            timeText.color = timeRunningOutColor;
        }
        else
        {
            timeText.color = timeColor;
        }
    }

    void InitializeAddedTimeCountdown()
    {
        StartCoroutine(CountdownToDeactivateAddedTimeText());
    }

    IEnumerator CountdownToDeactivateAddedTimeText()
    {
        addedTimeText.gameObject.SetActive(true);
        yield return new WaitForSeconds(timeToDeactivateAddedTimeText);
        addedTimeText.gameObject.SetActive(false);
    }

    public void ResetValues()
    {
        scoreText.text = GameManager.GetPlayer().initialScore.ToString();        
        ballThrowingCountText.text = GameManager.GetPlayer().initialAmountThrowing.ToString(); 
        throwingForceSlider.value = 0f;    
        verticalAngleSlider.value = GameManager.GetPlayer().initialVerticalRotationValue;
        timeText.color = timeColor;
    }
}