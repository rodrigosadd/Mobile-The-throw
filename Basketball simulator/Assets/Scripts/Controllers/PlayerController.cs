using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    [Header("Player variables")]
    public int score;
    public int amountThrowing;
    public float currentThrowingForce; 
    public float maxThrowingForce;

    [Header("Initial values")]
    public int initialVerticalRotationValue;
    public int initialHorizontalRotationValue;
    public int initialScore;
    public int initialAmountThrowing;

    [Header("Pool variables")]
    [SerializeField] private PoolObjects _poolObjects;
    private float _verticalRotationValue;
    private float _horizontalRotationValue;

    void Start()
    {
        InitialValues();
    }

    void OnEnable()
    {
        Actions.OnThrowingAction += SetBallDirection;
        Actions.OnThrowingAction += UpdateAmountThrowing;
        Actions.OnPlayAgainAction += ResetValues;
    }

    void OnDisable()
    {
        Actions.OnThrowingAction -= SetBallDirection;
        Actions.OnThrowingAction -= UpdateAmountThrowing;
        Actions.OnPlayAgainAction -= ResetValues;
    }

    public void InitialValues()
    {
        score = initialScore;
        amountThrowing = initialAmountThrowing;
    }
    
    public void SetThrowingForce(float value)
    {
        currentThrowingForce = value;
    }

    public void SetVerticalRotation(float value)
    {
        _verticalRotationValue = value;
        transform.rotation = Quaternion.Euler(value, _horizontalRotationValue, transform.rotation.z);
    }
    
    public void SetHorizontalRotation(float value)
    {
        _horizontalRotationValue = value;
        transform.rotation = Quaternion.Euler(_verticalRotationValue, value, transform.rotation.z);
    }

    public void SetBallDirection()
    {
        PoolableObject obj = _poolObjects.GetMonoBehaviourFromPool();
        obj.transform.position = transform.position;
        obj.throwableObject.rbody.velocity = (transform.rotation * Vector3.forward) * currentThrowingForce;        
    }
 
    public void UpdateAmountThrowing()
    {
        amountThrowing++;
        GameManager.GetUI().UpdateBallThrowingCount();
    }

    public void ResetValues()
    {
        score = initialScore;
        amountThrowing = initialAmountThrowing;
        currentThrowingForce = 0f;
        SetVerticalRotation(initialVerticalRotationValue);
    }
}
