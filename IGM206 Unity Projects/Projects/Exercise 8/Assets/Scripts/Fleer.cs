using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fleer : Agent
{
    public Seeker fleeing;
    private Vector3 steeringForce;

    public override void CalcSteeringForces()
    {
         Debug.Log("CalcSteering");
        steeringForce = Flee(fleeing.position);
        physics.ApplyForce(steeringForce);
        if (physics.CircleCollision())
        {
            Debug.Log("Is colliding");
            float xCoordinate = Random.Range(-7, 8);
            float yCoordinate = Random.Range(-4, 5);
            position = new Vector3(xCoordinate, yCoordinate, 0);
        }
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        fleeing = GetComponent<Seeker>();
        //physics = GetComponent<PhysicsObject>();
        //Debug.Log("Components gotten");
    }

    // Update is called once per frame
    protected override void Update()
    {
       base.Update();
    }
}
