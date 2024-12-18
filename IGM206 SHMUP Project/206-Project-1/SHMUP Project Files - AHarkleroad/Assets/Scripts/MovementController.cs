using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// used to set and update the vehicles position
public class MovementController : MonoBehaviour
{
    // field declaration
    public Vector3 objectPosition = Vector3.zero;
    public float speed = 4f;
    // direction changed from (1, 0, 0) in slides to stop it from sliding right immediately
    private Vector3 direction = Vector3.zero;
    private Vector3 velocity = Vector3.zero;
    private bool isWind;

     public void Bounce()
    {
        // reverses x velocity if they hit the left of the game window
        // can drift off the right end as loose condition
        if (objectPosition.x < -7.5f)
        {
            objectPosition.x = -7.5f;
            velocity.x = -velocity.x;
        }
        // reverses y velocity if they hit the bottom or top of the game window
        else if (objectPosition.y > 5f || objectPosition.y < -5f)
        {
            objectPosition.y = 5 * Mathf.Sign(objectPosition.y);
            velocity.y = -velocity.y;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // sets the object's position
        objectPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //isWind = GetComponent<EnemySpawn>().isWind;
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
        // if (isWind)
        // {
        //     velocity.x -= 2f;
        // }
        Bounce();
        objectPosition += velocity;
        transform.position = objectPosition;
        // Set the vehicle�s rotation to match the direction
        transform.rotation = Quaternion.LookRotation(Vector3.back, direction);
    }

    // sets the direction vector equal to a given vector
    public void SetDirection(Vector3 vector)
    {
        direction = vector;
    }
}
