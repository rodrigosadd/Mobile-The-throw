using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    public static ScoreController instance;
    public ParticleSystem particleScore;
    public Transform hood;
    public int minDistanceHood;
    public int maxDistanceHood;
    private float _countdownStopParticle;
    private bool _particleIsPlaying;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        TimeToStopParticle();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Ball")
        {
            MadeAPoint();
            RandomizeHoodPosition();      
        }
    }

    void MadeAPoint()
    {
        PlayerController.instance.ball.transform.position = PlayerController.instance.transform.position;
        PlayerController.instance.ball.rbody.velocity = Vector3.zero;
        PlayerController.instance.score++;
        particleScore.Play();  
        _particleIsPlaying = true;  
    }

    void RandomizeHoodPosition ()
    {
        Vector3 randomPosition = new Vector3(0f, 0f, Random.Range(minDistanceHood, maxDistanceHood));
        hood.position = randomPosition;
    } 

    void TimeToStopParticle()
    {
        if(_particleIsPlaying)
        {
            if(_countdownStopParticle < 1)
            {
                _countdownStopParticle += Time.deltaTime / 0.5f;
            }
            else
            {
                _countdownStopParticle = 0;
                _particleIsPlaying = false;
                particleScore.Stop(); 
            }
        }
    }

    public void ResetPositionHood()
    {
        Vector3 minPosition = new Vector3(0f, 0f,minDistanceHood);
        hood.position = minPosition;
    }
}
