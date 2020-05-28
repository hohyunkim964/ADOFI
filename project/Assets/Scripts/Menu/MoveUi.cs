using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveUi : MonoBehaviour
{
    PlayerMotion circle;
    PlayerCollsion position;
    public GameObject StageLogo1;
    public GameObject StageLogo2;
    public GameObject StageLogo3;
    public GameObject DotCircle;
    public GameObject redBall;
    public GameObject blueBall;
    GameObject stage1Effect;
    GameObject stage2Effect;
    GameObject stage3Effect;
    GameObject map;
    SpriteRenderer Stage1image;
    SpriteRenderer Stage2image;
    SpriteRenderer Stage3image;

    bool isStage1Up;
    bool isStage2Up;
    bool isStage3Up;
    bool RotationLeft;

    void Start()
    {
        circle = GameObject.Find("circle").GetComponent<PlayerMotion>();
        Stage1image = GameObject.Find("Stage1Loge").GetComponent<SpriteRenderer>();
        Stage2image = GameObject.Find("Stage2Loge").GetComponent<SpriteRenderer>();
        Stage3image = GameObject.Find("Stage3Loge").GetComponent<SpriteRenderer>();
        DotCircle = GameObject.Find("DottedCircle");
        redBall = GameObject.Find("RedBall");
        blueBall = GameObject.Find("BlueBall");
        StageLogo1 = GameObject.Find("Stage1Loge");
        StageLogo2 = GameObject.Find("Stage2Loge");
        StageLogo3 = GameObject.Find("Stage3Loge");
        map = GameObject.Find("Map");

        stage1Effect = StageLogo1.transform.GetChild(0).gameObject;
        stage2Effect = StageLogo2.transform.GetChild(0).gameObject;
        stage3Effect = StageLogo3.transform.GetChild(0).gameObject;

        RotationLeft = true;
        isStage1Up = false;
        isStage2Up = false;
        isStage3Up = false;
        
        InvokeRepeating("MenuLogMove", 0f, 0.1f);
    }

    void Update()
    {
        //스테이지 로고 주변의 효과 자동 회전
        stage1Effect.transform.Rotate(Vector3.forward,0.1f);
        stage2Effect.transform.Rotate(Vector3.forward, 0.1f);
        stage3Effect.transform.Rotate(Vector3.forward, 0.1f);
         //각각의 스테이지 포인트에서 스테이지로 이동하는 씬 전환 관련
        if (position.isStage1 == true)
        {
            Stage1image.color = new Color(Stage1image.color.r, Stage1image.color.g, Stage1image.color.b, 0.9f);

            if (Input.GetMouseButtonDown(0))
            {
                SoundManager.Instance.Stop();
                SceneManager.LoadScene(1);
            }
            if (Input.GetMouseButtonDown(0) && position.isMove)
            {
                position.isStage1 = false;
            }
        }
        else
        {
            Stage1image.color = new Color(Stage1image.color.r, Stage1image.color.g, Stage1image.color.b, 1.0f);
        }

        if (position.isStage2 == true)
        {            
            Stage2image.color = new Color(Stage2image.color.r, Stage2image.color.g, Stage2image.color.b, 0.9f);

            if (Input.GetMouseButtonDown(0))
            {
                SoundManager.Instance.Stop();
                SceneManager.LoadScene(8);
            }
            if (Input.GetMouseButtonDown(0) && position.isMove)
            {
                position.isStage2 = false;
            }            
        }
        else
        {
            Stage2image.color = new Color(Stage2image.color.r, Stage2image.color.g, Stage2image.color.b, 1.0f);
        }

        if (position.isStage3 == true)
        {
            Stage3image.color = new Color(Stage3image.color.r, Stage3image.color.g, Stage2image.color.b, 0.9f);

            if (Input.GetMouseButtonDown(0))
            {
                SoundManager.Instance.Stop();
                SceneManager.LoadScene(12);
            }
            if (Input.GetMouseButtonDown(0) && position.isMove)
            {
                position.isStage3 = false;
            }
        }
        else
        {
            Stage3image.color = new Color(Stage3image.color.r, Stage3image.color.g, Stage3image.color.b, 1.0f);
        }
    }

    void MenuLogMove()
    {        
        if (DotCircle.transform.position == redBall.transform.position)
        {
            position = blueBall.GetComponent<PlayerCollsion>();
        }
        else if (DotCircle.transform.position == blueBall.transform.position)
        {
            position = redBall.GetComponent<PlayerCollsion>();
        }
        //각각의 스테이지 로고 상하 이동 및 플레이어 원이 도달시 정지 관련 
        if (!isStage1Up && !position.isStage1)
        {
            StageLogo1.transform.position = new Vector3(StageLogo1.transform.position.x, StageLogo1.transform.position.y - 0.05f);
            if (StageLogo1.transform.position.y <= -0.2f)
            {
                isStage1Up = true;
            }

        }

        if (!isStage2Up && !position.isStage2)
        {
            StageLogo2.transform.position = new Vector3(StageLogo2.transform.position.x, StageLogo2.transform.position.y - 0.05f);
            if (StageLogo2.transform.position.y <= -0.2f)
            {
                isStage2Up = true;
            }
        }

        if (!isStage3Up && !position.isStage3)
        {
            StageLogo3.transform.position = new Vector3(StageLogo3.transform.position.x, StageLogo3.transform.position.y - 0.05f);
            if (StageLogo3.transform.position.y <= -0.2f)
            {
                isStage3Up = true;
            }
        }

        if (isStage1Up && !position.isStage1)
        {

            StageLogo1.transform.position = new Vector3(StageLogo1.transform.position.x, StageLogo1.transform.position.y + 0.05f);
            if (StageLogo1.transform.position.y >= 0.2f)
            {
                isStage1Up = false;
            }
        }

        if (isStage2Up && !position.isStage2)
        {
            StageLogo2.transform.position = new Vector3(StageLogo2.transform.position.x, StageLogo2.transform.position.y + 0.05f);
            if (StageLogo2.transform.position.y >= 0.2f)
            {
                isStage2Up = false;
            }
        }

        if (isStage3Up && !position.isStage3)
        {
            StageLogo3.transform.position = new Vector3(StageLogo3.transform.position.x, StageLogo3.transform.position.y + 0.05f);
            if (StageLogo3.transform.position.y >= 0.2f)
            {
                isStage3Up = false;
            }
        }
    }

    public void changeSceen()
    {    
        //위의 사운드 버튼 클릭 시 씬 전환
        SoundManager.Instance.Stop();
        SceneManager.LoadScene(19);
    }
}
