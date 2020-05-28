using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using UnityEngine.UI;

public class PlayerMotion : MonoBehaviour
{   
    public direction circleDT;
    PlayerCollsion position;
    MakeList tiles;

    Image red;

    public GameObject DotCircle;
    public GameObject redBall;
    public GameObject blueBall;

    float nowtime;
    float timer;
    float delayTime;
    float time;

    Sprite moveTile;

    [Header("속도, 반지름")]
    public float speed;
    [Range(0f, 10f)] public float radius = 0.75f;

    public float runningTime = 0;
    float x;
    float y;
    private Vector2 newPos = new Vector2();


    void Start()
    {
        DotCircle = GameObject.Find("DottedCircle");
        redBall = GameObject.Find("RedBall");
        blueBall = GameObject.Find("BlueBall");
        tiles = GameObject.Find("Manager").GetComponent<MakeList>();
        moveTile = (Sprite)Resources.Load("Tile Image/yellowTile", typeof(Sprite));
        blueBall.GetComponentInChildren<TrailRenderer>().enabled = true;
        redBall.GetComponentInChildren<TrailRenderer>().enabled = true;
        red = GameObject.Find("Image").GetComponent<Image>();       
        speed = 5.0f;              
        timer = 0.0f;
        delayTime = 2.0f;
        time = 0.0f;
        red.enabled = false;
        circleDT = direction.isLeft;
        
        this.UpdateAsObservable()
        .Subscribe(_ =>
        {
            timer += Time.deltaTime;
            //중점에 있는 공에 따라 회전하는 공의 값 가져오기
            if (DotCircle.transform.position == redBall.transform.position)
            {
                position = blueBall.GetComponent<PlayerCollsion>();
            }
            else if (DotCircle.transform.position == blueBall.transform.position)
            {
                position = redBall.GetComponent<PlayerCollsion>();
            }
            //Sin, Cos 파형을 통한 원그리기
            runningTime += Time.deltaTime * speed;
            x = radius * Mathf.Sin((90 * (Mathf.PI / 180)) + runningTime);
            y = radius * Mathf.Cos((90 * (Mathf.PI / 180)) + runningTime);

            newPos = new Vector2(-x + DotCircle.transform.position.x, -y + DotCircle.transform.position.y);

            if (DotCircle.transform.position == redBall.transform.position)
            {
                blueBall.transform.position = newPos;
            }
            else if (DotCircle.transform.position == blueBall.transform.position)
            {
                redBall.transform.position = newPos;
            }
            
            if (Input.GetMouseButtonDown(0) && position.isMove)
            {
                //빨간색 원이 충돌시 해당 타일 이미지 변경
                if (DotCircle.transform.position == redBall.transform.position)
                {
                    DotCircle.transform.position = tiles.map[position.tilenum].transform.position;
                    blueBall.transform.position = DotCircle.transform.position;
                }
                else if (DotCircle.transform.position == blueBall.transform.position)
                {
                    DotCircle.transform.position = tiles.map[position.tilenum].transform.position;
                    redBall.transform.position = DotCircle.transform.position;

                    tiles.map[position.tilenum].gameObject.GetComponent<SpriteRenderer>().sprite = moveTile;
                }
                //화면상의 초기 원위치 설정
                if (DotCircle.transform.position == redBall.transform.position)
                {
                    switch (circleDT)
                        {
                            case direction.isBottom:
                                runningTime = 1.55f;
                                break;
                            case direction.isTop:
                                runningTime = 4.65f;
                                break;
                            case direction.isLeft:
                                runningTime = 0f;
                                break;
                            case direction.isRight:
                                runningTime = 3.1f;
                                break;
                        }

                }
                else if (DotCircle.transform.position == blueBall.transform.position)
                {
                    switch (circleDT)
                    {
                        case direction.isBottom:
                            runningTime = 1.55f;
                            break;
                        case direction.isTop:
                            runningTime = 4.65f;
                            break;
                        case direction.isLeft:
                            runningTime = 0f;
                            break;
                        case direction.isRight:
                            runningTime = 3.1f;
                            break;
                    }
                }
            }
            //공이 타일에 안맞을 경우 화면의 색상 잠시동안 변경
            else if (!position.isStage1 && !position.isStage2 && !position.isStage3)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    red.enabled = true;
                }
                if (Input.GetMouseButtonUp(0))
                {
                    red.enabled = false;
                }
            }

            if (timer - nowtime >= 0.4f)
            {
                redBall.GetComponentInChildren<TrailRenderer>().enabled = true;
                blueBall.GetComponentInChildren<TrailRenderer>().enabled = true;
            }

        });
    }
    
}
