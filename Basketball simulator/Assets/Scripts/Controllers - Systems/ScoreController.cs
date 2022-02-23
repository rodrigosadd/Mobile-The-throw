using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreController : MonoBehaviour
{
    [Header("Score variables")]
    public ParticleSystem particleScore;

    [Header("Events")]
    public UnityEvent onMadeAPoint;

    void Update()
    {
        TimeToStopParticle();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Ball"))
        {
            other.GetComponent<PoolableObject>().Reset();
            MadeAPoint();
        }
    }

    void MadeAPoint()
    {
        GameManager.GetPlayer().score++;
        GameManager.GetTime().AddedTime(0.2f);     
        particleScore.Play();          
        StartCoroutine(GameManager.GetUI().ActiveAddedTimeAnim());
        StartCoroutine(TimeToStopParticle());
        onMadeAPoint?.Invoke();
    }

    IEnumerator TimeToStopParticle()
    {
        yield return new WaitForSeconds(0.5f);
        particleScore.Stop(); 
    }
}
