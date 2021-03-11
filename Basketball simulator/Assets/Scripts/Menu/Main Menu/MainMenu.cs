using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Button playButton;

    void Start()
    {
        InitializeListerners();
    }

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
        AudioManager.instance.Play("Click"); 
        LoadScene(1);
    }
}
