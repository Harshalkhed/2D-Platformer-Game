
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public static LevelManager instance;

    public static LevelManager Instance { get { return instance; } } //Whenever they call Capital Instance and
                                                                     //they get value of private instance,
    public string Level1;
    //so they can acces the instance through
    //Instance and they can only get the value
    //not set the value as it is a get function 

    private void Start()
    {

        
        //PlayerPrefs.DeleteAll();
        if (GetLevelStatus(Level1) == LevelStatus.Locked)
        {
            SetLevelStatus(Level1, LevelStatus.Unlocked);
            Debug.Log(Level1 + " is locked. Unlocking...");
            
            Debug.Log("Level1 status: " + GetLevelStatus(Level1));
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

    


    public LevelStatus GetLevelStatus(string level)
    {
       LevelStatus levelStatus= (LevelStatus)PlayerPrefs.GetInt(level, 0);
        return levelStatus;
    }
    public void SetLevelStatus(string level,LevelStatus levelStatus)
    {
        PlayerPrefs.SetInt(level, (int)levelStatus);
    }





}
