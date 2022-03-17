using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {
    public Color hoverColor;
    private Color startColor;
    private Renderer rend;
    private GameObject turret;
    void Start() {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }
    private void OnMouseEnter() {
        rend.material.color = hoverColor;
    }
    private void OnMouseExit() {
        rend.material.color = startColor;
    }
    private void OnMouseDown() {
        if (turret != null) {
            Debug.Log("Can't build here!");
            return;
        }
        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        turret = (GameObject)Instantiate(turretToBuild, transform.position+new Vector3(0,0.5f,0), transform.rotation);
    }

    // Update is called once per frame
    void Update() {

    }
}
