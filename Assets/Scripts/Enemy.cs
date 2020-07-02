using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Transform target;
    int waypointIndex = 0;
    [SerializeField]
    float Speed = 5f;
    Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        target = Waypoints.Waypoint[0];
    }

    // Update is called once per frame
    void Update()
    {
        direction = (target.position - transform.position).normalized;

        transform.Translate(direction*Speed*Time.deltaTime, Space.World);

        if(Vector3.Distance(target.position,transform.position)<=.2f)
        {
            GetNextWaypoint();
        }
    }

    private void GetNextWaypoint()
    {
        if(waypointIndex>=Waypoints.Waypoint.Length-1)
        {
            Destroy(gameObject);
            return;
        }

        waypointIndex++;
        target = Waypoints.Waypoint[waypointIndex];
    }
}
