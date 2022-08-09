using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoop : MonoBehaviour, IScorable
{
    public void HitedTarget()
    {
        Debug.Log("Made a point Hoop!");
    }

    void OnTriggerEnter(Collider other)
    {
        other.gameObject.SetActive(false);
    }
}
