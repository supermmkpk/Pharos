using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static float speed = 5f;
    public float health = 100f;
    //public int damage = 10;
    public GameObject enemyPrefab;
    

	private bool isDead = false;
   // private int wavepointIdx = 0;

    void Update() {
        // if(gameObject.transform.position.x == 0f && gameObject.transform.position.y == 0f && gameObject.transform.position.z == 0f)
        //      Destroy(gameObject);
        // Vector3 dir = target.position - transform.position;
        // transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        // if (Vector3.Distance(transform.position, target.position) <= 0.5f)
        // {
        //     GetNextWayPoint();
        // }
    }

    public void TakeDamage (float damage)
	{
		health -= damage;

		if (health <= 0 && !isDead)
		{
			Die();
		}
	}
    void Die() {
        isDead = true;
        Destroy(gameObject);
    }

    // void GetNextWayPoint()
    // {
    //     if (wavepointIdx >= WayPoints.points.Length - 1)
    //     {
    //         EndPath();
    //         return;
    //     }
    //     target = WayPoints.points[++wavepointIdx];
    // }

    // void EndPath() {
    //     Destroy(gameObject);
    // }

}
