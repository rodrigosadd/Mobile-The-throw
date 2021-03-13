using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [Header("Ball variables")]
    public Rigidbody rbody;
    public Vector3 startPosition;

    [Header("Trail variables")]
    public TrailRenderer trail;
    public bool canStartTrail;
    private float _countdownStartTrail;

    void Start()
    {
        //Apenas para definir os componentes para as variáveis
        rbody = GetComponent<Rigidbody>();
        trail = GetComponent<TrailRenderer>();

        //Pegando a posição inicial da bola para facilitar na hora de reiniciar o jogo
        startPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

     void Update()
    {
        ActiveTrail();
    }

    //Inicializando o trail depois de um tempo para poder evitar que sua imagem sejá distorcida
    void ActiveTrail()
    {
        if(canStartTrail)
        {
            if(_countdownStartTrail < 1)
            {
                _countdownStartTrail += Time.deltaTime / 0.5f;
            }
            else
            {
                _countdownStartTrail = 0;
                trail.time = 0.5f;
                trail.enabled = true; 
                canStartTrail = false;
            }
        }
    }

    //Apenas para facilitar na redefinição dos valores do trail
    public void ResetTrailValues()
    {
        trail.time = 0;
        trail.enabled = false;      
    }

    //Verifica se a bola colidiu com algo e toca o som da bola
    void OnTriggerEnter(Collider other)
    {
        AudioManager.instance.Play("Ball");
    }
}