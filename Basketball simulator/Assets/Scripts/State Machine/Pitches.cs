using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pitches : State
{
    public override IEnumerator Start()
    {
        Actions.OnStartTimerAction?.Invoke();
        yield break;
    }

    public override void Throwing()
    {
        Actions.OnThrowingAction?.Invoke();
    }

    public override void PlayAgain()
    {
        Actions.OnPlayAgainAction?.Invoke();
    }
}
