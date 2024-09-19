using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potato : Plant
{
    public Animator animator;

    public void Growth()
    {
        animator.SetBool("growth", true);
        isGrowth = true;
    }
}
