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
        LevelStatus levelStatus = LevelManager.Instance.GetLevelStatus(levelName);

        switch(levelStatus)
            {

            case LevelStatus.Locked:
                Debug.Log("Cant play this level till you unlock it");
                break;

            case LevelStatus.Unlocked:
                SceneManager.LoadScene(levelName);
                break;
            case LevelStatus.Completed:
                SceneManager.LoadScene(levelName);
                break;


        }
        
    }
}
