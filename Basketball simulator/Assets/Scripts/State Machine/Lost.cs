using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lost : State
{
    public override IEnumerator Start()
    {
        Actions.OnLostAction?.Invoke();
        yield break;
    }
}
