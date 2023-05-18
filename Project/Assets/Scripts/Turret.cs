using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public float range = 15f;
    public string enemyTag = "Enemy";
    public Transform centerPoint;

    private Transform target; 

    
    void Start() {
        InvokeRepeating("updateTarget", 0f, 0.5f);
    }
    void Update() {
        if(target == null)
            return;

        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = lookRotation.eulerAngles;
        centerPoint.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    void updateTarget() {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach(GameObject enemy in enemies) {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy < shortestDistance) {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if(nearestEnemy != null && shortestDistance <= range)
            target = nearestEnemy.transform;
        else 
            target = null;
    }
    void OnTriggerEnter(Collider other) {
        if(other.transform.tag == enemyTag) {
            Destroy(other.gameObject);
        }
    }
    void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

}
