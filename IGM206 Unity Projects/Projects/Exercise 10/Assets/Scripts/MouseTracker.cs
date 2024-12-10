using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MouseTracker : MonoBehaviour
{
    // field declaration
    private Camera cam;
    private Vector2 mousePosition;
    private Vector3 pointTo;

    // applies a force on a GameObject towards the mouse
    public Vector3 MousePuller(Vector3 objectPosition)
    {
        // finds the position of the mouse relative to the game world
        mousePosition = Mouse.current.position.ReadValue();
        pointTo = cam.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, cam.nearClipPlane));
        // finds the vector between the mouse and physics object
        // this will be applied as a force in PhysicsObject
        Vector3 force = pointTo - objectPosition;
        return force;
    }

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {

    }
}