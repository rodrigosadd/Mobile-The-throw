using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginState : State
{
    public BeginState(GamePlaySystem gamePlaySystem) : base(gamePlaySystem) { }

    public override IEnumerator Start()
    {
        Debug.Log("Hi Enter State...");
        yield break;
    }
}
