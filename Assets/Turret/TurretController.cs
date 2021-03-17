using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TurretController : MonoBehaviour
{
    public Rigidbody2D targetPos;
    public Rigidbody2D selfPos;
    public GameObject bullet;
    public Transform firePoint;
    private bool LockOn = false;

    public List<Rigidbody2D> targets;
    private void Start() {
       targets = new List<Rigidbody2D>();
    }
    private void Update() {
        if (targets.Count>0 && !LockOn) {

            targetPos = targets.ElementAt(0);
            LockOn = true;
            InvokeRepeating("BulletFire",0.1f,0.7f);
        } else if (targets.Count==0) {
            CancelInvoke("BulletFire");
            LockOn = false;
        }
        
    }
    private void FixedUpdate() {
        if (targetPos!=null){
            Vector2 shootDir = targetPos.position - selfPos.position;
            float angle = Mathf.Atan2(shootDir.y,shootDir.x) * Mathf.Rad2Deg;
            selfPos.rotation = angle;
        }  
    }
    void BulletFire() {   
        
        Instantiate(bullet, firePoint.position, Quaternion.identity); //todo add parent!
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Target") {
            targets.Add(GameObject.Find(other.name).GetComponent<Rigidbody2D>());
        }
        /*
        if (other.tag == "Target" && !LockOn) {
            LockOn = true;
            other.tag = "CurrentTarget";
            InvokeRepeating("BulletFire",0.1f,0.7f);
            Debug.Log("fire!");
            targetPos = GameObject.Find(other.name).GetComponent<Rigidbody2D>();
        }
        */

    }
    private void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Target") {
            targets.RemoveAt(0);
        }
        
        /*if (other.name == "Target") {
            CancelInvoke("BulletFire");
            Debug.Log("stop Fire");
        }*/
        /*
        if (other.tag == "CurrentTarget") {
            other.tag = "Target";
            CancelInvoke("BulletFire");
            LockOn = false;
        } */
    }

}
