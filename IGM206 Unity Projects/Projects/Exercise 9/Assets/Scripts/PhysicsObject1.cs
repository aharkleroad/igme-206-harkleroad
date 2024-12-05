using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PhysicsObject : MonoBehaviour
{
    // field declaration
    private bool isColliding;
    public GameObject referernceObject;
    public GameObject collidable;
    private SpriteRenderer spriteRendererReference;
    private SpriteRenderer spriteRendererCollidable;
    private Vector3 position;
    private Vector3 direction;
    private Vector3 velocity;
    private Vector3 acceleration;
    private Vector3 gravity;
    public float mass;
    private float radius;
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
        ApplyForce(friction);
    }

    // applies a given gravitational force to GameObjects
    public void ApplyGravity()
    {
        acceleration += gravity * strengthOfGravity;
    }

    public void ApplyForce(Vector3 force)
    {
        acceleration += force / mass;
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

    public bool CircleCollision()
    {
        // checks if the distance between the player and another sprite is larger than the combined radii of their bounding circles (collision occurring)
        // colors both sprites red if they are
         Debug.Log("Is being called");
        if (Math.Pow(spriteRendererReference.bounds.center.x - spriteRendererCollidable.bounds.center.x, 2)  +
            Math.Pow(spriteRendererReference.bounds.center.y - spriteRendererCollidable.bounds.center.y, 2) <
            spriteRendererReference.bounds.extents.magnitude + spriteRendererCollidable.bounds.extents.magnitude)
        {
            isColliding = true;
             Debug.Log("Is true");
        }
        // otherwise ensures that the other sprite is colored normally
        // does not reset player sprite because it may be colliding with another object
        else
        {
            isColliding = false;
             Debug.Log("Is false");
        }
        return isColliding;
    }

    // Start is called before the first frame update
    void Start()
    {
        gravity = new Vector3(0, -1, 0);
        spriteRendererReference = referernceObject.GetComponent<SpriteRenderer>();
        spriteRendererCollidable = collidable.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
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
        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);        // ensures the monsters bounce off the edges of the screen iif they encounter them
        Bounce();
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