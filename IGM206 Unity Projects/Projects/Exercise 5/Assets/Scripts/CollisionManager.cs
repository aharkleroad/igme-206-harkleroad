using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    // field declaration
    private SpriteRenderer spriteRendererPlayer;
    private SpriteRenderer spriteRendererCollidable;
    // switches between methods of collision detection
    public bool isUsingAABB;
    // references scene objects
    public GameObject playerObject;
    public GameObject collidable1;
    public GameObject collidable2;
    public GameObject collidable3;

    // detects collision using AABB bounding method
    public bool AABBCollision(GameObject collidable)
    {
        // assigns local variables
        bool isColliding = false;
        spriteRendererCollidable = collidable.GetComponent<SpriteRenderer>();
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
        // keeps them white otherwise
        else
        {
            spriteRendererCollidable.color = Color.white;
        }
        return isColliding;
    }

    // detects collision using circle bounding method
    public bool CircleCollision(GameObject playerObject, GameObject collidable)
    {
        bool isColliding = false;
        spriteRendererCollidable = collidable.GetComponent<SpriteRenderer>();
        if (Math.Pow(spriteRendererPlayer.bounds.center.x - spriteRendererCollidable.bounds.center.x, 2)  +
            Math.Pow(spriteRendererPlayer.bounds.center.y - spriteRendererCollidable.bounds.center.y, 2) >
            Math.Pow(2, 2))
        {
            spriteRendererCollidable.color = Color.red;
            spriteRendererPlayer.color = Color.red;
            isColliding = true;
        }
        else
        {
            spriteRendererCollidable.color = Color.white;
        }
        return isColliding;
    }

    // Start is called before the first frame update
    void Start()
    {
        spriteRendererPlayer = playerObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isUsingAABB)
        {
            if (!AABBCollision(collidable1) && !AABBCollision(collidable2) && !AABBCollision(collidable3))
            {
                spriteRendererPlayer.color = Color.white;
            }
        }
        else
        {
            if (!CircleCollision(playerObject, collidable1) && !CircleCollision(playerObject, collidable2) && !CircleCollision(playerObject, collidable3))
            {
                spriteRendererPlayer.color = Color.white;
            }
        }
    }
}
