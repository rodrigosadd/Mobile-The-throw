using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlaySystem : StateMachine
{
    public void OnBegin()
    {
        StartCoroutine(State.Throwing());
    }

    public void OnThrowing()
    {
        StartCoroutine(State.Throwing());
    }
}
