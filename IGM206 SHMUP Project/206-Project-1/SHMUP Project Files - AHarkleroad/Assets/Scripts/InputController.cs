using System;
using System.Collections;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using UnityEngine;

// detects player input and updates the vehicles heading and rotation
// allows movement to be updated next frame
public class InputController : MonoBehaviour
{
    // variable declaration
    private Vector3 inputDirection = new Vector3(0, 0, 0);
    private MovementController myMovementController;

    // sets the direction vector and applies it to the movement controller for the next frame
    public void OnMove(InputAction.CallbackContext context)
    {
        inputDirection = context.ReadValue<Vector2>();
        myMovementController.SetDirection(inputDirection);
    }

    // Start is called before the first frame update
    void Start()
    {
        // allows you to reference the MovementController
        myMovementController = GetComponent<MovementController>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
