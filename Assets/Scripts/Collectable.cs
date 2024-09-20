using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public Sprite icon;
    public CollectableType type;
    //If the player collides with a collectable thing, it will be destroyed and add into the inventory
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Player")){
            Destroy(gameObject);
            //Add the collectable into the inventory in particular
            other.gameObject.GetComponent<PlayerInventory>().inventory.Add(this);
        }
    }
}
//Types of collectable. If you want to add more collectable things, add here
public enum CollectableType
{
    NONE, STRAWBERRY_SEEED, RADISH_SEED, POTATO_SEED, ONION_SEED
}