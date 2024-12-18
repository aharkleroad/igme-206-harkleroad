using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    // field declaration
    private SpriteRenderer spriteRendererPlayer;
    private SpriteRenderer spriteRendererCollidable;
    private List<Enemy> enemyList;
    private List<GameObject> enemyProjectiles;
    private List<GameObject> playerProjectiles;
    public GameObject gameManager;
    private Player player;

    // collision for enemy and player objects
    public bool AABBCollision(Enemy collidable, Player colliding)
    {
        // assigns local variables
        bool isColliding = false;
        spriteRendererCollidable = collidable.GetComponent<SpriteRenderer>();
        spriteRendererPlayer = colliding.GetComponent<SpriteRenderer>();

        // checks if the sprites are within each other's bounds and makes them red if they are
        if (spriteRendererPlayer.bounds.min.x < spriteRendererCollidable.bounds.max.x &&
            spriteRendererPlayer.bounds.max.x > spriteRendererCollidable.bounds.min.x &&
            spriteRendererPlayer.bounds.min.y < spriteRendererCollidable.bounds.max.y &&
            spriteRendererPlayer.bounds.max.y > spriteRendererCollidable.bounds.min.y)
        {
            spriteRendererCollidable.color = Color.red;
            spriteRendererPlayer.color = Color.red;
            isColliding = true;
        }
        // otherwise ensures that the other sprite is colored normally
        // does not reset player sprite because it may be colliding with another object
        else
        {
            spriteRendererCollidable.color = Color.white;
        }
        return isColliding;
    }

    // collision for enemy projectiles and player
    public bool AABBCollision(GameObject collidable, Player colliding)
    {
        // assigns local variables
        bool isColliding = false;
        spriteRendererCollidable = collidable.GetComponent<SpriteRenderer>();
        spriteRendererPlayer = colliding.GetComponent<SpriteRenderer>();
        
        // checks if the sprites are within each other's bounds and makes them red if they are
        if (spriteRendererPlayer.bounds.min.x < spriteRendererCollidable.bounds.max.x &&
            spriteRendererPlayer.bounds.max.x > spriteRendererCollidable.bounds.min.x &&
            spriteRendererPlayer.bounds.min.y < spriteRendererCollidable.bounds.max.y &&
            spriteRendererPlayer.bounds.max.y > spriteRendererCollidable.bounds.min.y)
        {
            spriteRendererCollidable.color = Color.red;
            spriteRendererPlayer.color = Color.red;
            isColliding = true;
        }
        // otherwise ensures that the other sprite is colored normally
        // does not reset player sprite because it may be colliding with another object
        else
        {
            spriteRendererCollidable.color = Color.white;
        }
        return isColliding;
    }

    // collision for enemy objects and player projectiles
    public bool AABBCollision(Enemy collidable, GameObject colliding)
    {
        // assigns local variables
        bool isColliding = false;
        spriteRendererCollidable = collidable.GetComponent<SpriteRenderer>();
        spriteRendererPlayer = colliding.GetComponent<SpriteRenderer>();
        
        // checks if the sprites are within each other's bounds and makes them red if they are
        if (spriteRendererPlayer.bounds.min.x < spriteRendererCollidable.bounds.max.x &&
            spriteRendererPlayer.bounds.max.x > spriteRendererCollidable.bounds.min.x &&
            spriteRendererPlayer.bounds.min.y < spriteRendererCollidable.bounds.max.y &&
            spriteRendererPlayer.bounds.max.y > spriteRendererCollidable.bounds.min.y)
        {
            spriteRendererCollidable.color = Color.red;
            spriteRendererPlayer.color = Color.red;
            isColliding = true;
        }
        // otherwise ensures that the other sprite is colored normally
        // does not reset player sprite because it may be colliding with another object
        else
        {
            spriteRendererCollidable.color = Color.white;
        }
        return isColliding;
    }

    // collision for player and enemy projectiles
    public bool AABBCollision(GameObject collidable, GameObject colliding)
    {
        // assigns local variables
        bool isColliding = false;
        spriteRendererCollidable = collidable.GetComponent<SpriteRenderer>();
        spriteRendererPlayer = colliding.GetComponent<SpriteRenderer>();
        
        // checks if the sprites are within each other's bounds and makes them red if they are
        if (spriteRendererPlayer.bounds.min.x < spriteRendererCollidable.bounds.max.x &&
            spriteRendererPlayer.bounds.max.x > spriteRendererCollidable.bounds.min.x &&
            spriteRendererPlayer.bounds.min.y < spriteRendererCollidable.bounds.max.y &&
            spriteRendererPlayer.bounds.max.y > spriteRendererCollidable.bounds.min.y)
        {
            isColliding = true;
        }
        return isColliding;
    }

    // Start is called before the first frame update
    void Start()
    {
        // get components
        enemyList = gameManager.GetComponent<EnemySpawn>().enemyList;
        enemyProjectiles = GetComponent<EnemyProjectiles>().enemyProjectileList;
        playerProjectiles = GetComponent<PlayerProjectiles>().playerProjectiles;
    }

    // Update is called once per frame
    void Update()
    {
        // enemies have spawned
        if (enemyList != null)
        {
            int numberOfEnemies = enemyList.Count;
            // checks for collision between player and enemy objects
            for(int i = 0; i < numberOfEnemies; i++)
                {
                // each object takes damage and turns red if collision occurs
                if (AABBCollision(enemyList[i], player))
                {
                    // issue with GameObjects not having TakeDamage() method, so commented out
                    // enemyList[i].TakeDamage(player.Damage);
                    // player.TakeDamage(enemyList[i].Damage);
                    spriteRendererCollidable.color = Color.red;
                    spriteRendererPlayer.color = Color.red;
                }
            }

            // enemies have fired projectiles
            if (enemyProjectiles != null)
            {
                int numberOfEnemyProjectiles = enemyProjectiles.Count;
                // checks for collision between enemy projectiles and the player
                for(int i = 0; i < numberOfEnemyProjectiles; i++)
                {
                    if (AABBCollision(enemyProjectiles[i], player))
                    {
                        // enemyProjectiles[j].TakeDamage(player.Damage);
                        // player.TakeDamage(enemyProjectiles[j].Damage);
                        spriteRendererCollidable.color = Color.red;
                        spriteRendererPlayer.color = Color.red;
                    }
                }

                // player has fired projectiles
                if (playerProjectiles != null)
                {
                    int numberOfPlayerProjectiles = playerProjectiles.Count;
                    // checks for collision between player projectiles and enemies
                    for(int i = 0; i < numberOfPlayerProjectiles; i++)
                    {
                        for(int j = 0; j < numberOfEnemies; j++)
                        {
                            if (AABBCollision(enemyList[j], playerProjectiles[i]))
                            {
                                // enemyList[j].TakeDamage(playerProjectiles[i].Damage);
                                // playerProjectiles[i].TakeDamage(enemyList[j].Damage);
                                spriteRendererCollidable.color = Color.red;
                                spriteRendererPlayer.color = Color.red;
                            }
                        }
                    }

                    // checks for collision between player and enemy projectiles
                    for(int i = 0; i < numberOfPlayerProjectiles; i++)
                    {
                        for(int j = 0; j < numberOfEnemyProjectiles; j++)
                        {
                            if (AABBCollision(enemyProjectiles[j], playerProjectiles[i]))
                            {
                                // enemyProjectiles[j].TakeDamage(playerProjectiles[i].Damage);
                                // playerProjectiles[i].TakeDamage(enemyProjectiles[j].Damage);
                                spriteRendererCollidable.color = Color.red;
                                spriteRendererPlayer.color = Color.red;
                            }
                        }
                    }

                }
            }

        }   
    }
}
