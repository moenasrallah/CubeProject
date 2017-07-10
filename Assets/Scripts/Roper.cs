using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roper : MonoBehaviour {

    public Vector2 spawnRates;
    public bool canSpawn;
    public GameObject enemies;
    float nextSpawn;

    public int currEnemies;
    public int maxEnemies = 5;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
    }

    void Spawn()
    {
        for (int currEnemies = 0; currEnemies < maxEnemies; currEnemies++)
        {
            GameObject clone = Instantiate(enemies, transform.position, transform.rotation);
        }
    }

    public void iDied()
    {
        currEnemies -= 1;
        //subtract current count by 1
       
    }
}
