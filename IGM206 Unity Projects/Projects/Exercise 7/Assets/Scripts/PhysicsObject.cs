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
    public float mass;
    public bool isFrictionApplied;
    public bool isGravityApplied;
    public float coefficentOfFriction;
    public float strengthOfGravity;
    public float maxSpeed;

    // applies frictional force to GameObjects
    public void ApplyFriction()
    {
        // direction of friction opposes velocity
        Vector3 friction = -velocity;
        friction.Normalize();
        // calculates magnitude of the force
        friction *= coefficentOfFriction;
        // adjusts acceleration based on calculated force
        acceleration += friction / mass;
    }

    // applies a given gravitational force to GameObjects
    public void ApplyGravity()
    {
        acceleration += gravity * strengthOfGravity;
    }

    // has the monsters bounce when they begin to exit the game window
    public void Bounce()
    {
        // reverses x velocity if they hit the left or right of the game window
        if (position.x > 8f || position.x < -8f)
        {
            position.x = 8 * Mathf.Sign(position.x);
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
        // applies force from the mouse to the GameObject
        acceleration += GetComponent<MouseTracker>().MousePuller(position) / mass;
        // applies gravity if enabled
        if (isGravityApplied)
        {
            ApplyGravity();
        }
        // applies friction if enabled
        if (isFrictionApplied)
        {
            ApplyFriction();
        }
        // adjusts velocity
        velocity += acceleration * Time.deltaTime;
        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);
        // ensures the monsters bounce off the edges of the screen if they encounter them
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