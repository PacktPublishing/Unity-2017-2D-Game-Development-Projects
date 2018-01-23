using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningSystem : MonoBehaviour {

    public Transform[] enemiesSpawningPoints;
    public Transform[] decorationSpawningPoints;

    public GameObject[] enemies;
    public GameObject[] decorations;

	// Use this for initialization
	void Start () {
        //Start the two coroutines
        StartCoroutine(SpawnEnemies());
        StartCoroutine(SpawnDecorations());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator SpawnEnemies() {
        //Forever...
        while (true) {
            //...spawn a random enemy in a random location
            Instantiate(enemies[Random.Range(0, enemies.Length)], enemiesSpawningPoints[Random.Range(0, enemiesSpawningPoints.Length)].position, Quaternion.identity);

            //Set a random amount of time between 8 and 16 before to spawn another enemy
            yield return new WaitForSeconds(Random.Range(8, 16));
        }
    }

    IEnumerator SpawnDecorations() {
        //For ever...
        while (true) {
            //...spawn a random decoration in a random location
            Instantiate(decorations[Random.Range(0, decorations.Length)], decorationSpawningPoints[Random.Range(0, decorationSpawningPoints.Length)].position, Quaternion.identity);

            //Set a random amount of time between 4 and 9 before to spawn another enemy
            yield return new WaitForSeconds(Random.Range(4, 9));
        }
    }
}
