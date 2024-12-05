using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Agent : MonoBehaviour
{
    public float maxSpeed;
    public float maxForce;
    private Vector3 totalForce = Vector3.zero;
    protected Vector3 desiredVelocity;
    protected PhysicsObject physics;
    private float wanderAngle = 0f;
    public float maxWanderAngle = 45f;
    public float maxWanderChangePerSecond = 10f;


    protected abstract void CalcSteeringForces();

    public void Seek(Vector3 desiredPosition, float weight = 1f)
    {
        Debug.Log("Seeking");
        desiredVelocity = Vector3.Normalize(desiredPosition - physics.Position) * maxSpeed;
        Debug.Log(desiredVelocity);
        Vector3 seekingForce = desiredVelocity - physics.Velocity;
        seekingForce = Vector3.ClampMagnitude(seekingForce, maxForce);
        totalForce += seekingForce * weight;
    }

    public void Flee(Vector3 fleeingPosition, float weight = 1f)
    {
        desiredVelocity = Vector3.Normalize(physics.Position - fleeingPosition) * maxSpeed;
        Vector3 fleeingForce = desiredVelocity - physics.Velocity;
        fleeingForce = Vector3.ClampMagnitude(fleeingForce, maxForce);
        totalForce += fleeingForce * weight;
    }

    protected void Wander(float weight = 1f)
    {
        Debug.Log("Wandering");
        float maxWanderChange = maxWanderChangePerSecond * Time.deltaTime;
        wanderAngle += Random.Range(-maxWanderChange, maxWanderChange + 1);
        Debug.Log(wanderAngle);
        Vector3 wanderTarget = (Quaternion.Euler(0, 0, wanderAngle) * physics.Direction.normalized) + physics.Position;
        Debug.Log(physics.Direction);
        Seek(wanderTarget, weight);
    }

    protected void StayInBounds(float weight = 1f)
    {
        Vector3 futurePosition = GetFuturePosition();
        if (physics.Position.x > 8f || physics.Position.x < -8f || 
            physics.Position.y > 5f || physics.Position.y < -5f)
        {
            Seek(Vector3.zero, weight);
        }
    }

    public Vector3 GetFuturePosition(float timeToLookAhead = 1f)
    {
        return physics.Position + (physics.Velocity * timeToLookAhead);
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        physics = GetComponent<PhysicsObject>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        CalcSteeringForces();
        totalForce = Vector3.ClampMagnitude(totalForce, maxForce);
        physics.ApplyForce(totalForce);
        // objects rotate towards the direction they travel
        physics.Direction = Vector3.Normalize(physics.Velocity);
        transform.rotation = Quaternion.LookRotation(Vector3.back, physics.Direction);
        // reduce force to zero to calculate again next frame
        totalForce = Vector3.zero;
    }
}
