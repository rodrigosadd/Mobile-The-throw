using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Begin : State
{
    public override IEnumerator Start()
    {        
        Actions.OnStartGameAction?.Invoke();        
        yield break;
    }
}
