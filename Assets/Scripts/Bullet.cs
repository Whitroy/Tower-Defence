using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject particlePrefab;
    public float explosionRadius;
    public int damage = 50;
    private float _bulletSpeed = 70f;
    private Transform _Target;
    public void Seek(Transform Target)
    {
        _Target = Target;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_Target==null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = _Target.position - transform.position;

        float distancetobeTravelledperFrame = _bulletSpeed * Time.deltaTime;

        if(dir.magnitude<=distancetobeTravelledperFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distancetobeTravelledperFrame, Space.World);
        transform.LookAt(_Target);
    }

    private void HitTarget()
    {
        Instantiate(particlePrefab, transform.position, Quaternion.identity);

        if(explosionRadius>0f)
        {
            Explode();
        }
        else
        {
            Damage(_Target);
        }

        Destroy(gameObject);
    }

    void Damage(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();

        if(e!=null)
            e.TakeDamage(damage);

    }

    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach  (Collider collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
