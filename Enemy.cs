using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5f;
    public float health = 100f;
    //public int damage = 10;
	private bool isDead = false;

    private Transform target;
    private int wavepointIdx = 0;

    public GameObject enemyPrefab;
    float currTime = 0f;
    

    
    // Start is called before the first frame update
    void Start()
    {
        target = WayPoints.points[0];
    }

    // Update is called once per frame
    void Update()
    {
         currTime += Time.deltaTime;

        // 오브젝트를 몇초마다 생성할 것인지 조건문으로 만든다. 여기서는 10초로 했다.
        if (currTime > 10) {
              // x,y,z 좌표값을 각각 다른 범위에서 랜덤하게 정해지도록 만들었다.
              float newX = Random.Range(-10f, 10f);
              float newY = Random.Range(-50f, 50f);
              float newZ = Random.Range(-100f, 100f);

              // 생성할 오브젝트를 불러온다.
              Instantiate(enemyPrefab);

              // 불러온 오브젝트를 랜덤하게 생성한 좌표값으로 위치를 옮긴다.
              enemyPrefab.transform.position = new Vector3(newX, newY, newZ);

              // 시간을 0으로 되돌려주면, 10초마다 반복된다.
              currTime = 0;
        }    


        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.5f)
        {
            GetNextWayPoint();
        }
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

    void GetNextWayPoint()
    {
        if (wavepointIdx >= WayPoints.points.Length - 1)
        {
            EndPath();
            return;
        }
        target = WayPoints.points[++wavepointIdx];
    }

    void EndPath() {
        Destroy(gameObject);
    }

}
