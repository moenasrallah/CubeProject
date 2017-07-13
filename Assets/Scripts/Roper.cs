using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Roper : NetworkBehaviour
{

    public Vector2 spawnRates;
    public bool canSpawn;
    public GameObject enemies;
    GameObject clone;
    float nextSpawn;
    public static Roper instance;
    public int currEnemies = 0;
    public int maxEnemies = 5;


    private void Awake()
    {
        //Check if instance already exists
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);
    }
    // Use this for initialization

    void Start ()
    {
        nextSpawn = Time.time + Random.Range(spawnRates.x, spawnRates.y);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(isServer) // to have things spawn on the same screen
        {
            Spawn();
        }// dont touch

    }

    public void Spawn()
    {
        if (nextSpawn <= Time.time)
        {

            nextSpawn = Time.time + Random.Range(spawnRates.x, spawnRates.y);

            if (currEnemies < 0)
            {
                currEnemies = 0;
                return;
            }

            if (currEnemies >= 0 && currEnemies < maxEnemies)
            {
                //Debug.Log("WE'RE SPAWNING");
                clone = Instantiate(enemies, new Vector3(Random.Range(-5.7f, 4), 2, Random.Range(-2, 1)), enemies.transform.rotation);
                currEnemies++;
                NetworkServer.Spawn(clone);
                //Debug.Log("For loop called, current enemy count = " + currEnemies);
            }
            
            
        }
    } //dont touch

    public void iDied()
    {
      currEnemies -= 1;
    }
}
