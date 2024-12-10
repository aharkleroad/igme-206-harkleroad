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
    private float wanderAngle;
    public float maxWanderAngle = 90f;
    public float maxWanderChangePerSecond = 30f;
    public float projectionRadius = 2f;

    // calculates steering forces for all children of the Agent class
    protected abstract void CalcSteeringForces();

    // calculates the steering force for seeking a specific position with a given weight
    public void Seek(Vector3 desiredPosition, float weight = 1f)
    {
        // calculate desired velocity
        desiredVelocity = Vector3.Normalize(desiredPosition - physics.Position) * maxSpeed;
        // find seeking force based on this velocity
        Vector3 seekingForce = desiredVelocity - physics.Velocity;
        seekingForce = Vector3.ClampMagnitude(seekingForce, maxForce);
        // add the seeking force to the total force applied to the agent
        totalForce += seekingForce * weight;
    }

    // calculate the steering force for randomized wandering with a given weight
    protected void Wander(float weight, float time)
    {
        //Choose a distance ahead
        Vector3 futurePos = GetFuturePosition(time);
        // find the max angle we can wander right now
        float maxWanderChange = maxWanderChangePerSecond * Time.deltaTime;
        // determine the angle we will wander
        float angleChange = Random.Range(0, maxWanderChange + 1);
        float positiveOrNegative = Random.Range(0, 2);
        // half the time, this angle is negative
        if (positiveOrNegative == 0)
        {
            angleChange = -angleChange;
        }
        // add this angle to the angle we are already wandering in
        wanderAngle += angleChange;
        wanderAngle = Mathf.Clamp(wanderAngle, -maxWanderAngle, maxWanderAngle);

        // find a place on a circle around the agent that corresponds with this angle
        futurePos.x += Mathf.Cos(wanderAngle) * projectionRadius;
        futurePos.y += Mathf.Sin(wanderAngle) * projectionRadius;
        // seek this position
        Seek(futurePos);
    }

    // applies a force to agents when they get too close to the screen edges to keep them in bounds
    protected void StayInBounds(float weight = 1f)
    {
        // seek the center of the screen if an agent would leave it in 1.5 seconds
        Vector3 futurePosition = GetFuturePosition(1.5f);
        if (futurePosition.x > 8f || futurePosition.x < -8f || 
            futurePosition.y > 5f || futurePosition.y < -5f)
        {
            Seek(Vector3.zero, weight);
        }
    }

    // find an agent's future position based on their current velocity and a given time in the future
    public Vector3 GetFuturePosition(float timeToLookAhead = 1f)
    {
        return physics.Position + (physics.Velocity * timeToLookAhead);
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        physics = GetComponent<PhysicsObject>();
        // assigns starting wander angle
        wanderAngle = Random.Range(0, Mathf.PI * 2);
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        // find the forced applied to each agent
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
