using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolableObject : MonoBehaviour, IMonoBehaviourPool, IPool
{
    public MonoBehaviour MonoBehaviourReference => this;
    public GameObject GameObjectReference => gameObject;

    public ThrowableObject throwableObject;

    [SerializeField] float _timeToDeactivate = 2f;

    public bool IsBeenUsed { get; set; }
        
    void OnEnable()
    {
        StartCoroutine(CountdownToDeactivate());
    }

    public void Reset()
    {
        IsBeenUsed = false;
        gameObject.SetActive(false);
    }

    IEnumerator CountdownToDeactivate()
    {
        yield return new WaitForSeconds(_timeToDeactivate);
        Reset();      
    }
}
