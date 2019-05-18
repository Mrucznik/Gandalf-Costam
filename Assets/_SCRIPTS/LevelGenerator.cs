using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

namespace Assets._SCRIPTS
{
    public class LevelGenerator : MonoBehaviour {

        public GameObject EnemyPrefab;
        public GameObject Enemy2Prefab; 
        public GameObject SpikesPrefab;
        public GameObject PlayerPrefab;

        public List<GameObject> Prefabs;
        public List<int> PrefabsQuantity;
        public int NumberOfBlocks = 128;
        public int NumberOfRows = 128;



        List<GameObject> _enemies;
        List<GameObject> _level;
        Random _rand;
        // Use this for initialization

        void Start() {
            Random rand = new Random();
            GameObject world = new GameObject("World");
            _enemies = new List<GameObject>();
            _level = new List<GameObject>();
            Vector3 startingPos = Vector3.zero;
            int blocks = NumberOfBlocks - 10;
        
        
            // First Platform
            GameObject platformFirst = Instantiate(Prefabs[8], startingPos, Quaternion.identity);
            platformFirst.transform.SetParent(world.transform);
            _level.Add(platformFirst);
            startingPos.x += 10;


            for (int j = 0; j < NumberOfRows; j++)
            {
                while (blocks > 0)
                {
                    int i = rand.Next(Prefabs.Count);
                    if (blocks >= i)
                    {

                        GameObject platform = Instantiate(Prefabs[i], startingPos, Quaternion.identity);
                        platform.transform.SetParent(world.transform);
                        Rigidbody2D rb = platform.AddComponent<Rigidbody2D>();
                        rb.isKinematic = true;


                        if (rand.Next(100) <= 10)
                            platform.AddComponent<FallingPlatform>();
                        if (rand.Next(100) <= 20 && PrefabsQuantity[i] > 2)
                        {
                            GameObject enemyN = Instantiate(Enemy2Prefab, platform.transform.position + new Vector3(1f, 3f), Quaternion.identity);
                            _enemies.Add(enemyN);
                            enemyN.GetComponent<EnemyPatrol>().Seed = rand.Next();
                            enemyN.transform.parent = world.transform;
                        }
                        if (rand.Next(100) <= 40 && PrefabsQuantity[i] > 2)
                        {
                            GameObject enemyN = Instantiate(EnemyPrefab, platform.transform.position + new Vector3(.5f, 0), Quaternion.identity);
                            _enemies.Add(enemyN);
                            enemyN.GetComponent<EnemyPatrol>().Seed = rand.Next();
                            enemyN.transform.parent = world.transform;
                        }
                        else if(rand.Next(100) <= 80)
                        {
                            Vector2 temp = startingPos;
                            for (int k = 0; k < PrefabsQuantity[i]; k++)
                            {
                                if (rand.Next(100) <= 20)
                                {
                                    GameObject tmp = Instantiate(SpikesPrefab, temp, Quaternion.identity);
                                    tmp.transform.parent = platform.transform;
                                }
                                temp.x++;
                            }
                        }


                        _level.Add(platform);
                        startingPos.x += PrefabsQuantity[i] + rand.Next(4, 6);
                        blocks -= PrefabsQuantity[i];


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
}
