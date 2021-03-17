using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    public Rigidbody2D[] points;
    public Rigidbody2D selfPos;
    public int destination = 0;
    public int hp = 5000;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        selfPos.position = Vector2.MoveTowards(selfPos.position,points[destination].position,0.015f);
        if (Vector2.Distance(points[destination].position,selfPos.position)<=0.01) {
            destination++;
            if (destination>=5) destination=0;
        }
        if (hp<=0) {
            Destroy(gameObject);
        }
    
    }
            
}
