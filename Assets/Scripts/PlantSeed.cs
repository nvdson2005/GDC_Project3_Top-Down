using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
//using UnityEditor.Build.Content;

public class PlantSeed : MonoBehaviour
{
    public GameObject[] plantObject;
    public CollectableType plantType;
    public GameObject plant;

    public void IdentifyPlantType(Inventory.Slot slot)
    {
        if (slot.type == CollectableType.STRAWBERRY_SEEED)
        {
            plant = plantObject[0];
            plantType = CollectableType.STRAWBERRY_SEEED;
        }
        else if (slot.type == CollectableType.RADISH_SEED)
        {
            plant = plantObject[1];
            plantType = CollectableType.RADISH_SEED;
        }
        else if (slot.type == CollectableType.POTATO_SEED)
        {
            plant = plantObject[2];
            plantType = CollectableType.POTATO_SEED;
        }
        else if (slot.type == CollectableType.ONION_SEED)
        {
            plant = plantObject[3];
            plantType = CollectableType.ONION_SEED;
        }
        else
        {
            plant = GameObject.FindGameObjectWithTag("Temp");
            plantType = CollectableType.NONE;
        }
    }
}
