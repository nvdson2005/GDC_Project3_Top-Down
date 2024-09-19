using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strawberry : Plant
{
    public Animator animator;

    public Transform plantedSlot;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Growth()
    {
        animator.SetBool("growth", true);
        isGrowth = true;
    }
}
