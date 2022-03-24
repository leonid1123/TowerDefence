using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    private GameObject turretToBuild;
    public GameObject standartTurretPrefab;
    public GameObject anotherTurretPrefab;
    private void Awake()
    {
        instance = this;
    }

    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }
    public void SetTurretToBuild(GameObject turret) {
        turretToBuild = turret;
    }
}
