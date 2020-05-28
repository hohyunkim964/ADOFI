using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    CircleMove circle;
    GameStartUI start;
    GameObject tileAttribute;
    GameObject Dotcircle;
    MakeList tiles;
    int countnum;
    bool isRotationUp;
    bool isRotationDown;
    bool isRotationRight;
    bool isRotationLeft;
    float speed;

    private void Start()
    {
        circle = GameObject.Find("circle").GetComponent<CircleMove>();
        Dotcircle = GameObject.Find("DottedCircle");
        tiles = GameObject.Find("Manager").GetComponent<MakeList>();
        start = GameObject.Find("Manager").GetComponent<GameStartUI>();
        countnum = 0;

        speed = 0.4f;
    }

    private void Update()
    {
        if (start.isGameStart)
        {
            if (Input.GetMouseButtonDown(0))
            {
                countnum += 1;
            }
        }
        //게임이 끝나지 않았을 경우 맵의 타일의 자식 오브젝트의 갯수가 0이 아닐 경우 tileAttribute을 처음의 자식 게임 오브젝트로 설정
        if (!circle.isFinish)
        {
            if (tiles.map[countnum].transform.childCount != 0)
            {
                tileAttribute = tiles.map[countnum].transform.GetChild(0).gameObject;
            }
        }

        if (tileAttribute != null)
        {
            //카메라 회전 관련한 타일자식 tag 가져온 후 bool값 변경
            if (Dotcircle.transform.position == tileAttribute.transform.position)
            {
                if (tileAttribute.tag == "RotateDown")
                {
                    isRotationDown = true;                    
                }

                if (tileAttribute.tag == "RotateTop")
                {
                    isRotationUp = true;
                }

                if (tileAttribute.tag == "RotateLeft")
                {
                    isRotationLeft = true;
                }

                if (tileAttribute.tag == "RotateRight")
                {
                    isRotationRight = true;
                }   
            }

            //실질적인 카메라 회전 구문
            if (isRotationUp)
            {
                if (this.transform.eulerAngles.z >= 90.0f)
                {
                    isRotationUp = false;
                }
                else
                {
                    this.transform.Rotate(Vector3.forward * Time.deltaTime * speed * 90f);
                }               
            }

            if (isRotationDown)
            {
                if (this.transform.eulerAngles.z >= 270.0f)
                {
                    isRotationDown = false;
                }
                else
                {
                    this.transform.Rotate(Vector3.forward * Time.deltaTime * speed * 270.0f);
                }
            }

            if (isRotationLeft)
            {
                if (this.transform.eulerAngles.z >= 180.0f)
                {
                    isRotationLeft = false;
                }
                else
                {
                    this.transform.Rotate(Vector3.forward * Time.deltaTime * speed * 180.0f);
                }
            }

            if (isRotationRight)
            {
                if (this.transform.eulerAngles.z >= 0.0f)
                {
                    isRotationRight = false;
                }
                else
                {
                    this.transform.Rotate(Vector3.forward * Time.deltaTime * speed * 0f);
                }
            }
        }
    }
}
