using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    public Rigidbody2D[] points;
    public Rigidbody2D selfPos;
    public int destination = 0;
    public int hp = 5;
    public float speed=1;
    public int myID;
    public bool dead = false;
    void Start()
    {
        
    }
    void Update()
    {
        selfPos.position = Vector2.MoveTowards(selfPos.position,points[destination].position,0.015f*speed);
        if (Vector2.Distance(points[destination].position,selfPos.position)<=0.01) {
            destination++;
            if (destination>=points.Length) destination=0;
        }
        if (hp<=0) {
            myID = gameObject.GetInstanceID();
            dead = true;
            Destroy(gameObject);
        }
    
    }
            
}
