using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectSeeds : MonoBehaviour
{
    public Image icon;
    public Text amountText;

    public GameObject selectedNumber;
    public int selected = 0;

    public GameObject deselectIcon;

    private GameManager gms;

    private void Start()
    {
        gms = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        gameObject.GetComponent<Button>().onClick.AddListener(SelectedSeed);
        deselectIcon.GetComponent<Button>().onClick.AddListener(DeselectSeed);
    }
    private void SelectedSeed()
    {
        if (gameObject.GetComponent<PlantSeed>().plantType != CollectableType.NONE)
        {
            if (gms.currentField.GetComponent<Field>().remainingPlantSlot > 0 &&
                selected < int.Parse(amountText.text))
            {
                selected++;
                selectedNumber.GetComponent<Text>().text = selected.ToString();
                gms.SelectPlant(gameObject.GetComponent<PlantSeed>());
            }
            
        }    
    }
    private void DeselectSeed()
    {
        selected--;
        selectedNumber.GetComponent<Text>().text = selected.ToString();
        gms.DeselectPlant(gameObject.GetComponent<PlantSeed>());
    }
    private void Update()
    {
        if (selected <= 0)
        {
            selectedNumber.SetActive(false);
            deselectIcon.SetActive(false);
        }
        else
        {
            selectedNumber.SetActive(true);
            deselectIcon.SetActive(true);
        }
    }

    public void SetItem(Inventory.Slot slot)
    {
        if (slot != null)
        {
            icon.sprite = slot.icon;
            icon.color = new Color(1, 1, 1, 1);
            amountText.text = slot.count.ToString();
        }
    }
    public void SetEmpty()
    {
        icon.sprite = null;
        icon.color = new Color(1, 1, 1, 0);
        amountText.text = "0";
    }
}
