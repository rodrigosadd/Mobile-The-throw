using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    public Ball ball;
    public int score;
    public int amountThrowing;
    public float currentThrowingForce; 
    public float maxThrowingForce;

    void Awake()
    {
        instance = this;
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

    public void ResetValues()
    {
        score = 0;
        amountThrowing = 0;
        currentThrowingForce = 1;
        ball.transform.position = ball.startPosition;
        ball.rbody.velocity = Vector3.zero;
        SetRotation(45);
    }
}
