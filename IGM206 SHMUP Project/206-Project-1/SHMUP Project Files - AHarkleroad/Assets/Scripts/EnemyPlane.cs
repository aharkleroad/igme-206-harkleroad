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
    }

    // Start is called before the first frame update
    void Start()
    {
        desiredLocation = new Vector3(-10f, physics.Position.y, 0f);
        enemyProjectile = GetComponent<EnemyProjectiles>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
