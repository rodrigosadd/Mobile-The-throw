using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
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

    public virtual IEnumerator SetThrowingForce(float value)
    {
        yield break;
    }
    
    public virtual IEnumerator SetRotation(float value)
    {
        yield break;
    }
    
}
