using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    protected GamePlaySystem GamePlaySystem;

    public State(GamePlaySystem gamePlaySystem)
    {
        GamePlaySystem = gamePlaySystem;
    }

    public virtual IEnumerator Start() 
    {
        yield break;
    }

    public virtual IEnumerator Begin()
    {
        yield break;
    }

    public virtual IEnumerator Throwing()
    {
        yield break;
    }
}
