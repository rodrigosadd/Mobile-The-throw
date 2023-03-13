using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public Animator anim;
    public float transitionTime;
    public string parameterName;

    public void LoadScene(string sceneName)
    {
        StartCoroutine(StartTransition(sceneName));
    }

    IEnumerator StartTransition(string sceneName) 
    {
        anim.SetTrigger(parameterName);

        yield return new WaitForSeconds(transitionTime);
        
        SceneManager.LoadScene(sceneName);
    }
}
