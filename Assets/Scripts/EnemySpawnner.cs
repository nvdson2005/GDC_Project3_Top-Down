using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnner : MonoBehaviour
{
    public GameObject gameObjectPrefab;
    public GameObject[] gameObjectsList;
    public GameObject[] spawnners;
    private float counter = 0f;
    bool firsttime = true;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < spawnners.Length; i++)
        {
            GameObject tmp = Instantiate(gameObjectPrefab, spawnners[i].transform.position, Quaternion.identity);
            gameObjectsList[i] = tmp;
        }
        for (int i = 0; i < spawnners.Length; i++)
        {
            if (gameObjectsList[i] == null)
            {
                GameObject tmp = Instantiate(gameObjectPrefab, spawnners[i].transform.position, Quaternion.identity);
                gameObjectsList[i] = tmp;
            }
        }
        //StartCoroutine(SpawnEnemy());
    }
    void Update()
    {
        Spawn();
    }

    void Spawn()
    {
        for (int i = 0; i < spawnners.Length; i++)
        {
            if (gameObjectsList[i] == null)
            {
                counter += Time.deltaTime;
                if (counter >= 5f)
                {
                    GameObject tmp = Instantiate(gameObjectPrefab, spawnners[i].transform.position, Quaternion.identity);
                    gameObjectsList[i] = tmp; 
                    counter = 0f;
                }
            }
        }
    }
}
