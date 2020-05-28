using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleMove : MonoBehaviour
{
    trigger setting;
    Circle CircleAround;
    MakeList tiles;
    Menu Stop;
    GameStartUI start;

    public GameObject uncorrectPreFab;
    public GameObject Circle;
    public  GameObject DotCircle;
    public  GameObject redBall;
    public  GameObject blueBall;
    public GameObject End;
    public GameObject effectPreFab;
    public GameObject Point;
    public GameObject reCirclePoint;
    public GameObject moveDot; //이전 중점
    GameObject child;
    GameObject newEffect;
    GameObject UncorrectObj;

    public List<GameObject> effectList;       
    public bool isMove;
    public bool isClick;
    public bool isFinish;     
    public bool isUpdate;
    public bool isOnce;
    public bool isRetire;

    Transform effectHolder;
   
    Vector3 prvPosition;
    Vector3 TargetPosition;

    float distance;        

    public int moveCount;    
    int ChildCount;
    int num;
   

    public void Start()
    {
        CircleAround = GameObject.Find("circle").GetComponent<Circle>();       
        reCirclePoint = GameObject.Find("Point");
        start = GameObject.Find("Manager").GetComponent<GameStartUI>();
        tiles = GameObject.Find("Manager").GetComponent<MakeList>();
        Stop = GameObject.Find("Menu").GetComponent<Menu>();
        DotCircle = GameObject.Find("DottedCircle");
        redBall = GameObject.Find("RedBall");
        blueBall = GameObject.Find("BlueBall");
        Circle = GameObject.Find("circle");
        End = GameObject.Find("EndPoint");
        Point = GameObject.Find("PointCamera");
        effectList = new List<GameObject>();
             
        isMove = false;
        isUpdate = true;
        isRetire = true;
        isFinish = false;
        isOnce = false;
        moveCount = 0;

        string holderName = "Effect";
        effectHolder = new GameObject(holderName).transform;
        effectHolder.parent = transform;

        if (DotCircle.transform.position == redBall.transform.position)
        {
            prvPosition = blueBall.transform.position;
            distance = redBall.transform.position.x - blueBall.transform.position.x;
        }
        else if (DotCircle.transform.position == blueBall.transform.position)
        {
            prvPosition = redBall.transform.position;
            distance = blueBall.transform.position.x - redBall.transform.position.x;
        }

        newEffect = Instantiate(effectPreFab) as GameObject;       
        newEffect.transform.position = DotCircle.transform.position;
        newEffect.name = "Effect " + num;
        newEffect.transform.parent = effectHolder;
        num += 1;
        effectList.Add(newEffect);
        End.GetComponent<BoxCollider2D>().enabled = false;
        
    }

    void Update()
    {
        if (start.isGameStart)
        {
            if(Stop.isClick == false)
            {
                if (isUpdate)
                {
                    moveDot = DotCircle;
                    if (moveCount + 1 < tiles.map.Count)
                    {
                        if (!isFinish)
                        {
                            tiles.map[moveCount].GetComponent<BoxCollider2D>().enabled = false;

                            if (tiles.map[moveCount].transform.childCount != 0)
                            {
                                tiles.map[moveCount].GetComponentInChildren<BoxCollider2D>().enabled = false;
                            }

                            tiles.map[moveCount + 1].GetComponent<BoxCollider2D>().enabled = true;

                            if (tiles.map[moveCount + 1].GetComponent<BoxCollider2D>().enabled == true)
                            {
                                if (tiles.map[moveCount + 1].transform.childCount == 1)
                                {
                                    child = tiles.map[moveCount + 1].transform.GetChild(0).gameObject;
                                    child.GetComponent<BoxCollider2D>().enabled = true;
                                }
                            }

                            if (tiles.map[tiles.count - 1].GetComponent<BoxCollider2D>().enabled == true)
                            {
                                End.GetComponent<BoxCollider2D>().enabled = true;
                            }
                        }
                    }

                    if (DotCircle.transform.position == redBall.transform.position)
                    {
                        setting = GameObject.Find("BlueBall").GetComponent<trigger>();
                    }
                    else if (DotCircle.transform.position == blueBall.transform.position)
                    {
                        setting = GameObject.Find("RedBall").GetComponent<trigger>();
                    }

                    if (Input.GetMouseButtonDown(0))
                    {
                        if (isMove == true && isFinish == false)
                        {
                            move();
                            moveCount += 1;
                            newEffect = Instantiate(effectPreFab) as GameObject;
                            newEffect.transform.position = DotCircle.transform.position;
                            newEffect.name = "Effect " + num;
                            newEffect.transform.parent = effectHolder;
                            num += 1;
                            effectList.Add(newEffect);                       
                            Point.transform.position = DotCircle.transform.position;
                        }
                        if (isMove == false)
                        {                            
                            isUpdate = false;
                            
                            if (DotCircle.transform.position == blueBall.transform.position)
                            {
                                UncorrectObj = Instantiate(uncorrectPreFab) as GameObject;
                                UncorrectObj.transform.position = redBall.transform.position;
                                //  redBall.GetComponent<SpriteRenderer>().sprite = UnCorrect;
                            }
                            if (DotCircle.transform.position == redBall.transform.position)
                            {
                                UncorrectObj = Instantiate(uncorrectPreFab) as GameObject;
                                UncorrectObj.transform.position = blueBall.transform.position;
                                //  blueBall.GetComponent<SpriteRenderer>().sprite = UnCorrect;
                            }
                        }

                        if (isFinish == true)
                        {
                            if (isOnce == false)
                            {
                                move();
                                newEffect = Instantiate(effectPreFab) as GameObject;
                                newEffect.transform.position = DotCircle.transform.position;
                                newEffect.name = "Effect " + num;
                                newEffect.transform.parent = effectHolder;
                                num += 1;
                                effectList.Add(newEffect);
                                isOnce = true;
                            }
                        }
                    }
                }
            }
        }
    }

    public void move()
    {        
        if (DotCircle.transform.position == blueBall.transform.position)
        {
            DotCircle.transform.position = tiles.map[moveCount + 1].transform.position;
            redBall.transform.position = DotCircle.transform.position;
            reCirclePoint.transform.position = blueBall.transform.position;
                  
        }
        else if (DotCircle.transform.position == redBall.transform.position)
        {
            DotCircle.transform.position = tiles.map[moveCount + 1].transform.position;
            blueBall.transform.position = DotCircle.transform.position;
            reCirclePoint.transform.position = redBall.transform.position;
                 
        }
        if (DotCircle.transform.position == redBall.transform.position)
        {
            prvPosition = blueBall.transform.position;
        }
        else if (DotCircle.transform.position == blueBall.transform.position)
        {
            prvPosition = redBall.transform.position;
        }
      
    }
}