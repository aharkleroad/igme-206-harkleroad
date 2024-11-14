using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureSpawner : MonoBehaviour
{
    // variable instantiation
    public GameObject creaturePrefab;
    public Vector3 location1;
    public Vector3 location2;
    public Vector3 location3;

    // Start is called before the first frame update
    // creates a prefab object at 3 different locations
    void Start()
    {
        Instantiate(creaturePrefab, location1, Quaternion.identity);
        Instantiate(creaturePrefab, location2, Quaternion.identity);
        Instantiate(creaturePrefab, location3, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
