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

    [SerializeField] private PoolObjects _poolObjects;
    private Vector3 _startPosition;

    void Start()
    {
        _startPosition = new Vector3(transform.position.x,transform.position.y, transform.position.z);
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
        score = 0;
        amountThrowing = 0;
        currentThrowingForce = 1;
        transform.position = _startPosition;
        SetRotation(-40f);
    }
}
