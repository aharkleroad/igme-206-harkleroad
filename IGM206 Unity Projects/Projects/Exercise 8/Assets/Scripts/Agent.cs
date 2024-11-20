using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Agent : MonoBehaviour
{
    public float maxSpeed;
    public float maxForce;
    public GameObject physics;

    public abstract void CalcSteeringForces()
    {
        
    }

    public void Seek()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        physics = GetComponent<PhysicsObject>();
    }

    // Update is called once per frame
    void Update()
    {
        CalcSteeringForces();
    }
}
