using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingState : State
{
    public override IEnumerator Start()
    {
        Debug.Log("On Throwing State...");
        yield break;
    }

    public override IEnumerator Throwing()
    {
        if (!GameManager.GetTime().endGame && GameManager.GetTime().canStartGame)
        {
            GameManager.GetPlayer().amountThrowing++;
            GameManager.GetUI().countBallThrowingText.text = GameManager.GetPlayer().amountThrowing.ToString();
            GameManager.GetPlayer().SetBallDirection();
            GameManager.GetUI().onBallThrowing?.Invoke();
        }

        yield break;
    }

    public override IEnumerator SetThrowingForce(float value)
    {
        GameManager.GetUI().throwingForceSlider.value = value;
        GameManager.GetPlayer().currentThrowingForce = value;
        yield break;
    }

    public override IEnumerator SetRotation(float value)
    {
        GameManager.GetUI().angleText.text = (value * -1).ToString("0º");
        GameManager.GetPlayer().SetRotation(value);
        yield break;
    }
}
