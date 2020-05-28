using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    Scene scene;
    MakeList tiles;
    CircleMove inGame;
    Circle CircleAround;
    int listCount;
    int count;
    void Start()
    {
        inGame = GameObject.Find("circle").GetComponent<CircleMove>();
        CircleAround = GameObject.Find("circle").GetComponent<Circle>();
        tiles = GameObject.Find("Manager").GetComponent<MakeList>();
        scene = SceneManager.GetActiveScene();
        listCount = tiles.map.Count;
        count = 0;
    }
    private void Update()
    {
        if (!inGame.isUpdate)
        {
            if (CircleAround.isEnd)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    SoundManager.Instance.Stop();
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }
            }
        }

        int index = SceneManager.GetActiveScene().buildIndex;
        string name = SceneManager.GetActiveScene().name;

        if (inGame.isFinish && inGame.isOnce)
        {
            
            if (Input.GetMouseButtonDown(0))
            {
                count += 1;
            }
            if (count == 2)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    if (index != 5 || index != 10)
                    {
                        SoundManager.Instance.Stop();
                        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                        count = 0;
                    }
                }
                
            }
        }
    }
}