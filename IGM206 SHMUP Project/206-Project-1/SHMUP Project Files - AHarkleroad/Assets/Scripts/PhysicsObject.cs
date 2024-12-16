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

    public Vector3 Position
    {
        get {return position;}
        set {position = value;}
    }

    public Vector3 Direction
    {
        get {return direction;}
        set {direction = value;}
    }

    public Vector3 Velocity
    {
        get {return velocity;}
        set {velocity = value;}
    }

    public void ApplyForce(Vector3 force)
    {
        acceleration = force / mass;
    }

    // applies a given gravitational force to GameObjects
    public void ApplyGravity()
    {
        acceleration += gravity * strengthOfGravity;
    }

   public void Bounce()
    {
        // reverses x velocity if they hit the left of the game window
        // can drift off the right end as loose condition
        if (position.x < -8f)
        {
            position.x = -8f;
            velocity.x = -velocity.x;
        }
        // reverses y velocity if they hit the bottom or top of the game window
        else if (position.y > 5f || position.y < -5f)
        {
            position.y = 5 * Mathf.Sign(position.y);
            velocity.y = -velocity.y;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        gravity = new Vector3(0, -1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        // adjusts velocity
        velocity += acceleration * Time.deltaTime;
        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);
        Bounce();
        // adjusts position and direction accordingly
        position += velocity * Time.deltaTime;
        direction = velocity.normalized;
        position.z = 0f;
        transform.position = position;
        // resets acceleration calculation
        acceleration = Vector3.zero;
    }
}