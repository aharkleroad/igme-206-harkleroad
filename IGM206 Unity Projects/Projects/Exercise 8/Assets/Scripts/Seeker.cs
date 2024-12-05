using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seeker : Agent
{
    // field declaration
    protected PhysicsObject seekingPhysics;

    // seeks towards the fleeing agent's position
    public override void CalcSteeringForces()
    {
        Seek(seekingPhysics.Position);
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        seekingPhysics = agent.GetComponent<PhysicsObject>();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
}
