using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Agent : MonoBehaviour
{
    // field declaration
    public float maxSpeed;
    public float maxForce;
    private Vector3 totalForce = Vector3.zero;
    protected Vector3 desiredVelocity;
    protected PhysicsObject physics;
    public Agent agent;

    // abstract method for agent subclasses
    public abstract void CalcSteeringForces();

    // calculates and applies a seeking force towards a target position
    public void Seek(Vector3 desiredPosition)
    {
        // calculate seeking force based on desired velocity and bounded by max force
        desiredVelocity = Vector3.Normalize(desiredPosition - physics.Position) * maxSpeed;
        Vector3 seekingForce = desiredVelocity - physics.Velocity;
        seekingForce = Vector3.ClampMagnitude(seekingForce, maxForce);
        // adds seeking force to total force in case other forces are applied
        totalForce += seekingForce;
    }

    // applies a fleeing force away from a given position
    public void Flee(Vector3 fleeingPosition)
    {
        // calculate fleeing force based on desired velocity and bounded by max force
        desiredVelocity = Vector3.Normalize(physics.Position - fleeingPosition) * maxSpeed;
        Vector3 fleeingForce = desiredVelocity - physics.Velocity;
        fleeingForce = Vector3.ClampMagnitude(fleeingForce, maxForce);
        // adds fleeing force to total force in case other forces are applied
        totalForce += fleeingForce;
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        physics = GetComponent<PhysicsObject>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        // calculates the steering force for each agent
        CalcSteeringForces();
        totalForce = Vector3.ClampMagnitude(totalForce, maxForce);
        // apply steering force to the agent
        physics.ApplyForce(totalForce);
        totalForce = Vector3.zero;
    }
}
