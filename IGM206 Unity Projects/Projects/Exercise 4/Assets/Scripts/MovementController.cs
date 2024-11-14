using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// used to set and update the vehicles position
public class MovementController : MonoBehaviour
{
    // field declaration
    private Vector3 objectPosition = new Vector3(0, 0, 0);
    public float speed = 4f;
    // direction changed from (1, 0, 0) in slides to stop it from sliding right immediately
    private Vector3 direction = new Vector3(0, 0, 0);
    private Vector3 velocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        // sets the object's position
        objectPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // normalize direction
        // prevents divide by 0
        if (direction.x != 0)
        {
            direction.x /= Mathf.Sqrt(Mathf.Pow(direction.x, 2) + Mathf.Pow(direction.y, 2));
        }
        // prevents divide by 0
        if (direction.y != 0)
        {
            direction.y /= Mathf.Sqrt(Mathf.Pow(direction.x, 2) + Mathf.Pow(direction.y, 2));
        }
        // calculate velocity and position
        velocity = direction * speed * Time.deltaTime;
        objectPosition += velocity;
        transform.position = objectPosition;
        // Set the vehicle’s rotation to match the direction
        transform.rotation = Quaternion.LookRotation(Vector3.back, direction);

        // wrap around if the x or y value is off the screen
        if (objectPosition.x > 8f || objectPosition.x < -8f)
        {
            objectPosition.x = -objectPosition.x;
        }
        else if (objectPosition.y > 5f || objectPosition.y < -5f)
        {
            objectPosition.y = -objectPosition.y;
        }
    }

    // sets the direction vector equal to a given vector
    public void SetDirection(Vector3 vector)
    {
        direction = vector;
    }
}
