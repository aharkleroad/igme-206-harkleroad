using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigeonProjectiles : EnemyProjectiles
{
    // modifies acceleration for pigeon projectiles (just caused by gravity)
    protected override void CalcSteeringForces()
    {
        physics.ApplyGravity();
    }

    // Start is called before the first frame update
    protected void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
