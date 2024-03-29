using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    private float speed = 40f;
    public GameObject boom;
         
    public void Seek(Transform _target)
    {
        target = _target;
    }
    // Start is called before the first frame update
    void Start()
    {
        var dir = (target.position - transform.position).normalized;
        gameObject.GetComponent<Rigidbody>().velocity = dir * speed;

    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        GameObject boomObj = (GameObject)Instantiate(boom,transform.position,transform.rotation);
        Destroy(boomObj,2f);
        if (other.tag == "Enemy")
        {
            Destroy(gameObject);
            return;
        }
    }
}
