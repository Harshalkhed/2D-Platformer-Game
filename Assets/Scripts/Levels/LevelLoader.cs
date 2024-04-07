using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

[RequireComponent(typeof(Button))]
public class LevelLoader : MonoBehaviour
{
    private Button levelSelectButton;

    public string levelName;

    private void Awake()
    {
        levelSelectButton = GetComponent<Button>();
        levelSelectButton.onClick.AddListener(OnClick);

    }

    private void OnClick()
    {
        SceneManager.LoadScene(levelName);
    }
}
