using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : Singleton<SpawnManager>
{
    // field declaraction
    // holds references to all creature sprites
    public Sprite elephantSprite;
    public Sprite kangarooSprite;
    public Sprite octopusSprite;
    public Sprite snailSprite;
    public Sprite turtleSprite;
    public GameObject creaturePrefab;
    // holds current creatures
    private List<GameObject> creatureList = new List<GameObject>();
    // private Random randomNumberGenerator;
    private SpriteRenderer spriteRenderer;

    // (Optional) Prevent non-singleton constructor use.
    protected SpawnManager() { }

    // instantiates a random number of creatures
    public void Spawn()
    {
        // field declaration
        float xPosition;
        float yPosition;
        GameObject creature;
        // gets rid of previous creatures
        CleanUp();
        // randomly generates the number of creatures to spawn (between 10 and 20)
        int numberOfCreatures = Random.Range(10, 21);
        Debug.Log("number creatures decided");
        // creates the creatures and adds them to a list so they can be tracked
        for(int i = 0; i < numberOfCreatures; i++)
        {
            xPosition = Gaussian(0f, 3.5f);
            yPosition = Gaussian(0f, 1.25f);
            creature = SpawnCreature();
            GameObject creatureInstantiated = Instantiate(creature, new Vector3(xPosition, yPosition, 0f), Quaternion.identity);
            creatureList.Add(creatureInstantiated);
        }
    }

    // generates a random value according to a gaussian distribution
    private float Gaussian(float mean, float stdDev)
    {
        float val1 = Random.Range(0f, 1f);
        float val2 = Random.Range(0f, 1f);

        float gaussValue =
        Mathf.Sqrt(-2.0f * Mathf.Log(val1)) * Mathf.Sin(2.0f * Mathf.PI * val2);

        return mean + stdDev * gaussValue;
    }

    // creates and returns a creature prefab of a random animal type and color
    public GameObject SpawnCreature()
    {
        // generate the kind of creature
        Sprite creatureType = ChooseRandomCreature();
        // create an instance of the prefab
        GameObject creature = creaturePrefab;
        spriteRenderer = creature.GetComponent<SpriteRenderer>();
        // attach the sprite to the prefab
        spriteRenderer.sprite = creatureType;
        int randomNumber = Random.Range(1, 10);
        // determine and set sprite color based on the random number generated
        if (randomNumber == 1)
        {
            spriteRenderer.color = Color.black;
        }
        else if (randomNumber == 2)
        {
            spriteRenderer.color = Color.blue;
        }
        else if (randomNumber == 3)
        {
            spriteRenderer.color = Color.cyan;  
        }
        else if (randomNumber == 4)
        {
            spriteRenderer.color = Color.gray;
        }
        else if (randomNumber == 5)
        {
            spriteRenderer.color = Color.green;
        }
        else if (randomNumber == 6)
        {
            spriteRenderer.color = Color.magenta;
        }
        else if (randomNumber == 7)
        {
            spriteRenderer.color = Color.red;
        }
        else if (randomNumber == 8)
        {
            spriteRenderer.color = Color.yellow;
        }
        // otherwise, if the number generated is 9, the sprite stays white
        return creature;
    }

    // randomly determines what type of creature to spawn
    public Sprite ChooseRandomCreature()
    {
        Sprite creatureType;
        int randomNumber = Random.Range(1, 101);
        // decides what creature spawns based on randomly generated number
        // 25% chance of elephant
        if (randomNumber <= 25)
        {
            creatureType = elephantSprite;
        }
        // 30% chance of kangaroo
        else if (randomNumber <= 55)
        {
            creatureType = kangarooSprite;
        }
        // 10% chance of octopus
        else if (randomNumber <= 65)
        {
            creatureType = octopusSprite;
        }
        // 15% chance of snail
        else if (randomNumber <= 80)
        {
            creatureType = snailSprite;
        }
        // 20% chance of turtle
        else
        {
            creatureType = turtleSprite;
        }
        return creatureType;
    }

    // removes all creatures from the screen and list so new ones can be spawned
    public void CleanUp()
    {
        int listLength = creatureList.Count;
        // destroys each creature on the screen (stored in list)
        for (int i = 0; i < listLength; i++)
        {
            Destroy(creatureList[i]);
        }
        // clears list before new creatures are added
        creatureList.Clear();
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
