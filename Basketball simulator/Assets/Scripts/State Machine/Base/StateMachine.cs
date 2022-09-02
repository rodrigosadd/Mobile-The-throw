using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
    protected State currentState;

    public void SetState(State newState)
    {
        currentState = newState;
        StartCoroutine(currentState.Start());
    }
}
