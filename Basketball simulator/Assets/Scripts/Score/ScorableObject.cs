using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class ScorableObject : MonoBehaviour
{
    public ParticleSystem particlePoint;
    public float timeToStopParticle;
    public int amountScore;
    public int amountTime;

    [Header("Event")]
    public UnityEvent OnScore;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("ThrowableObject"))
            return;

        StartCoroutine(ParticleAnimation());
        other.gameObject.SetActive(false);
        GameManager.instance.OnAddedScore?.Invoke(amountScore);
        GameManager.instance.OnAddedTime?.Invoke(amountTime);
        OnScore?.Invoke();
    }

    IEnumerator ParticleAnimation()
    {
        particlePoint.Play();

        yield return new WaitForSeconds(timeToStopParticle);

        particlePoint.Stop();

    }
}
