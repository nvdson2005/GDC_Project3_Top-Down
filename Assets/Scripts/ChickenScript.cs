using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenScript : MonoBehaviour
{
    [SerializeField] private GameObject chickenShopUI;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Open shop when touching chicken
    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Touching chicken");
        if (other.gameObject.GetComponent<Character>() != null)
        {
            chickenShopUI.SetActive(true);
        }
    }

    // Close shop when not touching chicken
    private void OnCollisionExit2D(Collision2D other)
    {
        Debug.Log("Not touching chicken");
        if (other.gameObject.GetComponent<Character>() != null)
        {
            chickenShopUI.SetActive(false);
        }
    }
}
