using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player variables")]
    public Ball ball;
    public int score;
    public int amountThrowing;
    public float currentThrowingForce; 
    public float maxThrowingForce;

    [Header("New position variables")]
    public int minDistancePosition;
    public int maxDistancePosition;
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
        ball.rbody.velocity = BallDirection() * currentThrowingForce;
    }

    Vector3 BallDirection()
    {       
        ball.transform.position = transform.position; 
        return transform.rotation * Vector3.forward;
    }

    public void SetNewPosition()
    {        
        transform.position = RandomizePosition();       
    }

    Vector3 RandomizePosition()
    {
        Vector3 randomPosition = new Vector3(0f, _startPosition.y, Random.Range(minDistancePosition, maxDistancePosition));
        return randomPosition;
    }

    public void ResetValues()
    {
        score = 0;
        amountThrowing = 0;
        currentThrowingForce = 1;
        transform.position = _startPosition;
        ball.transform.position = ball.startPosition;
        ball.rbody.velocity = Vector3.zero;
        SetRotation(45);
    }
}
