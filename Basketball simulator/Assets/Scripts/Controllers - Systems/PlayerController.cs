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
    public int initialRotationValue;
    public int initialScore;
    public int initialAmountThrowing;

    [Header("Pool variables")]
    [SerializeField] private PoolObjects _poolObjects;
    private Vector3 _startPosition;

    void Start()
    {
        _startPosition = new Vector3(transform.position.x,transform.position.y, transform.position.z);
        SetupValues();
    }
 
    public void SetupValues()
    {
        score = initialScore;
        amountThrowing = initialAmountThrowing;
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
    }
 
    public void SetNewPosition(Transform newPosition)
    {        
        transform.position = newPosition.position;        
    }

    public void ResetValues()
    {
        score = initialScore;
        amountThrowing = initialAmountThrowing;
        currentThrowingForce = 0f;
        transform.position = _startPosition;
        SetRotation(initialRotationValue);
    }
}
