using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectiles : Projectiles
{
    public List<GameObject> playerProjectiles;

    protected override void CalcSteeringForces()
    {
        Seek(desiredLocation);
    }

    void Start()
    {
        base.Start();
        desiredLocation = new Vector3(-9f, physics.Position.y, 0f);
    }
}
