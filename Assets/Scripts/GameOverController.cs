using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    public Button buttonRestart;

    private void Awake()
    {
        buttonRestart.onClick.AddListener(ReloadLevel);
        
    }
    public void PlayerDied()
    {
        SoundManager.Instance.Play(Sounds.PlayerDeath);
        gameObject.SetActive(true);
    }
    public void ReloadLevel()
    {
        SceneManager.LoadScene(1);

    }
}
