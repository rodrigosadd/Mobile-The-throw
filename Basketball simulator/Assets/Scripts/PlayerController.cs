using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Ball ball;
    public float rotationSpeed;
    public float currentThrowingForce; 
    public float maxThrowingForce;

    void Update()
    {          
        Inputs();
    }

    void Inputs()
    {
        if(Input.GetKey(KeyCode.Space))
        {            
            SetBallDirection();
        }
        
        if(Input.GetKey(KeyCode.W))
        {
            LookAtTheTarget(Vector3.left);
        }
        else if(Input.GetKey(KeyCode.S))
        {
            LookAtTheTarget(Vector3.right);
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            IncreaseThrowingForce();
        }
        else if(Input.GetKeyDown(KeyCode.D))
        {
            DecreaseThrowingForce();
        }
    }

    void LookAtTheTarget(Vector3 angle)
    {      
        transform.Rotate(angle * rotationSpeed * Time.deltaTime);
    }

    void SetBallDirection()
    {
        ball.rbody.velocity = BallDirection() * currentThrowingForce;
    }

    Vector3 BallDirection()
    {       
        ball.transform.position = transform.position; 
        return transform.rotation * Vector3.forward;
    }

    void IncreaseThrowingForce()
    {
        currentThrowingForce++;
        currentThrowingForce = Mathf.Clamp(currentThrowingForce, 1f, maxThrowingForce);
    }

    void DecreaseThrowingForce()
    {
        currentThrowingForce--;
        currentThrowingForce = Mathf.Clamp(currentThrowingForce, 1f, maxThrowingForce);
    }
}
