using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    // variable declaration
    private double trackTimeEnemies = 0;
    private double trackTimeWind = 0;
    public float enemiesSpawnPerSecond;
    private float timeBetweenEnemySpawn;
    private bool enemySpawned;
    // in percent, must be 100 or less
    public int rateOfPlanes;
    private int enemyTypeDeterminer;
    public float frequencyOfWind;
    public float durationOfWind;
    private float windWillBlowFor;
    public bool isWind = false;
    public Enemy planePrefab;
    public Enemy pigeonPrefab;
    public List<Enemy> enemyList = new List<Enemy>();
    private float xPosition = -7.5f;
    private float yPosition;
    protected GameObject player;

    // spawns a plane at a randomly generated y position in the window
    public void SpawnEnemyPlane()
    {
        yPosition = Random.Range(-4, 5);
        Enemy plane = Instantiate(planePrefab, new Vector3(xPosition, yPosition, 0f), Quaternion.identity);
        plane.GetComponent<EnemyPlane>().player = this.player;
        enemyList.Add(plane);
    }

    // spawns a pigeon at a randomly generated y position in the window
    public void SpawnPigeon()
    {
        // pigeons only spawn at the top of the screen
        yPosition = Random.Range(1, 5);
        Enemy pigeon = Instantiate(pigeonPrefab, new Vector3(xPosition, yPosition, 0f), Quaternion.identity);
        pigeon.GetComponent<Pigeon>().player = this.player;
        enemyList.Add(pigeon);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeBetweenEnemySpawn = 1 / enemiesSpawnPerSecond;
        // add time to appropriate time trackers
        trackTimeEnemies += Time.deltaTime;
        // time not added to wind time tracker if wind is currently blowing
        if (!isWind)
        {
            trackTimeWind += Time.deltaTime;
        }
        else
        {
            windWillBlowFor -= Time.deltaTime;
        }

        // gone past the amount of time between enemy spawns
        if (trackTimeEnemies >= timeBetweenEnemySpawn)
        {
            enemySpawned = true;
            trackTimeEnemies = 0;
        }

        // enemy is spawned
        if (enemySpawned)
        {
            enemyTypeDeterminer = Random.Range(1, 101);
            // spawns planes at the given rate and pigeons all other times
            if (enemyTypeDeterminer <= rateOfPlanes)
            {
                SpawnEnemyPlane();
            }
            else 
            {
                SpawnPigeon();
            }
        }

        // gone past the amount of time when wind begins
        if (trackTimeWind >= frequencyOfWind)
        {
            isWind = true;
            trackTimeWind = 0;
            windWillBlowFor = durationOfWind;
        }
        // wind has finished blowing
        else if (windWillBlowFor <= 0)
        {
            isWind = false;
        }

        enemySpawned = false;
    }
}
