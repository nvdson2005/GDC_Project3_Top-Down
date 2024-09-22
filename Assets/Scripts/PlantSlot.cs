using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantSlot : MonoBehaviour
{
    public bool hasPlant;

    public GameObject plant;

    public GameObject field;

    public void setEmptyHasPlant(bool empty)
    {
        if (empty == false)
        {
            hasPlant = false;
        }
    }
}
