using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    [Header("Player variables")]
    public Ball ball;
    public int score;
    public int amountThrowing;
    public float currentThrowingForce; 
    public float maxThrowingForce;

    [Header("New position variables")]
    public int minDistancePosition;
    public int maxDistancePosition;
    private Vector3 _startPosition;

    void Start()
    {
        //Pegando a posição inicial do player para facilitar na hora de reiniciar o jogo
        _startPosition = new Vector3(transform.position.x,transform.position.y, transform.position.z);
    }
 
    //Rotacionando o player no eixo x de acordo com o valor que está sendo passado por parâmetro
    public void SetRotation(float value)
    {
        transform.rotation = Quaternion.Euler(value, transform.rotation.y, transform.rotation.z);
    }

    //Define a direção da bola e define que o trail pode ser ativo
    public void SetBallDirection()
    {   
        ball.canStartTrail = true;
        ball.ResetTrailValues();
        ball.rbody.velocity = BallDirection() * currentThrowingForce;   
    }
 
    //Traz a bola para o transform do player (assim sempre reciclar a mesma bola) e depois define
    //a direção da bola com a rotação que foi definida no metodo SetRotation
    Vector3 BallDirection()
    {       
        ball.transform.position = transform.position; 
        return transform.rotation * Vector3.forward;
    }

    public void SetNewPosition()
    {        
        transform.position = RandomizePosition();       
    }

    //Define uma nova posição randômica para o player com dois limitadores de distância
    Vector3 RandomizePosition()
    {
        Vector3 randomPosition = new Vector3(0f, _startPosition.y, Random.Range(minDistancePosition, maxDistancePosition));
        return randomPosition;
    }

    //Apenas para facilitar a redefinição dos valores do player e da bola
    public void ResetValues()
    {
        score = 0;
        amountThrowing = 0;
        currentThrowingForce = 1;
        transform.position = _startPosition;
        ball.transform.position = ball.startPosition;
        ball.rbody.velocity = Vector3.zero;
        SetRotation(45);
    }
}
