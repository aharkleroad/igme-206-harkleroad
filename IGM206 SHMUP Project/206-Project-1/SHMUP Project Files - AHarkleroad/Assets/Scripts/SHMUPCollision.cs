using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class SHMUPCollision : MonoBehaviour
{
    // field declaration
    private SpriteRenderer spriteRendererPlayer;
    private SpriteRenderer spriteRendererCollidable;
    public GameObject playerObject;
    public GameObject collidable;

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
        // otherwise ensures that the other sprite is colored normally
        // does not reset player sprite because it may be colliding with another object
        else
        {
            spriteRendererCollidable.color = Color.white;
        }
        return isColliding;
    }

    // Start is called before the first frame update
    void Start()
    {
        // accesses the sprite renderer for the player
        spriteRendererPlayer = playerObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // checks for collision with each vehicle using the correct method  
        if (!AABBCollision(collidable))
        {
            spriteRendererPlayer.color = Color.white;
        }
    }
}