using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class ScorableObject : MonoBehaviour
{
    public ParticleSystem particlePoint;
    public Collider[] colliders; 
    public float timeToStopParticle;
    public bool disableObjCollided;
    public int amountPoints;
    public int amountTime;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("ThrowableObject"))
            return;

        GameManager.GetUI().addedTimeText.text = amountTime.ToString("+00");
        GameManager.GetPlayer().score += amountPoints;
        GameManager.GetTime().currentTime += amountTime;
        StartCoroutine(ParticleAnimation());
        Actions.OnMadePointAction?.Invoke();

        if(disableObjCollided)
            other.gameObject.SetActive(false);

        for (int i = 0; i < colliders.Length; i++)
        {
            colliders[i].enabled = false;
        }
    }

    IEnumerator ParticleAnimation()
    {
        particlePoint.Play();
        yield return new WaitForSeconds(timeToStopParticle);
        particlePoint.Stop();

    }
}
