using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    PlayerMotion circle;
    Camera mainCamera;
    PlayerCollsion trigger;    
    Vector3 viewCamera;
    public GameObject DotCircle;
    public GameObject redBall;
    public GameObject blueBall;
    bool isZoom;
    float timer;

    void Start()
    {
        circle = GameObject.Find("circle").GetComponent<PlayerMotion>();
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();  
        DotCircle = GameObject.Find("DottedCircle");
        redBall = GameObject.Find("RedBall");
        blueBall = GameObject.Find("BlueBall");
        timer = 0.0f;

        viewCamera = transform.position;
    }
      
    void Update()
    {
        if (DotCircle.transform.position == redBall.transform.position)
        {
            trigger = blueBall.GetComponent<PlayerCollsion>();
        }
        else if (DotCircle.transform.position == blueBall.transform.position)
        {
            trigger = redBall.GetComponent<PlayerCollsion>();
        }

        if (trigger.isMove)
        {            
            //카메라 줌인 줌아웃 관련
            if (Input.GetMouseButtonDown(0))
            {
                timer += Time.deltaTime;
                mainCamera.fieldOfView -= 5.0f;
                isZoom = true;                
            }
            else
            {
                mainCamera.fieldOfView = 60;
                isZoom = false;
            }
        }
    }
}
