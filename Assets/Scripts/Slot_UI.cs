using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Slot_UI : MonoBehaviour
{
    public Image icon;
    public Text amountText;
    public void SetItem(Inventory.Slot slot){
        if(slot != null){
            icon.sprite = slot.icon;
            icon.color = new Color(1,1,1,1);
            amountText.text = slot.count.ToString();
        }
    }
    public void SetEmpty(){
        icon.sprite = null;
        icon.color = new Color(1,1,1,0);
        amountText.text = "0";
    }
}
