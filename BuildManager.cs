using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    public GameObject standardTurretPrefab;

    private GameObject turretToBuild;

public GameObject GetTurretToBuild()
{
    return turretToBuild;
}

private void Awake()
{
    if (instance != null)
    {
        Debug.LogError("More than one BuildManager in scene!");
        return;
    }

    instence = this;
}

void Start()
    {
        turretToBuild = standardTurretPrefab;
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    public void SelectTurretToBuild(TurretBluePrint turret)
    {
        TurretToBuild = turret; 
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionoffset;
    }

    public bool CanBuild
    {
        get { return turretToBuild != null; }
    }

    private void OnMouseEnter()
    {
        if(EventSystem.current.IsPointerOverGameObject())
            return;
        if(!BuildManager.CanBuild) 
            return;
        render.material.color = haveColor;
    }

    private void OnMouseDown()
    {
        if (!BuildManager.CanBuild)
            return;

        if (turret != null)
        {
            Debug.Log("we can't build here");
            return;
        }

        BuildManager.BuildTurretOn(this);
    }
}
