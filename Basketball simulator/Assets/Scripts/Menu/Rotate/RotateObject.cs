using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float speedRotate;
    void Update()
    {
        //Apenas para rotacionar um objeto em loop (Usando para fazer a câmera rodar no menu)
        transform.Rotate(new Vector3(0f, speedRotate, 0f));
    }
}
