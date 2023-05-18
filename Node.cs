using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    private GameObject turret;
    private Renderer render;
    public Color hoverColor;
    private Color startColor;
    public Vector3 positionoffset;
    private void OnMouseEnter()
    {
        render.material.color = hoverColor;
    }
    private void OnMouseExit()
    {
        render.material.color = startColor;
    }
    private void OnMouseDown()
    {
        if (turret != null)
        {
            Debug.Log("we can't build here");
            return;
        }
        
        GameObject turretToBuild = buildmanager.instance.GetTurretToBuild();
        turret = (GemeObject)Instantiate(turretToBuild, transform.position + positionoffset, transform.rotation);
    }

    // Start is called before the first frame update
    void Start()
    {
        render = GetGomponent<Renderer>();
        startColor = render.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
