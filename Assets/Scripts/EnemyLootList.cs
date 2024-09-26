using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyLootList : MonoBehaviour
{
    public List<LootableObjects> lootlist = new List<LootableObjects>();
    // Start is called before the first frame update
    LootableObjects GetDroppedItem()
    {
        int randomnumber = Random.Range(0, 101);
        List<LootableObjects> possibleItems = new List<LootableObjects>();
        foreach (LootableObjects item in lootlist)
        {
            if (randomnumber <= item.dropChance)
            {
                possibleItems.Add(item);
            }
        }
        if (possibleItems.Count > 0)
        {
            return possibleItems[Random.Range(0, possibleItems.Count)];
        }
        else
        {
            return lootlist[Random.Range(0, lootlist.Count)];
            // Debug.Log("No items can be instantiated from this slime");
            // return null;
        }
    }
    public void InstantiateLootObject(Vector2 spawnposition)
    {
        LootableObjects dropitem = GetDroppedItem();
        Debug.Log(dropitem.lootName + " dropped!");
        if(dropitem != null){
            GameObject dropGameObject = dropitem.LootableObjectPrefab;
            Instantiate(dropGameObject, spawnposition, Quaternion.identity);
        } else{
            Debug.Log("nothing to drop");
            return;
        }
    }
}

