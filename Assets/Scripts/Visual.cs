using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visual : MonoBehaviour
{
    public GameObject attackRangeDown;
    public GameObject attackRangeUp;
    public GameObject attackRangeLeft;
    public GameObject attackRangeRight;
    public void AttackDown()
    {
        attackRangeDown.SetActive(true);
        Invoke("AttackDownFinish", 0.15f);
    }
    public void AttackDownFinish()
    {
        attackRangeDown.SetActive(false);
    }
    public void AttackLeft()
    {
        attackRangeLeft.SetActive(true);
        Invoke("AttackLeftFinish", 0.15f);
    }
    public void AttackLeftFinish()
    {
        attackRangeLeft.SetActive(false);
    }
    public void AttackRight()
    {
        attackRangeRight.SetActive(true);
        Invoke("AttackRightFinish", 0.15f);
    }
    public void AttackRightFinish()
    {
        attackRangeRight.SetActive(false);
    }
    public void AttackUp()
    {
        attackRangeUp.SetActive(true);
        Invoke("AttackUpFinish", 0.15f);
    }
    public void AttackUpFinish()
    {
        attackRangeUp.SetActive(false);
    }
}
