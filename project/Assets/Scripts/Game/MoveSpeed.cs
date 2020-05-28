using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSpeed : MonoBehaviour
{   
    Circle circle;
    public float speed;
    public float BPM;

    void Start()
    {
        BPM = BPM / 60;
        circle = GameObject.Find("circle").GetComponent<Circle>();
        speed = ((2 * (circle.radius * Mathf.PI) * 1 / 2) / BPM) * 10;
    }   
}
