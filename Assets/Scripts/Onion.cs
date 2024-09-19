using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Onion : Plant
{
    public Animator animator;

    public void Growth()
    {
        animator.SetBool("growth", true);
        /*isGrowth = true;
        Debug.Log("true");*/
        gameObject.GetComponent<Plant>().isGrowth = true;
    }
}
