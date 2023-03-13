using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TimeHandler : MonoBehaviour
{
    [SerializeField] private float _time;
    public float currentTime;

    [Header("Event")]
    public UnityEvent OnStartTimer;
    public UnityEvent OnEndTimer;

    bool _canStartTimer;

    void OnEnable()
    {
        GameManager.instance.OnStartGame += StartTimer;
        GameManager.instance.OnAddedTime += UpdateCurrentTime;
    }

    void OnDisable()
    {
        GameManager.instance.OnStartGame -= StartTimer;
        GameManager.instance.OnAddedTime -= UpdateCurrentTime;
    }

    void Start()
    {
        currentTime = _time;
    }

    void Update()
    {
        Timer();
    }

    public void StartTimer()
    {
        _canStartTimer = true;
        OnStartTimer?.Invoke();
    }

    void Timer()
    {
        if (!_canStartTimer)
            return;

        currentTime -= Time.deltaTime;

        if (currentTime <= 0f)
        {
            _canStartTimer = false;
            GameManager.instance.OnEndGame?.Invoke();
            OnEndTimer?.Invoke();
        }
    }

    void UpdateCurrentTime(int value)
    {
        currentTime += value;
    }

    public void ResetValues()
    {
        currentTime = _time;
    }
}
