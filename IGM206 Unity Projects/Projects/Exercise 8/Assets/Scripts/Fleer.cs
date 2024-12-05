using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fleer : Agent
{
    // field declaration
    protected PhysicsObject fleeingPhysics;

    // flees from the seeker and teleports if caught
    public override void CalcSteeringForces()
    {
        // flees
        Flee(fleeingPhysics.Position);
        // transports to a random position when a collision occurs
        if (physics.CircleCollision())
        {
            // generates random coordinates in bounds
            float xCoordinate = Random.Range(-7, 8);
            float yCoordinate = Random.Range(-4, 5);
            physics.Position = new Vector3(xCoordinate, yCoordinate, 0);
        }
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        fleeingPhysics = agent.GetComponent<PhysicsObject>();
    }

    // Update is called once per frame
    protected override void Update()
    {
       base.Update();
    }
}
