using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
    [SerializeField] private float _time;
    public float currentTime;

    bool _canStartTimer;

    void Start()
    {
        currentTime = _time;
    }

    void Update()
    {
        Timer();
    }

    void OnEnable()
    {
        Actions.OnStartTimerAction += StartTimer;
        Actions.OnPlayAgainAction += ResetValues;
    }

    void OnDisable()
    {
        Actions.OnStartTimerAction -= StartTimer;
        Actions.OnPlayAgainAction -= ResetValues;
    }

    void StartTimer()
    {
        _canStartTimer = true;
    }

    void Timer()
    {
        if (!_canStartTimer)
            return;

        currentTime -= Time.deltaTime;

        if (currentTime <= 0f)
        {
            Actions.OnEndGameAction?.Invoke();
            _canStartTimer = false;
        }
    }

    public void ResetValues()
    {
        currentTime = _time;
    }
}
