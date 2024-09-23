using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    Animator anim;
    bool val;
    CircleCollider2D circlecol;
    // Start is called before the first frame update
    void Start()
    {
        circlecol = GetComponent<CircleCollider2D>();
        anim = GetComponent<Animator>();
        val = false;
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Player"){
            if(!val){
                val = !val;
                anim.SetBool("isOpen", val);
                circlecol.enabled = false;
            } else{
                val = !val;
                anim.SetBool("isOpen", val);
                circlecol.enabled = true;
            }
        }
    }
}
