using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wanderer : Agent
{
    [Min(1f)]
    public float wanderWeight = 1f;
    [Min(1f)]
    public float stayInBoundsWeight = 3f;

    protected override void CalcSteeringForces()
    {
        Wander(wanderWeight);
        StayInBounds(stayInBoundsWeight);
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
}
