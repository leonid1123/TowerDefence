using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {
    public Color hoverColor;
    private Color startColor;
    private Renderer rend;
    private GameObject turret;
    BuildManager buildManager;
    void Start() {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;
    }
    private void OnMouseEnter() {
        if (buildManager.GetTurretToBuild() == null) {
            return;
        }
        rend.material.color = hoverColor;
    }
    private void OnMouseExit() {
        rend.material.color = startColor;
    }
    private void OnMouseDown() {
        if (buildManager.GetTurretToBuild() == null) {
            return;
        }
        if (turret != null) {
            Debug.Log("Can't build here!");
            return;
        }
        GameObject turretToBuild = buildManager.GetTurretToBuild();
        turret = (GameObject)Instantiate(turretToBuild, transform.position+new Vector3(0,0.5f,0), transform.rotation);
        buildManager.SetTurretToBuild(null);
    }

    // Update is called once per frame
    void Update() {

    }
}
