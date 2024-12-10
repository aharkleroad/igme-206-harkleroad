using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wanderer : Agent
{
    // field declaration
    [Min(1f)]
    public float wanderWeight = 1f;
    [Min(1f)]
    public float stayInBoundsWeight = 3f;

    // find the steering forces applied to the wander agent
    protected override void CalcSteeringForces()
    {
        Wander(wanderWeight, 1f);
        StayInBounds(stayInBoundsWeight);
    }
}
