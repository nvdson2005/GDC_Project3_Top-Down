using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnner : MonoBehaviour
{
    public GameObject gameObjectPrefab;
    public GameObject[] gameObjectsList;
    public GameObject[] spawnners;
    private float counter = 0f;
    void Start()
    {
        /* 
        
        
                First Time Spawn

        */
        for (int i = 0; i < spawnners.Length; i++)
        {
            GameObject tmp = Instantiate(gameObjectPrefab, spawnners[i].transform.position, Quaternion.identity);
            tmp.GetComponent<SlimePatrolAndAttack>().RandomizeDirection();
            tmp.GetComponent<SlimePatrolAndAttack>().RandomizeHp();
            gameObjectsList[i] = tmp;
        }
        //////Second for loop to make sure all the enemies are spawned
        for (int i = 0; i < spawnners.Length; i++)
        {
            if (gameObjectsList[i] == null)
            {
                GameObject tmp = Instantiate(gameObjectPrefab, spawnners[i].transform.position, Quaternion.identity);
                tmp.GetComponent<SlimePatrolAndAttack>().RandomizeDirection();
                tmp.GetComponent<SlimePatrolAndAttack>().RandomizeHp();
                gameObjectsList[i] = tmp;
            }
        }
    }
    void Update()
    {
        //Continuous time spawn
        Spawn();
    }

    void Spawn()
    {
        for (int i = 0; i < spawnners.Length; i++)
        {
            if (gameObjectsList[i] == null)
            {
                counter += Time.deltaTime;
                if (counter >= 15f)
                {
                    GameObject tmp = Instantiate(gameObjectPrefab, spawnners[i].transform.position, Quaternion.identity);
                    gameObjectsList[i] = tmp;
                    counter = 0f;
                }
            }
        }
    }
}
