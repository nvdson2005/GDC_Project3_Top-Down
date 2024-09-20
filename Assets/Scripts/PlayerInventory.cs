using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public Inventory inventory;
    public int numSlots;
    // Start is called before the first frame update
    void Awake()
    {
        inventory = new Inventory(numSlots);
    }

    //The collection of collectable type is called in Collectable.cs by using CollisionEnter2D
}
