using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    // field declaration
    public float damage;
    public float health;
    public bool isGameOver = false;
    // time required between shots
    private float timeToFire = 0.3f;
    // tracks time since last shot
    public float timeBetweenFire = 0f;
    public GameObject player;
    private MovementController movementController;
    private PlayerProjectiles projectiles;
    public GameObject projectilePrefab;

    protected void TakeDamage(int damage)
    {
        health -= damage;
    }

    // fires projectiles when spacebar is clicked
    public void OnFire(InputAction.CallbackContext context)
    {
        // does not fire when button released
        if (context.canceled)
        {
            return;
        }
        // only fires after a set amount of time
        if (timeToFire <= timeBetweenFire)
        {
            // instantiates bullet when fired
            GameObject bullet = Instantiate(projectilePrefab, 
                new Vector3(movementController.objectPosition.x, movementController.objectPosition.y, 0f), Quaternion.identity);
            projectiles.playerProjectiles.Add(bullet);
            timeBetweenFire = 0f;
        }
    }

    // checks if a game over condition has been reached
    private bool GameOverCheck()
    {
        return (health <= 0 || movementController.objectPosition.x > 10f);
    }

    // Start is called before the first frame update
    void Start()
    {
        movementController = player.GetComponent<MovementController>();
    }

    // Update is called once per frame
    void Update()
    {
        // get rid of the player if game is over
        if(GameOverCheck())
        {
            Destroy(player);
            isGameOver = true;
        }
        // add time to "stopwatch"
        timeBetweenFire += Time.deltaTime;
    }
}
