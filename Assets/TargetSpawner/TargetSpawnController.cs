using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawnController : MonoBehaviour
{
    GameObject Target;// Start is called before the first frame update
    void Start()
    {
        Target = (GameObject)Resources.Load("prefabs/Target", typeof(GameObject));
        InvokeRepeating("Spawn",1f,3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Spawn() {
        Instantiate(Target,transform.position,Quaternion.identity);
    }
}
