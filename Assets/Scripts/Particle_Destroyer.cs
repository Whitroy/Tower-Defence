using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle_Destroyer : MonoBehaviour
{
    private float Countdown = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Countdown<=0f)
        {
            Destroy(gameObject);
            return;
        }

        Countdown -= Time.deltaTime;
    }
}
