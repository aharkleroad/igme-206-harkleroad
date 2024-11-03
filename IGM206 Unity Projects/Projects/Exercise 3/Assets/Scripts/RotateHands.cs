using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private float turnAmount = 2 * Mathf.PI / (60*60); 
    public bool useDeltaTime;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion rotationAngle;
        // uses either delta time or a set number of frames to rotate the hand around the clock once per minute
        if (useDeltaTime)
        {
            turnAmount -= 2 * Mathf.PI * Time.deltaTime;
            rotationAngle = Quaternion.Euler(0, 0, turnAmount);
        }
        else
        {
            turnAmount -= 2 * Mathf.PI;
            // this frame rate worked in my Unity project, it may be much faster on other machines
            rotationAngle = Quaternion.Euler(0, 0, turnAmount / 240);
        }
        transform.rotation = rotationAngle;
    }
}
