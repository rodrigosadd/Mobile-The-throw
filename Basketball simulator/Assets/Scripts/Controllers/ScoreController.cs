using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    public ParticleSystem particleScore;
    private float _countdownStopParticle;
    private bool _particleIsPlaying;

    void Update()
    {
        TimeToStopParticle();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Ball")
        {
            GameManager.GetPlayer().SetNewPosition();    
            MadeAPoint();
        }
    }

    void MadeAPoint()
    {
        GameManager.GetPlayer().ball.transform.position = GameManager.GetPlayer().transform.position;
        GameManager.GetPlayer().ball.rbody.velocity = Vector3.zero;
        GameManager.GetPlayer().score++;
        GameManager.GetPlayer().ball.trail.enabled = false;        
        particleScore.Play();  
        _particleIsPlaying = true;  
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
}
