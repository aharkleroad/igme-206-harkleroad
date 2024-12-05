using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Agent : MonoBehaviour
{
    public float maxSpeed;
    public float maxForce;
    public Vector3 position;
    protected Vector3 direction;
    protected Vector3 velocity;
    protected Vector3 desiredVelocity;
    protected Vector3 acceleration;
    protected PhysicsObject physics;

    public abstract void CalcSteeringForces();

    public Vector3 Seek(Vector3 desiredPosition)
    {
        desiredVelocity = Vector3.Normalize(desiredPosition - position) * maxSpeed;
        Vector3 seekingForce = desiredVelocity - velocity;
        seekingForce = Vector3.ClampMagnitude(seekingForce, maxForce);
        return seekingForce;
    }

    public Vector3 Flee(Vector3 fleeingPosition)
    {
        desiredVelocity = Vector3.Normalize(position - fleeingPosition) * maxSpeed;
        Vector3 fleeingForce = desiredVelocity - velocity;
        fleeingForce = Vector3.ClampMagnitude(fleeingForce, maxForce);
        return fleeingForce;
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        physics = GetComponent<PhysicsObject>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        Debug.Log("In update");
        CalcSteeringForces();
        // objects rotate towards the direction they travel
        Vector3 direction = Vector3.Normalize(velocity);
        transform.rotation = Quaternion.LookRotation(Vector3.back, direction);
    }
}
