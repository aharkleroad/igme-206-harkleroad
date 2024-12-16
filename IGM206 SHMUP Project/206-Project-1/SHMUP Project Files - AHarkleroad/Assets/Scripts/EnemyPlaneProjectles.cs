using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlaneProjectles : EnemyProjectiles
{
    public GameObject player;
    private SpriteRenderer spriteRenderer;

    protected override void CalcSteeringForces()
    {
        Seek(spriteRenderer.bounds.center);
    }

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = player.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
