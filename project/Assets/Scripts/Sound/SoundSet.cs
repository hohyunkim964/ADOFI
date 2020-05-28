using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSet : MonoBehaviour
{
    bool isChange;
    bool isSet;
    [SerializeField]
    private AudioClip Audio;
    
    private void Start()
    {
        isChange = false;
        SoundManager.Instance.PlayLoopMusic(Audio);
    }
    private void Update()
    {
        if (isChange)
        {
            if (!isSet)
            {
                SoundManager.Instance.PlayLoopMusic(Audio);
                isChange = false;
            }
        }
        isSet = false;
    }
    public void SetMusicVolume(float volume)
    {
        //슬라이더를 통한 볼륨값 변경
        isChange = true;
        isSet = true;
        SoundManager.Instance.Pause();
        SoundManager.Instance.SetMusicVolume(volume);
    }
}
