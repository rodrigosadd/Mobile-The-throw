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
        if (!GameManager.GetTime().endGame)
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

    public override IEnumerator SetVerticalRotation(float value)
    {
        GameManager.GetUI().verticalAngleText.text = (value * -1).ToString("0º");
        GameManager.GetPlayer().SetVerticalRotation(value);
        yield break;
    }

    public override IEnumerator SetHorizontalRotation(float value)
    {
        GameManager.GetUI().horizontalAngleText.text = (value * 1).ToString("0º");
        GameManager.GetPlayer().SetHorizontalRotation(value);
        yield break;
    }

    public override IEnumerator MadeAPoint()
    {
        GameManager.GetPlayer().score++;
        GameManager.GetTime().AddedTime(GameManager.GetScore().addedTimeValue);
        GameManager.GetScore().particleScore.Play();
        GameManager.GetScore().StartCoroutine(GameManager.GetUI().ActiveAddedTimeAnim());
        GameManager.GetScore().StartCoroutine(GameManager.GetScore().TimeToStopParticle());
        GameManager.GetScore().onMadeAPoint?.Invoke();
        yield break;
    }
}
