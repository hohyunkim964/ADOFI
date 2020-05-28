using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class trigger : MonoBehaviour
{
    MoveSpeed moveSpeed;
    int tilenum;
    public bool Change;
    public GameObject tile;
    Circle AroundCircle;
    CircleMove circle;
    MakeList tiles;
    public float speed;


    private void Start()
    {     
        moveSpeed = GameObject.Find("GameManager").GetComponent<MoveSpeed>();
        tiles = GameObject.Find("Manager").GetComponent<MakeList>();       
        circle = GameObject.Find("circle").GetComponent<CircleMove>();
        AroundCircle = GameObject.Find("circle").GetComponent<Circle>();
        Change = false;
        tilenum = 0;
        speed = moveSpeed.speed;
    }

  

    private void OnTriggerStay2D(Collider2D other)
    {       
        circle.isMove = true;

      

        for (int i = 0; i < tiles.map.Count; i++)
        {
            if (circle.moveDot.transform.position == tiles.map[i].transform.position)
            {
                tilenum = i;
                break;
            }
        }

        if (other.gameObject.tag == "UpSpeed")
        {
            if (circle.DotCircle.transform.position == other.gameObject.transform.position)
            {
                AroundCircle.speed = AroundCircle.speed * 2.0f;
                other.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }
        }

        if (other.gameObject.tag == "DownSpeed")
        {
            if (circle.DotCircle.transform.position == other.gameObject.transform.position)
            {
                AroundCircle.speed = AroundCircle.speed * 0.5f;
                other.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }
        }

        if (other.gameObject.tag == "DoubleDownSpeed")
        {
            if (circle.DotCircle.transform.position == other.gameObject.transform.position)
            {
                AroundCircle.speed = AroundCircle.speed * 0.25f;
                other.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }         
        }

        if (other.gameObject.tag == "DoubleUpSpeed")
        {
            if (circle.DotCircle.transform.position == other.gameObject.transform.position)
            {
                AroundCircle.speed = AroundCircle.speed * 4.0f;
                other.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }
        }

        if (other.gameObject.tag == "changeTop")
        {
            if (circle.DotCircle.transform.position == other.gameObject.transform.position)
            {
                Change = true;
            }
        }

        if (other.gameObject.tag == "changeDown")
        {
            if (circle.DotCircle.transform.position == other.gameObject.transform.position)
            {
                Change = false;
            }
        }

        if (other.gameObject.tag == "End")
        {
           
                circle.isFinish = true;
           
        }
        
        if (other.gameObject.tag == "CurveLD")
        {          
            if (tiles.map[tilenum].tag == "Horizontal")
            {
                AroundCircle.circleDT = direction.isLeft;
            }
            else if (tiles.map[tilenum].tag == "Vertical")
            {
                AroundCircle.circleDT = direction.isTop;
            }
            else if (tiles.map[tilenum].tag == "CurveLT")
            {
                AroundCircle.circleDT = direction.isTop;
            }
            else if (tiles.map[tilenum].tag == "CurveRD")
            {
                AroundCircle.circleDT = direction.isLeft;
            }
            else if (tiles.map[tilenum].tag == "CurveRT")
            {
                AroundCircle.circleDT = direction.isLeft;
            }            
        }

        if (other.gameObject.tag == "CurveLT")
        {               
            if (tiles.map[tilenum].tag == "Horizontal")
            {
                AroundCircle.circleDT = direction.isLeft;
            }
            else if (tiles.map[tilenum].tag == "Vertical")
            {
                AroundCircle.circleDT = direction.isBottom;
            }
            else if (tiles.map[tilenum].tag == "CurveLD")
            {
                AroundCircle.circleDT = direction.isBottom;
            }
            else if (tiles.map[tilenum].tag == "CurveRT")
            {
                AroundCircle.circleDT = direction.isLeft;
            }
            else if (tiles.map[tilenum].tag == "CurveRD")
            {
                AroundCircle.circleDT = direction.isLeft;
            } 
        }

        if (other.gameObject.tag == "CurveRD")
        {
            if (tiles.map[tilenum].tag == "Horizontal")
            {
                AroundCircle.circleDT = direction.isRight;
            }
            else if (tiles.map[tilenum].tag == "Vertical")
            {
                AroundCircle.circleDT = direction.isTop;
            }
            else if (tiles.map[tilenum].tag == "CurveLD")
            {
                AroundCircle.circleDT = direction.isRight;
            }
            else if (tiles.map[tilenum].tag == "CurveLT")
            {
                if (tiles.map[tilenum].transform.position.y < tiles.map[tilenum + 1].transform.position.y - 0.8f)
                {
                    AroundCircle.circleDT = direction.isTop;
                }
                else {
                    AroundCircle.circleDT = direction.isRight;
                }
            }
            else if (tiles.map[tilenum].tag == "CurveRT")
            {
                AroundCircle.circleDT = direction.isTop;
            }
        }
             
        if (other.gameObject.tag == "CurveRT")
        {
            if (tiles.map[tilenum].tag == "Horizontal")
            {
                AroundCircle.circleDT = direction.isRight;
            }
            else if (tiles.map[tilenum].tag == "Vertical")
            {
                AroundCircle.circleDT = direction.isBottom;
            }
            else if (tiles.map[tilenum].tag == "CurveLD")
            {
                if (tiles.map[tilenum].transform.position.y > tiles.map[tilenum + 1].transform.position.y)
                {
                    AroundCircle.circleDT = direction.isBottom;
                }
                else
                {
                    AroundCircle.circleDT = direction.isRight;
                }
            }
            else if (tiles.map[tilenum].tag == "CurveLT")
            {
                AroundCircle.circleDT = direction.isRight;
            }
            else if (tiles.map[tilenum].tag == "CurveRD")
            {
                AroundCircle.circleDT = direction.isBottom;
            }             
        }

        if (other.gameObject.tag == "Vertical")
        {              
            if (tiles.map[tilenum].tag == "CurveLD")
            {
                AroundCircle.circleDT = direction.isBottom;
            }
            else if (tiles.map[tilenum].tag == "CurveLT")
            {
                AroundCircle.circleDT = direction.isTop;
            }
            else if (tiles.map[tilenum].tag == "CurveRD")
            {
                AroundCircle.circleDT = direction.isBottom;
            }
            else if (tiles.map[tilenum].tag == "CurveRT")
            {
                AroundCircle.circleDT = direction.isTop;
            }  
        }

        if (other.gameObject.tag == "Horizontal")
        {               
            if (tiles.map[tilenum].tag == "CurveLD")
            {
                 AroundCircle.circleDT = direction.isRight;
            }
            else if (tiles.map[tilenum].tag == "CurveLT")
            {
                 AroundCircle.circleDT = direction.isRight;
            }
            else if (tiles.map[tilenum].tag == "CurveRD")
            {
                 AroundCircle.circleDT = direction.isLeft;
            }
            else if (tiles.map[tilenum].tag == "CurveRT")
            {
                 AroundCircle.circleDT = direction.isLeft;
            }
        }

        tile = other.gameObject;
        /////////////////////////////////////////////////////////
       

    }

    private void OnTriggerExit2D(Collider2D collision)
    {        
        circle.isMove = false;
        tile = null;
    }
}
