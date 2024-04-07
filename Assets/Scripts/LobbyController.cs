using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class LobbyController : MonoBehaviour
{
    public Button buttonPlay;
    public GameObject levelSelection;
   public Button buttonQuit;
    private void Awake()
    {
        buttonPlay.onClick.AddListener(PlayGame);
        buttonQuit.onClick.AddListener(QuitGame);
}

    private void QuitGame()
    {
        Application.Quit();
    }

    private void PlayGame()
    {
        //SceneManager.LoadScene(1);
        levelSelection.SetActive(true);
    }
}
