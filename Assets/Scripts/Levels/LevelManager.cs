using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{

    public static LevelManager instance;
    public int health = 3;
    public Image[] hearts;

    public string[] Levels;
    public static LevelManager Instance { get { return instance; } } //Whenever they call Capital Instance and
                                                                     //they get value of private instance,
                                                                         //so they can acces the instance through
                                                                         //Instance and they can only get the value
                                                                          //not set the value as it is a get function 

    private void Start()
    {

        
        //PlayerPrefs.DeleteAll();
        if (GetLevelStatus(Levels[0]) == LevelStatus.Locked)
        {
            SetLevelStatus(Levels[0], LevelStatus.Unlocked);
            Debug.Log(Levels[0] + " is locked. Unlocking...");
            
            Debug.Log("Level1 status: " + GetLevelStatus(Levels[0]));
        }
        
    }


    private void Awake()
    {
        PlayerPrefs.DeleteAll();
        if (instance==null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);//level manager is consitent and required for the entire game 
        }
        else
        {
            Destroy(gameObject);//says that there is a duplicate copy of level manager,A singleton can only have on object
        }


        
    }

    public void MarkCurrentLevelComplete()
    {
        Scene currentscene = SceneManager.GetActiveScene();
        //set level status to complete
        //and ulock the next level be unlocked
        SetLevelStatus(currentscene.name, LevelStatus.Completed);
        // int nextSceneIndex = currentscene.buildIndex + 1;
        // Scene nextScene=SceneManager.GetSceneByBuildIndex(nextSceneIndex);
        // SetLevelStatus(nextScene.name, LevelStatus.Unlocked);
     int currentSceneIndex =   Array.FindIndex(Levels, level => level == currentscene.name);
        int nextSceneIndex = currentSceneIndex + 1;

        if(nextSceneIndex<Levels.Length)    {
            SetLevelStatus(Levels[nextSceneIndex], LevelStatus.Unlocked);
        }
        
    }
    


    public LevelStatus GetLevelStatus(string level)
    {
       LevelStatus levelStatus= (LevelStatus)PlayerPrefs.GetInt(level, 0);
        return levelStatus;
    }
    public void SetLevelStatus(string level,LevelStatus levelStatus)
    {
        PlayerPrefs.SetInt(level, (int)levelStatus);
     Debug.Log("Setting " + level + "levelstatus" + levelStatus);
    }





}
