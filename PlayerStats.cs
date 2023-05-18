using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int money;

    public int startMoney = 400;
    // Start is called before the first frame update
    void Start()
    {
        this.money = startMoney;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BuildTurretOn(Node node)
    {
        if (PlayerStats.Money < turretToBuild.cost)
        {
            Debug.Log("not enough money to build that!");
            return;
        }

        PlayerStats.mondy -= turretToBuild.cost;

        GameObject turret = (GameObject)Instantiate(turretToBuild.Prefab, node.GetBuildPosition(), Quaternion.identify);
        node.turret = turret;

        Debug.Log("Turret build! Money left : " + PlayerStats.money);
    }
}
