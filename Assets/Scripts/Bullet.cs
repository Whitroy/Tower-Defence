using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject particlePrefab;

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
    }

    private void HitTarget()
    {
        Instantiate(particlePrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
        Destroy(_Target.gameObject);
    }
}
