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

    void InitializeListerners()
    {
        playButton.onClick.AddListener(PlayGame);        
    }

    void PlayGame()
    {
        onPlayGame?.Invoke();
    }
}
