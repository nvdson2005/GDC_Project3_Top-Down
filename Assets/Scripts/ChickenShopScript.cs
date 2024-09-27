using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ChickenShopScript : MonoBehaviour
{
    [SerializeField] private int eggCount = 100;
    [SerializeField] private TMP_Text eggCountText;
    [SerializeField] private List<Slot_UI> slotUI = new List<Slot_UI>();
    
    private GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        eggCountText.text = eggCount.ToString();
        
        if(slotUI.Count == player.GetComponent<PlayerInventory>().inventory.slots.Count){
            for(int i=0; i<slotUI.Count; i++){
                if(player.GetComponent<PlayerInventory>().inventory.slots[i].type != CollectableType.NONE){
                    slotUI[i].SetItem(player.GetComponent<PlayerInventory>().inventory.slots[i]);
                } else{
                    slotUI[i].SetEmpty();
                }
            }
        }
    }

    public void BuyItem(Collectable item)
    {
        int price = 0;
        switch (item.type)
        {
            case CollectableType.HEALING_EGG: 
                price = 10; 
                break;
            
           case CollectableType.ATTACK_EGG:
                price = 20;
                break;
           
           case CollectableType.SPEED_EGG:
                price = 20;
                break;
        }
        
        if (eggCount >= price)
        {
            Debug.Log("Added item to player inventory");
            player.GetComponent<PlayerInventory>().inventory.Add(item);
            eggCount -= price;
        }
    }
    
    public void SellItem(int slotIndex)
    {
        CollectableType item = player.GetComponent<PlayerInventory>().inventory.slots[slotIndex].type;
        
        if (item != CollectableType.NONE)
        {
            int price = 5;
            player.GetComponent<PlayerInventory>().inventory.Subtract(item);
            eggCount += price;
        }
    }
}
