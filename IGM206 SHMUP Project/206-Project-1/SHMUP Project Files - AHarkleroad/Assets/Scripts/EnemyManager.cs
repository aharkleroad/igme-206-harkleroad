using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // field declaration
    private EnemySpawn enemySpawn;
    private Enemy enemy;
    public Player player;
    private int enemyNumber;

    // gets rid of enemies once they've left the screen or been destroyed by the player
    public void RemoveEnemies()
    {
        enemyNumber = enemySpawn.enemyList.Count;
        for (int i = 0; i < enemyNumber; i++)
        {
            if (enemySpawn.enemyList[i].DesiredLocation == enemySpawn.enemyList[i].position 
             || ((Enemy)enemySpawn.enemyList[i]).health == 0)
            {
                Destroy(enemySpawn.enemyList[i]);
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
