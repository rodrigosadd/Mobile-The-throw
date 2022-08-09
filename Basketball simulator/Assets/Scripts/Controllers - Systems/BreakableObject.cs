using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableObject : MonoBehaviour, IScorable
{
    public void HitedTarget()
    {
        Debug.Log("Made a point BreakableObject!");
    }
}
