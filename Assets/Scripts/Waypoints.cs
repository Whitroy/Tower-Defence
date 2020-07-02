using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public static Transform[] Waypoint;

    // Start is called before the first frame update
    void Awake()
    {
        Waypoint = new Transform[transform.childCount];

        for(int x=0;x<transform.childCount;x++)
        {
            Waypoint[x] = transform.GetChild(x).transform;
        }
    }

    // Update is called once per frame
    void Update()
    {        
    }
}
