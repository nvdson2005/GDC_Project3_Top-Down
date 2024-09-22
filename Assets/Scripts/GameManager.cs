using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;
using UnityEngine.UI;
using System.Linq;


public class GameManager : MonoBehaviour
{
    public Transform tiles;
    public GameObject currentField;
    public LayerMask tileMask;

    public List<PlantSeed> currentPlants;

    public GameObject player;

    private RaycastHit2D hit;

    [SerializeField] private GameObject sowseedsGameobject;
    bool isUIOpen;
    public List<GameObject> selectedSeeds = new List<GameObject>();
    public GameObject plantButton;

    public int NumberOfSelectedPlant;


    // these two variables are not important
    private float timer = 0;
    private bool canInteract = true;
    //


    void Awake()
    {
        currentPlants = new List<PlantSeed>();
        sowseedsGameobject.SetActive(false);
        isUIOpen = false;
    }

    private void Start()
    {
        plantButton.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(Planting);
    }
    private void Update()
    {
        Setup();
        hit = Physics2D.Raycast(player.transform.position, Vector2.zero, Mathf.Infinity, tileMask);
        if (hit.collider == null && isUIOpen)
        {
            UIToggle();
        }
        foreach (Transform tile in tiles)
        {
            if (hit.collider)
            { 
                if (!hit.collider.GetComponent<PlantSlot>().hasPlant)
                {
                    currentField = hit.collider.GetComponent<PlantSlot>().field;
                    if (canInteract == false)
                    {
                        return;
                    }
                    if (Input.GetKeyDown(KeyCode.F) && !isUIOpen)
                    {
                        UIToggle();
                    }
                    else if (Input.GetKeyDown(KeyCode.Escape) && isUIOpen)
                    {
                        UIToggle();
                    }
                }
                else
                {
                    if (hit.collider.GetComponent<PlantSlot>().plant.GetComponent<Plant>().isGrowth)
                    {
                        if (Input.GetKeyDown(KeyCode.F))
                        {
                            Destroy(hit.collider.GetComponent<PlantSlot>().plant);
                            hit.collider.GetComponent<PlantSlot>().setEmptyHasPlant(false);
                            canInteract = false;
                        }
                    }
                }
            }
        }

        if (canInteract == false)
        {
            timer += Time.deltaTime;
            if (timer > 0.5f)
            {
                canInteract = true;
                timer = 0f;
            }
        }
    }


    private void UIToggle()
    {
        if (!isUIOpen)
        {
            sowseedsGameobject.SetActive(true);
            foreach (GameObject selectedSeed in selectedSeeds)
            {
                selectedSeed.GetComponent<SelectSeeds>().selected = 0;
            }
            sowseedsGameobject.transform.DOScale(1, 0.5f).OnComplete(() => isUIOpen = true);
        }
        else
        {
            NumberOfSelectedPlant = 0;
            currentField.GetComponent<Field>().remainingPlantSlot = 
                currentField.GetComponent<Field>().standardPlantslot;
            currentPlants.Clear();
            isUIOpen = false;
            sowseedsGameobject.transform.DOScale(0, 0.5f).OnComplete(() => {sowseedsGameobject.SetActive(false);});
        }
    }

    public void SelectPlant(PlantSeed plant)
    {
        currentPlants.Add(plant);
        NumberOfSelectedPlant++;
        currentField.GetComponent<Field>().remainingPlantSlot--;
    }
    public void DeselectPlant(PlantSeed plant)
    {
        int listCount = currentPlants.Count;
        for (int i = 0; i < listCount; i++)
        {
            if (currentPlants[i].plantType == plant.plantType)
            {
                currentPlants.RemoveAt(i);
                NumberOfSelectedPlant--;
                currentField.GetComponent<Field>().remainingPlantSlot++;
                break;
            }

        }
    }
    private void Planting()
    {
        if (NumberOfSelectedPlant <= 0)
        {
            return;
        }
        int i = 0;
        foreach (Transform tile in currentField.transform)
        {
            if (i < NumberOfSelectedPlant)
            {
                if (tile.GetComponent<PlantSlot>().hasPlant == false)
                {
                    GameObject planted = Instantiate(currentPlants[i].plant, tile.transform.position, Quaternion.identity);
                    tile.GetComponent<PlantSlot>().hasPlant = true;
                    tile.GetComponent<PlantSlot>().plant = planted;
                    planted.GetComponent<Plant>().plantedSlot = tile;
                    i++;
                }
            }
            else
            {
                break;
            }
        }

        for (int index = 0; index < NumberOfSelectedPlant; index++)
        {
            player.GetComponent<PlayerInventory>().inventory.Subtract(currentPlants[index]);
        }
       
        currentPlants.Clear();
        NumberOfSelectedPlant = 0;
        UIToggle();
    }

    void Setup()
    {
        if (selectedSeeds.Count == player.GetComponent<PlayerInventory>().inventory.slots.Count)
        {
            for (int i = 0; i < selectedSeeds.Count; i++)
            {
                if (player.GetComponent<PlayerInventory>().inventory.slots[i].type != CollectableType.NONE)
                {
                    selectedSeeds[i].GetComponent<SelectSeeds>().SetItem
                        (player.GetComponent<PlayerInventory>().inventory.slots[i]);
                    selectedSeeds[i].GetComponent<PlantSeed>().IdentifyPlantType
                        (player.GetComponent<PlayerInventory>().inventory.slots[i]);
                }
                else
                {
                    selectedSeeds[i].GetComponent<SelectSeeds>().SetEmpty();
                    selectedSeeds[i].GetComponent<PlantSeed>().IdentifyPlantType
                        (player.GetComponent<PlayerInventory>().inventory.slots[i]);
                }
            }
        }
    }
}
