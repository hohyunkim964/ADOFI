using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;
    public static SoundManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<SoundManager>();
                if (instance == null)
                {
                    instance = new GameObject("AudioManager", typeof(SoundManager)).GetComponent<SoundManager>();
                }
            }
            return instance;
        }
        set
        {
            instance = value;
        }
    }

    private AudioSource musicSource;
    float volumNum = 1.0f;
    bool isStop;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        musicSource = this.gameObject.AddComponent<AudioSource>();
        musicSource.loop = false;
    }

    public void PlayMusic(AudioClip musicClip)
    {       
        musicSource.clip = musicClip;
        musicSource.volume = volumNum;
        musicSource.Play();
        isStop = false;
    }

    public void PlayLoopMusic(AudioClip musicClip)
    {
        musicSource.clip = musicClip;
        musicSource.loop = true;
        musicSource.volume = volumNum;
        musicSource.Play();
    }

    public void Stop()
    {
        musicSource.Stop();
        isStop = true;
    }

    public void SetMusicVolume(float volume)
    {       
        volumNum = volume;
    }
    public void Pause()
    {
        musicSource.Pause();       
    }
    
}
