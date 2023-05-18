using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    public float speed = 70f;

    public int damage = 50;
    public Rigidbody bulletRigidbody;

    public GameObject bulletEffect;

    private float explosionRadius = 0f;

    void Start()
    {
        // bulletRigidbody = GetComponent<Rigidbody>();
        // bulletRigidbody.velocity = transform.forward*speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed + Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    void Damage(Transform enemy) {
      Enemy e = enemy.GetComponent<Enemy>();

		if (e != null)
		{
			e.TakeDamage(damage);
		}
    }
    
    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    }

    void HitTarget()
    {
        GameObject instantBulletEffect =
            (GameObject) Instantiate(bulletEffect, transform.position, transform.rotation);
        Destroy(instantBulletEffect, 0.5f);

        if (explosionRadius > 0f)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }

        Destroy(gameObject);
    }
    /*void HitTarget()
    {
        GameObject instantBulletEffect = (GameObject)Instantiate(bulletEffect, transform.position, transform.rotation);
        Destroy(instantBulletEffect, 1f);
        Destroy(target.gameObject);
        Destroy(gameObject);
    }*/
    
    public void Seek(Transform _target)
    {
        target = _target;
    }
    // Start is called before the first frame update
    
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
    
}
