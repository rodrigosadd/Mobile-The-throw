using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObjects : MonoBehaviour
{
    [SerializeField] private PoolableObject _prefabObjPool;
    [SerializeField] private int _initialAmountPoolableObjects;
    [SerializeField] private PoolableObject[] _objsPool;

    GameObject _objsPoolHolder;
    PoolableObject _currentPoolableObj;

    void Start()
    {
        InitializePool();
    }

    void InitializePool()
    {
        _objsPoolHolder = new GameObject("===Poolable Objects");
        _objsPoolHolder.transform.position = Vector2.zero;
        GameManager.GetPoolSystem().InitializePool(ref _objsPool, _prefabObjPool, _initialAmountPoolableObjects, _objsPoolHolder);
    }

    public PoolableObject GetMonoBehaviourFromPool()
    {
        _currentPoolableObj = (PoolableObject)GameManager.GetPoolSystem().TryGetMonoBehaviourFromPool<PoolableObject>(ref _objsPool, _prefabObjPool, _objsPoolHolder);
        _currentPoolableObj.IsBeenUsed = true;
        return _currentPoolableObj;
    }
}
