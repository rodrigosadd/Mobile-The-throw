using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMonoBehaviourPool
{
    MonoBehaviour MonoBehaviourReference { get; }
    GameObject GameObjectReference { get; }
}
