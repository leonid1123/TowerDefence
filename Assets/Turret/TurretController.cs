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
    public List<int> targetsID;
    //public Dictionary<int, Rigidbody2D> allTargets = new Dictionary<int, Rigidbody2D>();
    private void Start() {
       targets = new List<Rigidbody2D>();
       targetsID = new List<int>();
    }
    private void Update() {
        if (targets.Count>0 && !LockOn) {
            LockOn = true;
            InvokeRepeating("BulletFire",0.1f,0.7f);
        } else if (targets.Count==0) {
            CancelInvoke("BulletFire");
            LockOn = false;
        } 
    }
    private void FixedUpdate() {

        if (targets.Count>0){
            targetPos = targets.ElementAt(0);
            Vector2 shootDir = targets[0].position - selfPos.position;
            float angle = Mathf.Atan2(shootDir.y,shootDir.x) * Mathf.Rad2Deg;
            selfPos.rotation = angle;
        } 
        if (targets.Count>0) { 
            bool toDelete = targetPos.GetComponent<TargetController>().dead;
            if (toDelete) {
                int pos = targetPos.GetComponent<TargetController>().myID;
                targetsID.RemoveAt(pos);
                targets.RemoveAt(pos); 
            }
        }
    }
    void BulletFire() {   
        
        Instantiate(bullet, firePoint.position, Quaternion.identity); //todo add parent!
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Target") {
            targets.Add(GameObject.Find(other.name).GetComponent<Rigidbody2D>());
            targetsID.Add(GameObject.Find(other.name).GetInstanceID());
        }

    }
    private void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Target") {
            int exitID = GameObject.Find(other.name).GetInstanceID();
            int pos = targetsID.IndexOf(exitID);
            targetsID.RemoveAt(pos);
            targets.RemoveAt(pos);            
        }
    }
}
