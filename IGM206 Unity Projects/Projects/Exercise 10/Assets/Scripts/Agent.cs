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
    private float wanderAngle;
    public float maxWanderAngle = 90f;
    public float maxWanderChangePerSecond = 30f;
    public float projectionRadius = 2f;


    protected abstract void CalcSteeringForces();

    public void AvoidObstacles(List<GameObject> obstacles, float weight)
    {
        foreach (GameObject obstacle in Obstacles)
        {
            
        }
    }

    public void Seek(Vector3 desiredPosition, float weight = 1f)
    {
        desiredVelocity = Vector3.Normalize(desiredPosition - physics.Position) * maxSpeed;
        Vector3 seekingForce = desiredVelocity - physics.Velocity;
        seekingForce = Vector3.ClampMagnitude(seekingForce, maxForce);
        totalForce += seekingForce * weight;
    }

    protected void Wander(float weight, float time)
    {
        //Choose a distance ahead
        Vector3 futurePos = GetFuturePosition(time);
        float maxWanderChange = maxWanderChangePerSecond * Time.deltaTime;
        float minWanderChange = maxWanderChange * -1;
        wanderAngle += Random.Range(minWanderChange, maxWanderChange + 1);
        Debug.Log("Wander " + wanderAngle);
        float minWanderAngle = maxWanderAngle * -1;
        wanderAngle = Mathf.Clamp(wanderAngle, minWanderAngle, maxWanderAngle);
        Debug.Log("Wander " + wanderAngle);

        futurePos.x += Mathf.Cos(wanderAngle) * projectionRadius;
        futurePos.y += Mathf.Sin(wanderAngle) * projectionRadius;

        Vector3 targetPos = futurePos;
        Seek(targetPos);
    }

    protected void StayInBounds(float weight = 1f)
    {
        Vector3 futurePosition = GetFuturePosition(1.5f);
        if (futurePosition.x > 8f || futurePosition.x < -8f || 
            futurePosition.y > 5f || futurePosition.y < -5f)
        {
            Seek(Vector3.zero, weight);
        }
    }

    public Vector3 GetFuturePosition(float timeToLookAhead = 1f)
    {
        Debug.Log("Velocity " + physics.Velocity);
        return physics.Position + (physics.Velocity * timeToLookAhead);
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        physics = GetComponent<PhysicsObject>();
        wanderAngle = Random.Range(0, Mathf.PI * 2);
        Debug.Log("Wander angle " + wanderAngle);
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        CalcSteeringForces();
        totalForce = Vector3.ClampMagnitude(totalForce, maxForce);
        Debug.Log(totalForce);
        physics.ApplyForce(totalForce);
        // objects rotate towards the direction they travel
        physics.Direction = Vector3.Normalize(physics.Velocity);
        transform.rotation = Quaternion.LookRotation(Vector3.back, physics.Direction);
        // reduce force to zero to calculate again next frame
        totalForce = Vector3.zero;
    }
}
