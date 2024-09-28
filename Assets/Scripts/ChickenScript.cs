using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenScript : MonoBehaviour
{
    [SerializeField] private GameObject chickenShopUI;
    [SerializeField] private AudioClip chickenShopOpenSound;
    
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
        if (other.gameObject.GetComponent<Character>() != null)
        {
            Debug.Log("Touching chicken");
            chickenShopUI.SetActive(true);
            AudioManagerScript.Instance.PlaySFX(chickenShopOpenSound);
        }
    }

    // Close shop when not touching chicken
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<Character>() != null)
        {
            Debug.Log("Not touching chicken");
            chickenShopUI.SetActive(false);
            AudioManagerScript.Instance.PlaySFX(chickenShopOpenSound);
        }
    }
}
