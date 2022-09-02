using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Won : State
{
    public override IEnumerator Start()
    {
        Actions.OnWonAction?.Invoke();
        yield break;
    }
}
