using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody rbody;
    public Vector3 startPosition;

    void Start()
    {
        rbody = GetComponent<Rigidbody>();
        startPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }
}