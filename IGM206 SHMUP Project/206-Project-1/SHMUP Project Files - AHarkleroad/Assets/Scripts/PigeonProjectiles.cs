using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigeonProjectiles : EnemyProjectiles
{
    protected override void CalcSteeringForces()
    {
        physics.ApplyGravity();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
