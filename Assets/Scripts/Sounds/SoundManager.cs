using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static SoundManager instance;
    
    

   
    public static SoundManager Instance { get { return instance; } } //Whenever they call Capital Instance and
                                                                     //they get value of private instance,
                                                                     //so they can acces the instance through
                                                                     //Instance and they can only get the value
                                                                     //not set the value as it is a get function 

    
    public AudioSource soundEffect;
    public AudioSource soundMusic;
     public SoundType[] Sounds;



    private void Awake()
    {
        PlayerPrefs.DeleteAll();
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);//level manager is consitent and required for the entire game 
        }
        else
        {
            Destroy(gameObject);//says that there is a duplicate copy of level manager,A singleton can only have on object
        }



    }

    private void Start()
    {
        PlaybackGroundMusic(global::Sounds.BackgroundMusic );


    }
    public void PlaybackGroundMusic(Sounds sound)
    {
        AudioClip clip = getSoundClip(sound);

        if (clip != null)
        {
            soundMusic.clip = clip;
            soundMusic.Play();

        }
        else
        {
            Debug.LogError("Clip Not Found fopr sound type " + sound);
        }
    }

    public void Play(Sounds sound)
    {
        AudioClip clip = getSoundClip(sound);

        if(clip!=null)
        {
            soundEffect.PlayOneShot(clip);

        }
        else
        {
            Debug.LogError("Clip Not Found fopr sound type " + sound);
        }
    }

    private AudioClip getSoundClip(Sounds sound)
    {
        SoundType item= Array.Find(Sounds, i => i.soundType == sound);

        if(item!=null)
        
            return item.soundClip;

        return null;

    }
}
[Serializable]
public class SoundType
{
    public Sounds soundType;
    public AudioClip soundClip;

}


public enum Sounds
{
    ButtonClick,
    PlayerMove,
    PlayerDeath,
    EnemyDeath,
    BackgroundMusic


}
