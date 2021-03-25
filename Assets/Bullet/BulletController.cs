using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public Rigidbody2D selfPos;
    public Rigidbody2D targetPos;
    public TurretController turretController;
    TargetController target;

    private void Awake() {
        turretController = GameObject.Find("Turret").GetComponent<TurretController>();
        targetPos = turretController.targetPos;
        Debug.Log(targetPos.position);
    }
    void FixedUpdate()
    {
        if (targetPos!=null) {
        Vector2 shootDir = targetPos.position - selfPos.position; 
        float angle = Mathf.Atan2(shootDir.y,shootDir.x) * Mathf.Rad2Deg-90f;
        selfPos.rotation = angle;
        selfPos.velocity = shootDir.normalized*10;
        } else {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag=="Target") {
            target = GameObject.Find(other.name).GetComponent<TargetController>();
            target.hp--;
            Destroy(gameObject);
        }
    }
    
}
