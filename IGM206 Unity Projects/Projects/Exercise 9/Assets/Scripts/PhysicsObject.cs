using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsObject : MonoBehaviour
{
    // field declaration
    private Vector3 position = new Vector3(0, 0, 0);
    private Vector3 direction;
    private Vector3 velocity;
    private Vector3 acceleration;
    public float mass;
    public float maxSpeed;
    protected Transform transform;

    // direction getter and setter
    public Vector3 Direction
    {
        get {return direction;}
        set {direction = value;}
    }

    // velocity getter
    public Vector3 Velocity
    {
        get {return velocity;}
    }

    // position getter and setter
    public Vector3 Position
    {
        get {return transform.position;}
        set {position = value;}
    }

    // calculate acceleration based on an object's mass and the force applied
    public void ApplyForce(Vector3 force)
    {
        acceleration = force / mass;
    }

    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
        // assign each object a random starting direction
        float randomStartAngle = Random.Range(0, Mathf.PI * 2);
        direction.x = Mathf.Cos(randomStartAngle * Mathf.Deg2Rad);
        direction.y = Mathf.Sin(randomStartAngle * Mathf.Deg2Rad);
        direction = direction.normalized;
    }

    // Update is called once per frame
    void Update()
    {
        // adjusts velocity
        velocity += acceleration * Time.deltaTime;
        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);
        // adjusts position and direction accordingly
        position += velocity * Time.deltaTime;
        direction = velocity.normalized;
        transform.rotation = Quaternion.LookRotation(Vector3.back, direction);
        position.z = 0f;
        transform.position = position;
        // resets acceleration calculation
        acceleration = Vector3.zero;
    }
}