using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatHandler : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float atkRange;
    [SerializeField] float pushBackForce;
    void Start(){
        rb = GetComponent<Rigidbody2D>();
    }



    //This is called in Character.cs
    public void Attack(float x, float y){
        Collider2D[] atkcircle = Physics2D.OverlapCircleAll(new Vector2(transform.position.x + x, transform.position.y + y), atkRange);
        foreach(Collider2D coll in atkcircle){
            if(coll.gameObject.CompareTag("Enemy")){
                coll.gameObject.GetComponent<SlimePatrolAndAttack>().TakeDamage(1);
            }
        }
    }
    public void TakeDamage(Vector2 enemytarget){
        //This is called in SlimePatrolAndAttack.cs
        //Has not include reducing player's HP yet
        Vector2 pushbackdirection = new Vector2(transform.position.x - enemytarget.x, transform.position.y - enemytarget.y);
        rb.AddForce(pushbackdirection * pushBackForce, ForceMode2D.Impulse);
    }
}
