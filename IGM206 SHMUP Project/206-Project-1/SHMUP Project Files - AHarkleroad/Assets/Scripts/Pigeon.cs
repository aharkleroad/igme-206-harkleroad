using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pigeon : Enemy
{
    private int xDirectionSet;
    // smaller = more turns
    public int turnFrequency;
    public GameObject pigeonProjectilePrefab;
    private EnemyProjectiles enemyProjectile;

    protected override void CalcSteeringForces()
    {
        xDirectionSet = Random.Range(0, turnFrequency + 1);
        // bird turns
        if (xDirectionSet == turnFrequency)
        {
            desiredLocation = new Vector3(-physics.Position.x, physics.Position.y, 0f);
        }
        Seek(desiredLocation);
    }

    // bird shoots whenever it is able to
    protected override void SpawnProjectile()
    {
        GameObject poop = Instantiate(pigeonProjectilePrefab, physics.Position, Quaternion.identity);
        enemyProjectile.enemyProjectileList.Add(poop);
        poop.GetComponent<EnemyProjectiles>().player = this.player;
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        // starts the pigeon with a set desired position
        // desired position has the same y value but is off the screen
        base.Start();
        desiredLocation = new Vector3(-9f, physics.Position.y, 0f);
        enemyProjectile = GetComponent<EnemyProjectiles>();
    }
}
