using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Menu : MonoBehaviour
{
    GameStartUI music;

    public Canvas menu;
    public Canvas Game;
    public Text text;
    
    public bool isClick;
    public bool UiButton;

    float timer;

    int num;


    void Start()
    {
        Game = GameObject.Find("Canvas").GetComponent<Canvas>();
        menu = GameObject.Find("Menu").GetComponent<Canvas>();
        text = GameObject.Find("logo").GetComponent<Text>();
        music = GameObject.Find("Manager").GetComponent<GameStartUI>();
        isClick = false;        
        menu.enabled = false;
        Game.enabled = true;
        text.enabled = false;
        UiButton = false;
    }

    void Update()
    {    
        if(text.enabled == true)
        {
            timer += Time.deltaTime;
            if (timer > 1.0f)
            {
                timer = 0;
                text.enabled = false;
            }
        }
    }

    public void play()
    {
        isClick = false;
        Game.enabled = true;
        menu.enabled = false;
        SoundManager.Instance.PlayMusic(music.music);
    }

    public void prev()
    {        
        int i = SceneManager.GetActiveScene().buildIndex;
        if (i == 1 || i == 8 || i == 12)
        {
            text.enabled = true;
            if (i == 1)
            {
                num = 1;
            }
            if (i == 8)
            {
                num = 2;
            }
            if (i == 12)
            {
                num = 3;
            }

            text.text = num + " 스테이지 처음 단계 입니다.";
        }
        else
        {
            SoundManager.Instance.Stop();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }

    public void next()
    {       
        int i = SceneManager.GetActiveScene().buildIndex;
        if (i == 11 || i == 18 || i == 7)
        {
            if (i == 11)
            {
                num = 2;
            }
            if (i == 18)
            {
                num = 3;
            }
            if (i == 7)
            {
                num = 1;
            }
            text.enabled = true;
            text.text = num + " 스테이지 마지막 단계 입니다.";
        }
        else
        {
            SoundManager.Instance.Stop();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }       
    }

    public void exit()
    {
        SoundManager.Instance.Stop();
        SceneManager.LoadScene(0);
    }

    public void Pause()
    {
        UiButton = true;
        if (music.isStart)
        {
            if (SceneManager.GetActiveScene().buildIndex != 0)
            {
                if (!isClick)
                {
                    isClick = true;
                    Game.enabled = false;
                    menu.enabled = true;
                    SoundManager.Instance.Pause();
                }
                else
                {
                    isClick = false;
                    Game.enabled = true;
                    menu.enabled = false;
                    SoundManager.Instance.PlayMusic(music.music);
                }
            }
        }
        
    }
}
