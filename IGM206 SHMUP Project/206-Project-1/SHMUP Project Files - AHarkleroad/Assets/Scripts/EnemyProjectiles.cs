using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyProjectiles : Projectiles
{
    // field declaration
    public List<GameObject> enemyProjectileList = new List<GameObject>();
    public GameObject player;
    public GameObject gameManager;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        // finds player object in the scene
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
