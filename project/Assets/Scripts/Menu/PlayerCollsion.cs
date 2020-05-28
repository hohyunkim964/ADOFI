using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollsion : MonoBehaviour
{
    PlayerMotion AroundCircle;
    MakeList tiles;

    public bool isStage1;
    public bool isStage2;
    public bool isStage3;
    public bool isMove;

    public int tilenum;
    int postilenum;   

    public GameObject target;
    GameObject DotPoint;    
    GameObject Stage1Point;
    GameObject Stage2Point;
    GameObject Stage3Point;


    void Start()
    {
        AroundCircle = GameObject.Find("circle").GetComponent<PlayerMotion>();
        tiles = GameObject.Find("Manager").GetComponent<MakeList>();
        DotPoint = GameObject.Find("DottedCircle");

        Stage1Point = GameObject.Find("Stage1");
        Stage2Point = GameObject.Find("Stage2");
        Stage3Point = GameObject.Find("Stage3");

        isMove = false;
        isStage1 = false;
        isStage2 = false;
        isStage3 = false;
    }

    private void Update()
    {
        for (int i = 0; i < tiles.map.Count; i++)
        {
            if (DotPoint.transform.position == tiles.map[i].transform.position)
            {
                postilenum = i;
                break;
            }
        }
        if (postilenum + 1 <= 15)
        {
            tiles.map[postilenum + 1].GetComponent<BoxCollider2D>().enabled = true;
        }
        if (postilenum - 1 >= 0)
        {
            tiles.map[postilenum - 1].GetComponent<BoxCollider2D>().enabled = true;
        }
        for (int i = 16; i < 22; i++)
        {
            tiles.map[i].GetComponent<BoxCollider2D>().enabled = true;
        }
        if (DotPoint.transform.position == Stage1Point.transform.position)
        {
            isStage1 = true;
        }
        else if (DotPoint.transform.position == Stage2Point.transform.position)
        {
            isStage2 = true;
        }
        else if (DotPoint.transform.position == Stage3Point.transform.position)
        {
            isStage3 = true;
        }
        else
        {
            isStage1 = false;
            isStage2 = false;
            isStage3 = false;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        isMove = true;

        for (int i = 0; i < tiles.map.Count; i++)
        {
            if (tiles.map[i].name == other.name)
            {
                tilenum = i;
            }
        }
 
        
        if (other.gameObject.tag == "Horizontal")
        {
            if (Input.GetMouseButton(0))
            {
                if (tiles.map[tilenum].transform.position.x > tiles.map[postilenum].transform.position.x)
                {
                    AroundCircle.circleDT = direction.isLeft;
                }
                else
                {
                    AroundCircle.circleDT = direction.isRight;
                }
            }
        }

        if (other.gameObject.tag == "Vertical")
        {
            if (Input.GetMouseButton(0))
            {
                if (tiles.map[tilenum].transform.position.y > tiles.map[postilenum].transform.position.y)
                {
                    AroundCircle.circleDT = direction.isTop;
                }
                else
                {
                    AroundCircle.circleDT = direction.isBottom;
                }
            }
        }

            if (other.gameObject.tag == "End")
            {
                if (Input.GetMouseButtonDown(0))
                {
#if UNITY_EDITOR
                    UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); 
#endif
                }
            }      
        target = other.gameObject;
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        isMove = false;

        isStage1 = false;
        isStage2 = false;
        isStage3 = false;
    }
}
