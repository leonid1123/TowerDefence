using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;
    private Transform target;
    private int wayPointIndex = 0;
    public GameObject enemyBoomObj;
    private int hp = 2;
    void Start()
    {
        target = Waypoints.waypoints[wayPointIndex];
    }

    void Update()
    {
        if (hp == 2)
        {
            transform.localScale = Vector3.one*2;
        }
        if (hp == 1)
        {
            transform.localScale = Vector3.one;
        }
        if (hp == 0)
        {
            Destroy(gameObject);
        }
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed*Time.deltaTime,Space.World);
        if (Vector3.Distance(transform.position, target.position) < speed * Time.deltaTime)
        {
            ChangeWayPointIndex();
        }
    }
    void ChangeWayPointIndex()
    {
        if(wayPointIndex >= Waypoints.waypoints.Length - 1)
        {
            Destroy(gameObject);
            return;
        }
        wayPointIndex++;
        target = Waypoints.waypoints[wayPointIndex];
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag =="bullet" )
        {
            GameObject enemyBoom = (GameObject)Instantiate(enemyBoomObj,transform.position,transform.rotation);
            Destroy(enemyBoom,2f);
            hp--;
        }
    }
}
