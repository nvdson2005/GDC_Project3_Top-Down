using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public Transform tiles;
    public LayerMask tileMask;

    public GameObject currentPlant;

    public GameObject plantSeed;

    public GameObject player;

    private RaycastHit2D hit;
    public Transform currentTile;


    private void Update()
    {
        hit = Physics2D.Raycast(player.transform.position, Vector2.zero, Mathf.Infinity, tileMask);

        foreach (Transform tile in tiles)
        {
            if (hit.collider)
            {
                currentTile = hit.transform;
                if (currentTile.GetComponent<PlantSlot>().hasPlant == false)
                {
                    plantSeed.SetActive(true);       
                }
                else
                {
                    plantSeed.SetActive(false);
                    if (currentTile.GetComponent<PlantSlot>().plant.GetComponent<Plant>().isGrowth == true)
                    {
                        if (Input.GetKeyDown(KeyCode.F))
                        {
                            Destroy(currentTile.GetComponent<PlantSlot>().plant);
                            currentTile.GetComponent<PlantSlot>().hasPlant = false;
                            //currentTile.GetComponent<PlantSlot>().plant.GetComponent<Plant>().isGrowth = false;
                        }
                    }
                }
                
            }
            else
            {
                plantSeed.SetActive(false);
            }
        }
    }
    public void ChoosePlant(GameObject plant)
    {
        currentPlant = plant;
        Planting();
    }
    private void Planting()
    {
        if (currentTile.GetComponent<PlantSlot>().hasPlant == false)
        {
            GameObject planted = Instantiate(currentPlant, hit.transform.position, Quaternion.identity);
            currentTile.GetComponent<PlantSlot>().hasPlant = true;
            currentTile.GetComponent<PlantSlot>().plant = planted;
            planted.GetComponent<Strawberry>().plantedSlot = currentTile;

            currentPlant = GameObject.FindGameObjectWithTag("Temp");
        }  
        //currentTile = GameObject.FindGameObjectWithTag("Temp").transform;
    }
}
