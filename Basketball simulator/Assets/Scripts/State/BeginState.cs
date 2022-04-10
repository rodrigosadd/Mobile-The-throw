using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginState : State
{
    public override IEnumerator Start()
    {
        Debug.Log("On Begin State...");
        if (!GameManager.GetUI().countdownToStartText.activeSelf)
        {
            GameManager.GetUI().countdownToStartText.SetActive(true);
        }

        yield return new WaitForSeconds(GameManager.GetTime().timeToStart);

        GameManager.GetTime().onFinishCountdownToStart?.Invoke();
        GameManager.GetUI().countdownToStartText.SetActive(false);
        GameManager.GetTime().canStartGame = true;
        GameManager.instance.SetState(new ThrowingState());
        yield break;
    }
}
