using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Button playButton;
    public Button quitButton;

    void Start()
    {
        InitializeListerners();
    }

    void InitializeListerners()
    {
        playButton.onClick.AddListener(PlayGame);
        quitButton.onClick.AddListener(QuitGame);
    }

    public void LoadScene(int indexScene)
     {         
          SceneManager.LoadScene(indexScene);
     }

    void PlayGame()
    {
        LoadScene(1);
    }

     void QuitGame()
     {
          Debug.Log("Quit!");
          Application.Quit();
     }
}
