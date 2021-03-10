using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [Header("Ball variables")]
    public Rigidbody rbody;
    public TrailRenderer trail;
    public Vector3 startPosition;

    [Header("Trail variables")]
    public bool canStartTrail;
    private float _countdownStartTrail;

    void Start()
    {
        rbody = GetComponent<Rigidbody>();
        trail = GetComponent<TrailRenderer>();
        startPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

     void Update()
    {
        ActiveTrail();
    }

    void ActiveTrail()
    {
        if(canStartTrail)
        {
            if(_countdownStartTrail < 1)
            {
                _countdownStartTrail += Time.deltaTime / 0.5f;
            }
            else
            {
                _countdownStartTrail = 0;
                trail.time = 0.5f;
                trail.enabled = true; 
                canStartTrail = false;
            }
        }
    }

    public void ResetTrailValues()
    {
        trail.time = 0;
        trail.enabled = false;      
    }
}