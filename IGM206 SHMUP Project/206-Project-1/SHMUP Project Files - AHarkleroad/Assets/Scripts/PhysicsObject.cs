using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsObject : MonoBehaviour
{
    // field declaration
    private Vector3 position;
    private Vector3 direction;
    private Vector3 velocity;
    private Vector3 acceleration;
    private Vector3 gravity;
    private Vector3 force;
    public float mass;
    public float strengthOfGravity;
    public float maxSpeed;

    // gets and sets object's position
    public Vector3 Position
    {
        get {return position;}
        set {position = value;}
    }

    // gets and sets object's direction
    public Vector3 Direction
    {
        get {return direction;}
        set {direction = value;}
    }

    // gets and sets object's velocity
    public Vector3 Velocity
    {
        get {return velocity;}
        set {velocity = value;}
    }

    // applies a force to an object's acceleration
    public void ApplyForce(Vector3 force)
    {
        acceleration = force / mass;
    }

    // applies a given gravitational force to GameObjects
    public void ApplyGravity()
    {
        acceleration += gravity * strengthOfGravity;
    }

    // Start is called before the first frame update
    void Start()
    {
        gravity = new Vector3(0, -1, 0);
        position = transform.position;
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
        position.z = 0f;
        transform.position = position;
        // resets acceleration calculation
        acceleration = Vector3.zero;
    }
}