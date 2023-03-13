using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float speedRotate;
    void Update()
    {
        transform.Rotate(new Vector3(0f, speedRotate, 0f));
    }
}
