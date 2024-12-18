using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlane : Enemy
{
    public GameObject planeProjectilePrefab;
    private EnemyProjectiles enemyProjectile;

    protected override void CalcSteeringForces()
    {
        Seek(desiredLocation);
    }

    // plane shoots whenever it is able to
    protected override void SpawnProjectile()
    {
        GameObject bullet = Instantiate(planeProjectilePrefab, physics.Position, Quaternion.identity);
        enemyProjectile.enemyProjectileList.Add(bullet);
        bullet.GetComponent<EnemyProjectiles>().player = this.player;
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        desiredLocation = new Vector3(-10f, physics.Position.y, 0f);
        enemyProjectile = GetComponent<EnemyProjectiles>();
    }
}
