using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wanderer : Agent
{
    [Min(1f)]
    public float wanderWeight = 1f;
    [Min(1f)]
    public float stayInBoundsWeight = 5f;

    protected override void CalcSteeringForces()
    {
        Wander(wanderWeight, 1f);
        StayInBounds(stayInBoundsWeight);
    }
}
