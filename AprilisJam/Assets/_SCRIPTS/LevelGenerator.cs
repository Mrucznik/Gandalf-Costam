using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class LevelGenerator : MonoBehaviour {

    public GameObject enemyPrefab;
    public GameObject spikesPrefab;
    public GameObject playerPrefab;

    public List<GameObject> prefabs;
    public List<int> prefabsQuantity;
    public int NumberOfBlocks = 128;
    public int NumberOfRows = 128;
    List<GameObject> Enemies;
    List<GameObject> Level;
    Random rand;
    // Use this for initialization

    void Start() {
        Random rand = new Random();
        GameObject world = new GameObject("World");
        Enemies = new List<GameObject>();
        Level = new List<GameObject>();
        Vector3 startingPos = Vector3.zero;
        int blocks = NumberOfBlocks - 8;
        // First Platform
        GameObject platformFirst = Instantiate(prefabs[8], startingPos, Quaternion.identity);
        platformFirst.transform.SetParent(world.transform);
        Level.Add(platformFirst);
        Instantiate(playerPrefab, startingPos + new Vector3(2, 2, 0), Quaternion.identity);
        startingPos.x += 10;
        for (int j = 0; j < NumberOfRows; j++)
        {
            while (blocks > 0)
            {
                int i = rand.Next(prefabs.Count);
                if (blocks >= i)
                {
                    GameObject platform = Instantiate(prefabs[i], startingPos, Quaternion.identity);
                    platform.transform.SetParent(world.transform);
                    Rigidbody2D rb = platform.AddComponent<Rigidbody2D>();
                    rb.isKinematic = true;
                    if (rand.Next(100) <= 10)
                        platform.AddComponent<FallingPlatform>();
                    if (rand.Next(100) <= 40)
                    {
                        GameObject enemyN;
                        enemyN = Instantiate(enemyPrefab, platform.transform.position + new Vector3(.5f, 0), Quaternion.identity);
                        Enemies.Add(enemyN);
                        enemyN.transform.parent = world.transform;
                    }
                    else if(rand.Next(100) <= 80)
                    {
                        Vector2 temp = startingPos;
                        for (int k = 0; k < prefabsQuantity[i]; k++)
                        {
                            if (rand.Next(100) <= 20)
                            {
                                Instantiate(spikesPrefab, temp, Quaternion.identity);
                            }
                            temp.x++;
                        }
                    }
                    Level.Add(platform);
                    startingPos.x += prefabsQuantity[i] + rand.Next(4, 6);
                    blocks -= prefabsQuantity[i];
                    }
            }
            startingPos.y += 5;
            startingPos.x = 0;
            blocks = NumberOfBlocks;
        }

    }

    void Update()
    {

    }
	
}
