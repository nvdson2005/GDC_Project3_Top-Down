using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Inventory_UI : MonoBehaviour
{
    //This class will be in the parent object (Canvas) in order to be able to set active for the inventory
    [SerializeField] private GameObject inventoryGameObject;
    public GameObject player;
    public List<Slot_UI> slotUI = new List<Slot_UI>();
    bool isUIOpen;
    // Start is called before the first frame update
    void Awake()
    {
        inventoryGameObject.SetActive(false);
        isUIOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        Setup();
        if(Input.GetKeyDown(KeyCode.Tab) && !isUIOpen){
            UIToggle();
        } else if (Input.GetKeyDown(KeyCode.Tab) && isUIOpen){
            UIToggle();
        }
    }
    private void UIToggle(){
        if(!isUIOpen){
            inventoryGameObject.SetActive(true);
            inventoryGameObject.transform.DOScale(1, 0.5f).OnComplete(() => isUIOpen = true);          
        } else{
            inventoryGameObject.transform.DOScale(0, 0.5f).OnComplete(() => {inventoryGameObject.SetActive(false); isUIOpen = false;});
        }
    }
    void Setup(){
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

    public void EatEgg(int slotIndex)
    {
        CollectableType eggType = player.GetComponent<PlayerInventory>().inventory.slots[slotIndex].type;
        switch (eggType)
        {
            case CollectableType.HEALING_EGG:
                // Increase player health
                player.GetComponent<Character>().IncreaseHP(2);
                
                // Subtract from inventory
                player.GetComponent<PlayerInventory>().inventory.Subtract(eggType);
                break;
            
            case CollectableType.ATTACK_EGG:
                // Double player attack
                player.GetComponent<Character>().DoubleAttack(30);
                
                // Subtract from inventory
                player.GetComponent<PlayerInventory>().inventory.Subtract(eggType);
                break;
            
            case CollectableType.SPEED_EGG:
                // Double player attack
                player.GetComponent<Character>().DoubleSpeed(30);
                
                // Subtract from inventory
                player.GetComponent<PlayerInventory>().inventory.Subtract(eggType);
                break;
        }
    }
}
