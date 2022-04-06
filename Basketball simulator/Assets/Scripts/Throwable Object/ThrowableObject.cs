using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ThrowableObject : MonoBehaviour
{
    [Header("Object variables")]
    public PoolableObject poolableObject;
    public Rigidbody rbody;
    public SoundSO collisionSound;
    public Vector3 startPosition;

    [Header("Trail variables")]
    public TrailRenderer trail;

    [Header("Events")]
    public UnityEvent onObjectCollision;

    void Start()
    {
        startPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    void OnEnable()
    {
        StartCoroutine(ActiveTrail());
    }

    void OnDisable()
    {
        ResetTrailValues();
    }

    IEnumerator ActiveTrail()
    {
        yield return new WaitForSeconds(0.5f);
        trail.time = 0.5f;
        trail.enabled = true;        
    }

    public void ResetTrailValues()
    {
        trail.time = 0;
        trail.enabled = false;      
    }

    void OnTriggerEnter(Collider other)
    {
        GameManager.GetAudioManager().Play(collisionSound);
        onObjectCollision?.Invoke();
    }
}