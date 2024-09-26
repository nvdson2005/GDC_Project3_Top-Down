using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class LootableObjects : ScriptableObject
{
    public GameObject LootableObjectPrefab;
    public int dropChance;
    public string lootName;
    public LootableObjects(string lootname, int dropchance){
        dropChance = dropchance;
        lootName = lootname;
    }
}
