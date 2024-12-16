using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private EnemySpawn enemySpawn;
    private Enemy enemy;

    // gets rid of enemies once they've left the screen or been destroyed by the player
    public void RemoveEnemies()
    {
        for (int i = 0; i < enemySpawn.enemyList.Count; i++)
        {
            if (enemySpawn.enemyList[i].DesiredLocation == enemySpawn.enemyList[i].position 
             || ((Enemy)enemySpawn.enemyList[i]).health == 0
            )
            {
                Destroy(enemySpawn.enemyList[i]);
                enemySpawn.enemyList.RemoveAt(i);
            }
        }
    }

    // gets rid of projectiles once they've left the screen or been destroyed by the player
    public void RemoveProjectiles()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        enemySpawn = GetComponent<EnemySpawn>();
        enemy = GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        RemoveEnemies();
        RemoveProjectiles();
    }
}
