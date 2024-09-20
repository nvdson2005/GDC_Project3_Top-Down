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
        Debug.Log(other.gameObject.tag);
        if(other.gameObject.CompareTag("Player")){
            Destroy(gameObject);
            //Add the collectable into the inventory in particular
            other.gameObject.GetComponent<PlayerInventory>().inventory.Add(this);
        }
    }
}
public enum CollectableType
{
    NONE, STRAWBERRY_SEEED, RADISH_SEED, POTATO_SEED, ONION_SEED
}