using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIHandler : MonoBehaviour
{   
    [Header("Input variables")]
    public Slider angleSlider;
    public Slider throwingForceSlider;
    public Button throwingButton;
    public Button menuButton;

    [Header("Start game variables")]
    public GameObject menuInGame;
    public GameObject countdownToStartText;
    public float timeCountdownToStart;

    [Header("In game variables")]
    public Color timeColor;
    public Color timeRunningOutColor;
    public Text scoreText;
    public Text amountThrowingText;
    public Text angleText;
    public Text timeText;
    public Text addedTimeText;
    public float timeToDeactivateAddedTimeText;

    [Header("End game variables")]
    public GameObject endGamePanel;
    public Text finalScoreText;
    public Text finalAmountThrowingText;

    private float _initialRotationValue;

    void OnEnable()
    {
        GameManager.instance.OnAddedTime += UpdateAddedTimeText;
        GameManager.instance.OnSetAmountThrowing += UpdateBallThrowingCount;
        GameManager.instance.OnUpdateUIScore += UpdateScore;
        GameManager.instance.OnEndGame += UpdateEndGamePanel;
        GameManager.instance.OnSetMaxThrowingForce += SetupThrowingForceSlider;
        GameManager.instance.OnSetInitialRotationValue += SetupAngleSlider;        
    }

    void OnDisable()
    {
        GameManager.instance.OnAddedTime -= UpdateAddedTimeText;
        GameManager.instance.OnSetAmountThrowing -= UpdateBallThrowingCount;
        GameManager.instance.OnUpdateUIScore -= UpdateScore;
        GameManager.instance.OnEndGame -= UpdateEndGamePanel;
        GameManager.instance.OnSetMaxThrowingForce -= SetupThrowingForceSlider;
        GameManager.instance.OnSetInitialRotationValue -= SetupAngleSlider;        
    }

    void Start()
    {
        InitializeListerners();        
        SetupValues();
        InitializeCountdownToStart();        
    }

    void Update()
    {
        UpdateTimeText();
        UpdateAngleSliderText();
    }

    void SetupValues ()
    {
        throwingForceSlider.minValue = 0f;        
        scoreText.text = 0.ToString();
        amountThrowingText.text = "0";
    }

    void InitializeListerners()
    {
        angleSlider.onValueChanged.AddListener(GameManager.GetPlayer().SetRotation);
        throwingForceSlider.onValueChanged.AddListener(GameManager.GetPlayer().SetThrowingForce);
        throwingButton.onClick.AddListener(GameManager.GetPlayer().SetBallDirection);
    }

    void SetupThrowingForceSlider(float value)
    {
        throwingForceSlider.maxValue = value;
    }

    void SetupAngleSlider(float value)
    {
        angleSlider.value = value;
        _initialRotationValue = value;
    }

    void UpdateAngleSliderText()
    {
        float angle = -angleSlider.value + _initialRotationValue;
        angleText.text = angle.ToString("0°");
    }

    void UpdateScore(int value)
    {        
        scoreText.text = value.ToString();        
    }

    void UpdateBallThrowingCount(int value)
    {
        amountThrowingText.text = value.ToString();
    }

    void UpdateEndGamePanel()
    {
        endGamePanel.SetActive(true);
        finalScoreText.text = scoreText.text;
        finalAmountThrowingText.text = amountThrowingText.text;
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

    void UpdateAddedTimeText(int value)
    {
        addedTimeText.text = value.ToString("+00");
        AddedTimeAnimation();
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
        GameManager.instance.OnStartGame?.Invoke();
    }

    void AddedTimeAnimation()
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
        scoreText.text = 0.ToString();        
        amountThrowingText.text = "0"; 
        throwingForceSlider.value = 0f;    
        angleSlider.value = _initialRotationValue;
        timeText.color = timeColor;
    }
}