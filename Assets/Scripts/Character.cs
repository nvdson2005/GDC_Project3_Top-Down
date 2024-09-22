using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float speed;
    private Vector3 direction;

    public Animator animator;

    public GameObject visual;

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        direction = new Vector3(horizontal, vertical, 0);    
    }

    private void FixedUpdate()
    {
        transform.position += direction.normalized * speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }


        if (Input.GetKey(KeyCode.W))
        {
            animator.SetFloat("X", 0);
            animator.SetFloat("Y", 1);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            animator.SetFloat("X", -1);
            animator.SetFloat("Y", 0);
<<<<<<< HEAD
            //visual.GetComponent<SpriteRenderer>().flipX = true;
=======
            // visual.GetComponent<SpriteRenderer>().flipX = true;
>>>>>>> c943a5c468e619b7612370a8a3e81dcc6e9dd685
        }
        else if (Input.GetKey(KeyCode.S))
        {
            animator.SetFloat("X", 0);
            animator.SetFloat("Y", -1);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            animator.SetFloat("X", 1);
            animator.SetFloat("Y", 0);
<<<<<<< HEAD
            //visual.GetComponent<SpriteRenderer>().flipX = false;
=======
            // visual.GetComponent<SpriteRenderer>().flipX = false;
>>>>>>> c943a5c468e619b7612370a8a3e81dcc6e9dd685
        }
    }


}
