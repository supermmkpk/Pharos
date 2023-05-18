using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBluePrint standardTurret;
    public TurretBluePrint missileLauncher;

    BuildManager buildManager;

    private void Start()
    {
        buildManager = buildManager.instance;
    }
    public void selectStandardTurret()
    {
        Debug.Log("Standard Turret Selected");
        buildManager.selectTurretToBuild(standardTurret);
    }
    public void selectMissileLauncher()
    {
        Debud.Log("Missile Launcher Selected");
        buildManager.selectTurretToBuild(missileLauncher);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
