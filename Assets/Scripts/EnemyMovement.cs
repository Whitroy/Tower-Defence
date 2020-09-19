using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    Transform target;
    int waypointIndex = 0;

    Enemy enemy;

    Vector3 direction;

    void Start()
    {
        enemy = GetComponent<Enemy>();
        target = Waypoints.Waypoint[0];
    }

    // Update is called once per frame
    void Update()
    {
        direction = (target.position - transform.position).normalized;

        transform.Translate(direction * enemy.Speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(target.position, transform.position) <= .2f)
        {
            GetNextWaypoint();
        }

        enemy.Speed = enemy.startSpeed;
    }

    private void GetNextWaypoint()
    {
        if (waypointIndex >= Waypoints.Waypoint.Length - 1)
        {
            EndPath();
            return;
        }

        waypointIndex++;
        target = Waypoints.Waypoint[waypointIndex];
    }

    void EndPath()
    {
        playerStats.Lives--;
        Destroy(gameObject);
    }
}
