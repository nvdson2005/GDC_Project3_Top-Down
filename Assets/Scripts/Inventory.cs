using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Inventory
{
    [System.Serializable]
    public class Slot{
        public Sprite icon;
        public CollectableType type;
        public int count;
        public int maxCapacity;
        public Slot(){
            type = CollectableType.NONE;
            count = 0;
            maxCapacity = 99;
        }
        public bool IsAbleToAdd(){
            return count < maxCapacity;
        }
        public void AddInSlot(Collectable add){
            this.type = add.type;
            this.icon = add.icon;
            count++;
        }
    }  
    public List<Slot> slots;
    public Inventory(int nums){
        slots = new List<Slot>();
        for(int i=0; i<nums; i++){
            Slot slot = new Slot();
            slots.Add(slot);
        }
    }
    public void Add(Collectable add){
        foreach(Slot slot in slots){
            if(slot.type == add.type && slot.IsAbleToAdd()){
                slot.AddInSlot(add);
                return;
            }
        }
        foreach(Slot slot in slots){
            if(slot.type == CollectableType.NONE){
                slot.AddInSlot(add);
                return;
            }
        }
    }
}
