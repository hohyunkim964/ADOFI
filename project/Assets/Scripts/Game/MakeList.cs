using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MakeList : MonoBehaviour
{
    public int count;
    public List<GameObject> map;
    GameObject tiles;

    private void Start()
    {
        GameObject[] tag = GameObject.FindGameObjectsWithTag("Horizontal");
        GameObject[] tag1 = GameObject.FindGameObjectsWithTag("Vertical");
        GameObject[] tag2 = GameObject.FindGameObjectsWithTag("CurveLT");
        GameObject[] tag3 = GameObject.FindGameObjectsWithTag("CurveLD");
        GameObject[] tag4 = GameObject.FindGameObjectsWithTag("CurveRD");
        GameObject[] tag5 = GameObject.FindGameObjectsWithTag("CurveRT");
        count = tag.Length + tag1.Length + tag2.Length + tag3.Length + tag4.Length + tag5.Length;

        map = new List<GameObject>();
        
        for (int i = 0; i < count; i++)
        {
            tiles = GameObject.Find(i.ToString());
            tiles.GetComponent<BoxCollider2D>().enabled = false;
            map.Add(tiles);
        }        
    }
}
