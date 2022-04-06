using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginState : State
{
    public override IEnumerator Start()
    {
        Debug.Log("On Begin State...");
        GameManager.instance.SetState(new ThrowingState());
        yield break;
    }
}
