using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectiles : MonoBehaviour
{
    public float maxSpeed;
    public float maxForce;
    protected Vector3 totalForce;
    protected Vector3 desiredLocation;
    protected Vector3 desiredVelocity;
    protected PhysicsObject physics;

    public Vector3 DesiredLocation
    {
        get {return desiredLocation;}
    }

    protected abstract void CalcSteeringForces();

    public void Seek(Vector3 desiredPosition)
    {
        // calculate desired velocity
        desiredVelocity = Vector3.Normalize(desiredPosition - physics.Position) * maxSpeed;
        // find seeking force based on this velocity
        Vector3 seekingForce = desiredVelocity - physics.Velocity;
        seekingForce = Vector3.ClampMagnitude(seekingForce, maxForce);
        // add the seeking force to the total force applied to the agent
        totalForce += seekingForce;
    }

    // Start is called before the first frame update
    void Start()
    {
        physics = GetComponent<PhysicsObject>();
    }

    // Update is called once per frame
    void Update()
    {
        CalcSteeringForces();
        totalForce = Vector3.ClampMagnitude(totalForce, maxForce);
        // apply the force to the agent
        physics.ApplyForce(totalForce);
        // rotate agents towards the direction they travel
        physics.Direction = Vector3.Normalize(physics.Velocity);
        transform.rotation = Quaternion.LookRotation(Vector3.back, physics.Direction);
        // reduce force to zero to calculate again next frame
        totalForce = Vector3.zero;
    }
}