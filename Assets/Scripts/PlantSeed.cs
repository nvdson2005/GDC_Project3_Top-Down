using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor.Build.Content;

public class PlantSeed : MonoBehaviour
{
    public GameObject plantObject;
    private GameObject gms;


    private void Start()
    {
        gms = GameObject.FindGameObjectWithTag("GameController");
        GetComponent<Button>().onClick.AddListener(ChoosePlant);
    }



    public void ChoosePlant()
    {
        gms.GetComponent<GameManager>().ChoosePlant(plantObject);
    }
}
