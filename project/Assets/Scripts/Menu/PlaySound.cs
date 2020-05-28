using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    [SerializeField]
    private AudioClip music;

    void Start()
    {
        SoundManager.Instance.PlayLoopMusic(music);
    }

}
