using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;
    private void Start() {
        buildManager = BuildManager.instance;
    }
   public void PurchaseStandartTurret() {
       Debug.Log("standart Turret");
       buildManager.SetTurretToBuild(buildManager.standartTurretPrefab);
   }
   public void PurchaseAnotherTurret() {
       Debug.Log("another Turret");
       buildManager.SetTurretToBuild(buildManager.anotherTurretPrefab);
   }
}
