using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreController : MonoBehaviour
{
    [Header("Score variables")]
    public ParticleSystem particleScore;
    public float addedTimeValue;
    public float timeToStopParticle;

    [Header("Events")]
    public UnityEvent onMadeAPoint;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Ball"))
        {
            other.GetComponent<PoolableObject>().Reset();
            GameManager.instance.OnMadeAPoint();
        }
    }

    public IEnumerator TimeToStopParticle()
    {
        yield return new WaitForSeconds(timeToStopParticle);
        particleScore.Stop(); 
    }
}
