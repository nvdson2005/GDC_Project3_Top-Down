using System;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private AudioClip attackSound;
    [SerializeField] private AudioClip hitSound;
    
    public float speed;
    private float originalSpeed;
    private float hitSpeed = 10;
    private Vector3 direction;
    public int damage;
    private int originalDamage;

    public Animator animator;

    public GameObject visual;

    public GameObject hitIcon;
    public int HP;
    public int maxHP;
    public Vector3 attackDirecton;
    public bool hitting = false;
    private float hittingTime = 0.3f;
    private float hitCooldown = 1f;
    private bool canGetHit = true;
    private float timer = 0f;

    public bool die = false;

    private void Start()
    {
        originalSpeed = speed;
        originalDamage = damage;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        direction = new Vector3(horizontal, vertical, 0);    
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("attack");
            GetComponent<PlayerCombatHandler>().Attack(horizontal, vertical);
            
            AudioManagerScript.Instance.PlaySFX(attackSound);
        }
    }

    private void FixedUpdate()
    {
        if (hitting)
        {
            timer += Time.deltaTime;
            if (timer <= 0.15f)
            {
                transform.position += attackDirecton.normalized * hitSpeed * Time.deltaTime;
            }
            else
            {

            }
        }
        else
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
            }
        }
    }


    private void ResetHitting()
    {
        timer = 0;
        hitting = false;
        animator.SetBool("hitting", false);
        Color currentColor = visual.GetComponent<SpriteRenderer>().color;
        currentColor = Color.white;
        currentColor.a = 0.5f;
        visual.GetComponent<SpriteRenderer>().color = currentColor;      
    }

    private void ResetCanGetHit()
    {
        canGetHit = true;
        visual.GetComponent<SpriteRenderer>().color = Color.white;
    }

    public void TakeDamage(GameObject enemy)
    {
        AudioManagerScript.Instance.PlaySFX(hitSound);
        
        if (!canGetHit)
        {
            return;
        }
        int health = HP;
        health -= enemy.GetComponent<SlimePatrolAndAttack>().damage;
        if (health <= 0)
        {
            Die();
        }
        else
        {
            HP = health;
        }
        hitIcon.transform.DOScale(new Vector2(2f, 2f), 0.3f);
        hitIcon.transform.DOScale(new Vector2(0f, 0f), 0.3f).SetDelay(0.3f);
        attackDirecton = gameObject.transform.position - enemy.transform.position;
        hitting = true;
        canGetHit = false;
        animator.SetBool("hitting", true);
        visual.GetComponent<SpriteRenderer>().color = Color.red;  
        Invoke("ResetHitting", hittingTime);
        Invoke("ResetCanGetHit", hitCooldown);
    }

    private void Die()
    {
        Time.timeScale = 0;
        die = true;
    }

    public void IncreaseHP(int amount)
    {
        if (HP + amount <= maxHP)
        {
            HP += amount;
        }
    }

    public void DoubleAttack(float duration)
    {
        damage *= 2;
        Invoke(nameof(ResetAttackPower), duration);
    }

    private void ResetAttackPower()
    {
        damage = originalDamage;
    }
    
    public void DoubleSpeed(float duration)
    {
        speed *= 1.75f;
        Invoke(nameof(ResetSpeed), duration);
    }

    private void ResetSpeed()
    {
        speed = originalSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            if (collision.gameObject.GetComponent<SlimePatrolAndAttack>().attacking == true)
            {
                TakeDamage(collision.gameObject);
            }
        }
    }

}
