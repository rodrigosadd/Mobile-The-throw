using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Player Instance")]
    [SerializeField] private PlayerHandler _playerInstance;

    [Header("UI Instance")]
    [SerializeField] private UIHandler _uiInstance;

    [Header("Pool System Instance")]
    [SerializeField] private PoolSystem _poolSystemInstance;

    [Header("Audio Manager Instance")]
    [SerializeField] private AudioManager _audioInstance;
    
    [Header("Time Controller Instance")]
    [SerializeField] private TimeHandler _timeInstance;

    public UnityAction OnStartGame;
    public UnityAction OnStartTransition;
    public UnityAction OnEndGame;
    public UnityAction<int> OnAddedTime;
    public UnityAction<int> OnAddedScore;
    public UnityAction<int> OnUpdateUIScore;
    public UnityAction<int> OnSetAmountThrowing;
    public UnityAction<float> OnSetMaxThrowingForce;
    public UnityAction<float> OnSetInitialRotationValue;

    void Awake()
    {
        instance = this;
    }

    #region Instances
    public static PlayerHandler GetPlayer()
    {
        return instance._playerInstance;
    }

    public static UIHandler GetUI()
    {
        return instance._uiInstance;
    }

    public static PoolSystem GetPoolSystem()
    {
        return instance._poolSystemInstance;
    }

    public static AudioManager GetAudioManager()
    {
        return instance._audioInstance;
    }
    
    public static TimeHandler GetTime()
    {
        return instance._timeInstance;
    }
    #endregion

    public void ResetAll()
    {
        GetUI().ResetValues();
        GetPlayer().ResetValues();
        GetTime().ResetValues();
    }
}