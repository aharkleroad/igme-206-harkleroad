using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlaneProjectles : EnemyProjectiles
{
    // field declaration
    private SpriteRenderer spriteRenderer;

    // calculates enemy plane steering force (seeks the player plane)
    protected override void CalcSteeringForces()
    {
        Seek(spriteRenderer.bounds.center);
    }

    // Start is called before the first frame update
    protected void Start()
    {
        base.Start();
        spriteRenderer = player.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
