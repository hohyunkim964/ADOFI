using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public enum direction
{
    isTop,
    isBottom,
    isLeft,
    isRight,
    isHorizontal,
    isVertical
};

public class Circle : MonoBehaviour
{
    MoveSpeed moveSpeed;
    public direction circleDT;
    GameStartUI start;    
    CircleMove inGame;
    Menu Stop;

    public bool isEnd;
    public GameObject DotCircle;
    public GameObject redBall;
    public GameObject blueBall;   
   
  
   
    trigger CircleAround;

    public bool isOnce;
    bool isChange;
    bool isFirst;
    float CollsionRunningTime;

    Vector2 prvPos;

    [Header("속도, 반지름")]
    public float speed;
    [SerializeField] [Range(0f, 10f)] public float radius;
  
    public float runningTime = 0;
    float x;
    float y;
    private Vector2 newPos = new Vector2();

    float nowTime;
    float PrvTime;
   
    void Start()
    {
        circleDT = direction.isLeft;
        moveSpeed = GameObject.Find("GameManager").GetComponent<MoveSpeed>();
        Stop = GameObject.Find("Menu").GetComponent<Menu>();        
      
        start = GameObject.Find("Manager").GetComponent<GameStartUI>();
        inGame = GameObject.Find("circle").GetComponent<CircleMove>();        
      
        DotCircle = GameObject.Find("DottedCircle");
        redBall = GameObject.Find("RedBall");
        blueBall = GameObject.Find("BlueBall");
        isChange = false;
        isFirst = true;
       
        isOnce = false;
        isEnd = false;
        speed = moveSpeed.speed;
        DotCircle.transform.GetChild(1).gameObject.SetActive(false);
        radius = 0.75f;
        CollsionRunningTime = 6.2f;

        this.UpdateAsObservable()
        .Subscribe(_ =>
        {
            if (start.isGameStart)
            {
                if (Stop.isClick == false)
                {
                    if (inGame.isUpdate)
                    {
                        if (DotCircle.transform.position == redBall.transform.position)
                        {
                            CircleAround = GameObject.Find("BlueBall").GetComponent<trigger>();

                        }
                        else if (DotCircle.transform.position == blueBall.transform.position)
                        {
                            CircleAround = GameObject.Find("RedBall").GetComponent<trigger>();

                        }

                        runningTime += Time.deltaTime * speed;


                        if (CircleAround.Change == false)
                        {
                            x = radius * Mathf.Sin((90 * (Mathf.PI / 180)) + runningTime);
                            y = radius * Mathf.Cos((90 * (Mathf.PI / 180)) + runningTime);
                        }
                        else
                        {
                            x = radius * Mathf.Cos(runningTime);
                            y = radius * Mathf.Sin(runningTime);
                        }

                        newPos = new Vector2(-x + DotCircle.transform.position.x, -y + DotCircle.transform.position.y);

                        if (isFirst)
                        {
                            prvPos = newPos;
                            isFirst = false;
                        }

                        if (!inGame.isFinish)
                        {
                            if (Input.GetMouseButtonDown(0))
                            {
                                isChange = true;
                                isFirst = true;
                            }
                        }

                        if (DotCircle.transform.position == redBall.transform.position && isChange == false)
                        {
                            blueBall.transform.position = newPos;
                        }
                        else if (DotCircle.transform.position == blueBall.transform.position && isChange == false)
                        {
                            redBall.transform.position = newPos;
                        }

                        if (DotCircle.transform.position == redBall.transform.position && isChange)
                        {
                            switch (circleDT)
                            {
                                case direction.isBottom:
                                    runningTime = 1.55f;
                                    CollsionRunningTime = 7.75f;
                                    break;
                                case direction.isTop:
                                    runningTime = 4.65f;
                                    CollsionRunningTime = 10.85f;
                                    break;
                                case direction.isLeft:
                                    runningTime = 0f;
                                    CollsionRunningTime = 6.2f;
                                    break;
                                case direction.isRight:
                                    runningTime = 3.1f;
                                    CollsionRunningTime = 9.3f;
                                    break;
                            }
                            isChange = false;
                        }
                        else if (DotCircle.transform.position == blueBall.transform.position && isChange)
                        {
                            switch (circleDT)
                            {
                                case direction.isBottom:
                                    runningTime = 1.55f;
                                    CollsionRunningTime = 7.75f;
                                    break;
                                case direction.isTop:
                                    runningTime = 4.65f;
                                    CollsionRunningTime = 10.85f;
                                    break;
                                case direction.isLeft:
                                    runningTime = 0f;
                                    CollsionRunningTime = 6.2f;
                                    break;
                                case direction.isRight:
                                    runningTime = 3.1f;
                                    CollsionRunningTime = 9.3f;
                                    break;
                            }
                            isChange = false;
                        }

                        if (inGame.isFinish != true)
                        {
                            if (runningTime >= CollsionRunningTime)
                            {
                                inGame.isUpdate = false;
                            }
                        }
                    }


                    if (inGame.isUpdate == false)
                    {
                        if (DotCircle.transform.position == redBall.transform.position)
                        {
                            CircleAround = GameObject.Find("BlueBall").GetComponent<trigger>();

                        }

                        else if (DotCircle.transform.position == blueBall.transform.position)
                        {
                            CircleAround = GameObject.Find("RedBall").GetComponent<trigger>();

                        }

                        radius -= 0.08f;
                        if (radius <= 0.0f)
                        {
                            radius = 0.0f;
                        }

                        runningTime += Time.deltaTime * speed;

                        if (CircleAround.Change == false)
                        {
                            x = radius * Mathf.Sin((90 * (Mathf.PI / 180)) + runningTime);
                            y = radius * Mathf.Cos((90 * (Mathf.PI / 180)) + runningTime);
                        }
                        else
                        {
                            x = radius * Mathf.Cos(runningTime);
                            y = radius * Mathf.Sin(runningTime);
                        }

                        newPos = new Vector2(-x + DotCircle.transform.position.x, -y + DotCircle.transform.position.y);

                        if (radius > 0.0f)
                        {
                            if (DotCircle.transform.position == redBall.transform.position && isChange == false)
                            {
                                blueBall.transform.position = newPos;
                            }
                            else if (DotCircle.transform.position == blueBall.transform.position && isChange == false)
                            {
                                redBall.transform.position = newPos;
                            }
                        }
                        else
                        {
                            if (DotCircle.transform.childCount > 1)
                            {
                                DotCircle.transform.GetChild(1).gameObject.SetActive(true);
                            }
                            else
                            {
                                isEnd = true;
                            }
                        }
                    }
                }               
            }
        });

        
    }
    //버튼에 따라 속도 변경
    public void SpeedUp()
    {
        if (start.isGameStart)
        {
            speed += 0.1f;
        }
    }
    public void SpeedDown()
    {
        if (start.isGameStart)
        {
            speed -= 0.1f;
        }
    }
}
