using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Header("Main menu variables")]
    public Button playButton;

    [Header("Events")]
    public UnityEvent onPlayGame;

    void Start()
    {
        InitializeListerners();
    }

    //Inicializa os Listerners da UI
    void InitializeListerners()
    {
        playButton.onClick.AddListener(PlayGame);        
    }

    public void LoadScene(int indexScene)
     {         
          SceneManager.LoadScene(indexScene);
     }

    void PlayGame()
    {
        //AudioManager.instance.Play("Click"); 
        onPlayGame?.Invoke();
        LoadScene(1);
    }
}
