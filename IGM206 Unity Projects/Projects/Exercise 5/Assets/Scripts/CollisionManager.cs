using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class CollisionManager : MonoBehaviour
{
    // field declaration
    private SpriteRenderer spriteRendererPlayer;
    private SpriteRenderer spriteRendererCollidable;
    // switches between methods of collision detection
    public bool isUsingAABB = true;
    // prints collision method detection
    public GameObject textDisplay;
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
        // otherwise ensures that the other sprite is colored normally
        // does not reset player sprite because it may be colliding with another object
        else
        {
            spriteRendererCollidable.color = Color.white;
        }
        return isColliding;
    }

    // detects collision using circle bounding method
    public bool CircleCollision(GameObject collidable)
    {
        // variable declaration
        bool isColliding = false;
        // checks if the distance between the player and another sprite is larger than the combined radii of their bounding circles (collision occurring)
        // colors both sprites red if they are
        spriteRendererCollidable = collidable.GetComponent<SpriteRenderer>();
        if (Math.Pow(spriteRendererPlayer.bounds.center.x - spriteRendererCollidable.bounds.center.x, 2)  +
            Math.Pow(spriteRendererPlayer.bounds.center.y - spriteRendererCollidable.bounds.center.y, 2) <
            spriteRendererPlayer.bounds.extents.magnitude + spriteRendererCollidable.bounds.extents.magnitude)
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

    // changes the collision method when the user presses the "change collision method" button
    public void ChangeCollision()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            // switches from AABB to bounding circle and changes prompt text
            if (isUsingAABB)
            {
                isUsingAABB = false;
                textDisplay.GetComponent<TextMesh>().text = "Using bounding circle collision. Left click to change";
            }
            // switches from bounding circle to AABB and changes prompt text
            else
            {
                isUsingAABB = true;
                textDisplay.GetComponent<TextMesh>().text = "Using AABB collision. Left click to change";
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // accesses the sprite renderer for the player
        spriteRendererPlayer = playerObject.GetComponent<SpriteRenderer>();
        textDisplay.GetComponent<TextMesh>().text = "Using AABB collision. Left click to change";
    }

    // Update is called once per frame
    void Update()
    {
        // checks if the user changed the collision method
        ChangeCollision();
        // checks for collision with each vehicle using the correct method (AABB or Bounding Circle)
        // if there is no collision, it ensures that the player vehicle is colored normally
        if (isUsingAABB)
        {
            if (!AABBCollision(collidable1) && !AABBCollision(collidable2) && !AABBCollision(collidable3))
            {
                spriteRendererPlayer.color = Color.white;
            }
        }
        else
        {
            if (!CircleCollision(collidable1) && !CircleCollision(collidable2) && !CircleCollision(collidable3))
            {
                spriteRendererPlayer.color = Color.white;
            }
        }
    }
}
