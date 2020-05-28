using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameStartUI : MonoBehaviour
{
    
    CircleMove inGame;
    Menu Stop;
    Circle CircleAround;

    public bool isStart;
    public bool isGameStart;
    bool isMusicOn;
    bool isOnce;
    float timer;

    public Text start;
    public Text End;
    Text Stage;
    float count;

    float percent;   
    public AudioClip music;

    public void Start()
    {        
        Stage = GameObject.Find("스테이지 이름").GetComponent<Text>();
        Stop = GameObject.Find("Menu").GetComponent<Menu>();
        inGame = GameObject.Find("circle").GetComponent<CircleMove>();
        CircleAround = GameObject.Find("circle").GetComponent<Circle>();
        start = GameObject.Find("Text").GetComponent<Text>();
        End = GameObject.Find("End").GetComponent<Text>();
        
        isStart = false;
        isGameStart = false;
        isOnce = true;

        timer = 0.0f;
        GameObject[] tag = GameObject.FindGameObjectsWithTag("Horizontal");
        GameObject[] tag1 = GameObject.FindGameObjectsWithTag("Vertical");
        GameObject[] tag2 = GameObject.FindGameObjectsWithTag("CurveLT");
        GameObject[] tag3 = GameObject.FindGameObjectsWithTag("CurveLD");
        GameObject[] tag4 = GameObject.FindGameObjectsWithTag("CurveRD");
        GameObject[] tag5 = GameObject.FindGameObjectsWithTag("CurveRT");
        count = tag.Length + tag1.Length + tag2.Length + tag3.Length + tag4.Length + tag5.Length;
        End.enabled = false;       
    }

    void Update()
    {      
        if (Input.GetMouseButtonDown(0) && isStart == false)
        {
            isStart = true;
        }
        if (isStart && Stop.isClick == false)
        {

            timer += Time.deltaTime;

            if (timer < 1.0f && timer >= 0.0f)
            {
                start.text = "3";
            }

            if (timer < 2.0f && timer >= 1.0f)
            {
                start.text = "2";
            }

            if (timer >= 2.0f && timer < 3.0f)
            {
                start.text = "1";
            }

            if (timer >= 3.0f)
            {
                if (isOnce)
                {
                    isMusicOn = true;
                    isOnce = false;
                }
               
                start.enabled = false;
                isGameStart = true;
            }
            if (isMusicOn == true)
            {
                SoundManager.Instance.PlayMusic(music);
                isMusicOn = false;
            }
        }

        if (inGame.isUpdate == false)
        {
            SoundManager.Instance.Stop();            
            if (CircleAround.isEnd)
            {
                percent = (inGame.moveCount / count);
                percent = Mathf.Round(percent * 100);
                End.enabled = true;
                End.text = percent + "% 완료";
            }
        }
        
            
    }
}

