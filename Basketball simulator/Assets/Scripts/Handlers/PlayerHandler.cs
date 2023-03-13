using UnityEngine;
using UnityEngine.Events;

public class PlayerHandler : MonoBehaviour
{
    [Header("Others")]
    public int score;
    public int amountThrowing;
    public float currentThrowingForce; 
    public float maxThrowingForce;
    public float maxDistance;

    [Header("Initial values")]
    public int initialRotationValue;
    private float _initialPosition;

    [Header("Pool variables")]
    [SerializeField] private PoolObjects _poolObjects;

    [Header("Event")]
    public UnityEvent OnThrowing;

    void OnEnable()
    {
        GameManager.instance.OnAddedScore += UpdateScore;
        GameManager.instance.OnAddedScore += SetNewPosition;
    }

    void OnDisable()
    {
        GameManager.instance.OnAddedScore -= UpdateScore;
        GameManager.instance.OnAddedScore -= SetNewPosition;
    }

    void Start()
    {
        GetInitialPosition();
        InitialMaxThrowingForce();
        InitialRotationValue();
    }
    void GetInitialPosition()
    {
        _initialPosition = transform.position.z;
    }

    public void InitialMaxThrowingForce()
    {
        GameManager.instance.OnSetMaxThrowingForce?.Invoke(maxThrowingForce);
    }
    
    public void InitialRotationValue()
    {
        GameManager.instance.OnSetInitialRotationValue?.Invoke(initialRotationValue);
    }
    
    public void SetThrowingForce(float value)
    {
        currentThrowingForce = value;
    }

    public void SetRotation(float value)
    {
        transform.rotation = Quaternion.Euler(value, transform.rotation.y, transform.rotation.z);
    }
    
    public void SetBallDirection()
    {
        PoolableObject obj = _poolObjects.GetMonoBehaviourFromPool();
        obj.transform.position = transform.position;
        obj.throwableObject.rbody.velocity = (transform.rotation * Vector3.forward) * currentThrowingForce;
        UpdateAmountThrowing();
        OnThrowing?.Invoke();
    }
 
    public void UpdateAmountThrowing()
    {
        amountThrowing++;
        GameManager.instance.OnSetAmountThrowing?.Invoke(amountThrowing);
    }

    public void UpdateScore(int value)
    {
        score += value;
        GameManager.instance.OnUpdateUIScore?.Invoke(score);
    }

    void SetNewPosition(int value)
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, Random.Range(_initialPosition, maxDistance));
    }

    public void ResetValues()
    {
        score = 0;
        amountThrowing = 0;
        currentThrowingForce = 0f;
        SetRotation(initialRotationValue);
    }
}
