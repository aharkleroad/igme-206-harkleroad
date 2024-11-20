using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsSHMUP : MonoBehaviour
{
    // field declaration
    private Vector3 position;
    private Vector3 direction;
    private Vector3 velocity;
    private Vector3 acceleration;
    private Vector3 gravity;
    public float mass;
    public bool isGravityApplied;
    public float strengthOfGravity;
    public float maxSpeed;

    // applies a given gravitational force to GameObjects
    public void ApplyGravity()
    {
        acceleration += gravity * strengthOfGravity;
    }

    // has the plane bounce when it begins to exit the game window
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

    // allows player input to change the acceleration of the plane
    public void ChangeAcceleration(Vector3 playerInput)
    {
        acceleration += playerInput;
    }

    // Start is called before the first frame update
    void Start()
    {
        gravity = new Vector3(0, -1, 0);
        position = new Vector3(6, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        // applies gravity if enabled
        if (isGravityApplied)
        {
            ApplyGravity();
        }
        // adjusts velocity
        velocity += acceleration * 30 * Time.deltaTime;
        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);
        // ensures the monsters bounce off the edges of the screen if they encounter them
        Bounce();
        // adjusts position and direction accordingly
        position += velocity * Time.deltaTime;
        direction = velocity.normalized;
        position.z = 0f;
        transform.position = position;
        transform.rotation = Quaternion.LookRotation(Vector3.back, direction);
        // resets acceleration calculation
        acceleration = Vector3.zero;
    }
}