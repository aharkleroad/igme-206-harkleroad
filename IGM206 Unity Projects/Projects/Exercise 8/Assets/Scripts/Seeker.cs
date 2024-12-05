using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seeker : Agent
{
    public Fleer seeking;
    private Vector3 steeringForce;

    public override void CalcSteeringForces()
    {
        steeringForce = Seek(seeking.position);
        physics.ApplyForce(steeringForce);
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        seeking = GetComponent<Fleer>();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
}
