using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolSystem : MonoBehaviour
{
    public void InitializePool<T>(ref T[] pool, IMonoBehaviourPool prefab, int amount, GameObject holder) where T : IMonoBehaviourPool
    {
        for (int i = 0; i < amount; i++)
        {
            IMonoBehaviourPool item = GameObject.Instantiate(prefab.MonoBehaviourReference) as IMonoBehaviourPool;
            item.GameObjectReference.transform.SetParent(holder.transform);
            item.GameObjectReference.GetComponent<PoolableObject>().Reset();
            AddToPool(ref pool, item);
        }
    }

    public IMonoBehaviourPool TryGetMonoBehaviourFromPool<T>(ref T[] pool, IMonoBehaviourPool prefab, GameObject holder) where T : IMonoBehaviourPool
    {
        IMonoBehaviourPool item = GetAvailableMonoBehaviourInPool(pool);

        if (item == null)
        {
            item = GameObject.Instantiate(prefab.MonoBehaviourReference) as IMonoBehaviourPool;
            item.GameObjectReference.transform.SetParent(holder.transform);
            AddToPool(ref pool, item);
        }

        item.GameObjectReference.SetActive(true);
        return item;
    }

    public IPool TryGetFromPool<T>(ref T[] pool, Type type) where T : IPool
    {
        IPool item = GetAvailableItemInPool(pool);

        if (item == null)
        {
            item = (IPool)Activator.CreateInstance(type);
            AddToPool(ref pool, item);
        }

        item.IsBeenUsed = true;

        return item;
    }

    public IMonoBehaviourPool GetAvailableMonoBehaviourInPool<T>(T[] pool) where T : IMonoBehaviourPool
    {
        IMonoBehaviourPool toReturn = null;

        for (int i = 0; i < pool.Length; i++)
        {
            GameObject item = pool[i].GameObjectReference;
            if (!item.activeSelf)
            {
                toReturn = pool[i];
                break;
            }
        }

        return toReturn;
    }

    public IPool GetAvailableItemInPool<T>(T[] pool) where T : IPool
    {
        IPool toReturn = null;

        for (int i = 0; i < pool.Length; i++)
        {
            if (!pool[i].IsBeenUsed)
            {
                toReturn = pool[i];
                break;
            }
        }

        return toReturn;
    }

    public void AddToPool<T>(ref T[] pool, IPool item) where T : IPool
    {
        Array.Resize(ref pool, pool.Length + 1);
        int id = pool.Length - 1;
        pool[id] = (T)item;
    }

    public void AddToPool<T>(ref T[] pool, IMonoBehaviourPool item) where T : IMonoBehaviourPool
    {
        Array.Resize(ref pool, pool.Length + 1);
        int id = pool.Length - 1;
        pool[id] = (T)item;
    }

    public void ResetListOfItens<T>(ref List<T> collection, bool clear = true) where T : IPool
    {
        for (int i = 0; i < collection.Count; i++)
        {
            collection[i].Reset();
        }

        if (clear)
        {
            collection.Clear();
        }
    }
}