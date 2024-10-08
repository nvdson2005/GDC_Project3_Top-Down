using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;
using DG.Tweening;
public class SlimePatrolAndAttack : MonoBehaviour
{
    [SerializeField] private AudioClip deathSound;
    
    ///
    int HP = 3;
    public int damage;
    ///
    public bool attacking = false;
    public bool afterAttack = false;
    bool isDead = false;
    Transform playerTarget;
    [SerializeField] float detectRange;
    [SerializeField] Vector2 direction = Vector2.right;
    [SerializeField] float speed;
    bool isRunning = true;
    bool goingAhead = true;
    Animator anim;
    Vector3 defaultScaleVector = new Vector3(1.25f, 1.25f, 0);
    Vector3 reverseScaleVector = new Vector3(-1.25f, 1.25f, 0);
    Rigidbody2D rigid;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerInRange() && !afterAttack)
        {
            //TODO
            Attack();
        }
        else
        {
            StartCoroutine(Patrol());
        }
        ///This is used to try the hit, death and drop loot function
        // if (Input.GetKeyDown(KeyCode.Space))
        // {
        //     TakeDamage(1);
        // }
        ///
    }
    public void TakeDamage(int hp)
    {
        /*

            This function is called from player to take damage of the slime


        */
        rigid.velocity = Vector2.zero;
        this.HP -= hp;
        Debug.Log(HP);
        anim.SetTrigger("Hit");
        if (HP <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        AudioManagerScript.Instance.PlaySFX(deathSound);
        
        isDead = true;
        anim.SetTrigger("Die");
        //This is used for drop loot items
        GetComponent<EnemyLootList>().InstantiateLootObject(transform.position);
        //
        Destroy(gameObject, 0.5f);
    }
    void Attack()
    {
        attacking = true;
        Invoke("ResetAttack", 0.3f);
        rigid.velocity = Vector2.zero;
        transform.DOMove(playerTarget.position, 1.5f);
        anim.SetBool("isAttacking", true);
        if ((transform.position.x > playerTarget.position.x))
        {
            transform.localScale = reverseScaleVector;
        }
        if (Vector2.Distance(transform.position, playerTarget.position) < 0.75f)
        {
            //Call to the player's take damage function here
            ///
            ///
            ///
            ///
            playerTarget.gameObject.GetComponent<PlayerCombatHandler>().TakeDamage(transform.position);
            Debug.Log("Attacked");
            transform.localScale = defaultScaleVector;
            afterAttack = true;
            anim.SetBool("isAttacking", false);
            StartCoroutine(ResetAfterAttack());
        }
    }

    private void ResetAttack()
    {
        attacking = false;
    }
    bool PlayerInRange()
    {
        //Detect the player in a circle area around the enemy


        Collider2D detector = Physics2D.OverlapCircle(transform.position, detectRange, 1 << LayerMask.NameToLayer("Player"));
        if (detector)
        {
            playerTarget = detector.gameObject.transform;
            return true;
        }
        else return false;
    }
    IEnumerator Patrol()
    {
        if (isDead)
        {
            //When the enemy dies, it stops moving


            rigid.velocity = Vector2.zero;
        }
        else
        {
            //Just normally patrol
            if (isRunning)
            {
                if (goingAhead) transform.localScale = defaultScaleVector;
                else transform.localScale = reverseScaleVector;
                anim.SetBool("isPatrolling", true);
                rigid.velocity = direction.normalized * speed;
            }
            else
            {
                anim.SetBool("isPatrolling", false);
                rigid.velocity = Vector2.zero;
                yield return new WaitForSeconds(2);
                isRunning = true;
            }
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        //Detect wall to change the direction


        if (other.gameObject.layer == LayerMask.NameToLayer("Wall"))
        {
            direction = direction * -1;
            isRunning = false;
            goingAhead = !goingAhead;
        }
    }
    IEnumerator ResetAfterAttack()
    {
        //Move back from the player, after 3 secs enable the attack again
        transform.position = Vector2.MoveTowards(transform.position, playerTarget.position, -speed * Time.deltaTime);
        yield return new WaitForSeconds(3f);
        afterAttack = false;
    }
    void OnDrawGizmos()
    {
        //Draw the detect range of the enemy on editor
        Gizmos.DrawWireSphere(transform.position, detectRange);
    }
    /*
    
        This is used for random customization of direction in EnemySpawnner.cs

    */
    public void RandomizeDirection()
    {
        direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        direction = direction.normalized;
    }
    /* 
    
        This function is used to randomize HP of slimes when spawnning
    
    */
    public void RandomizeHp()
    {
        HP = Random.Range(2, 5);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Attack"))
        {
            TakeDamage(GameObject.FindGameObjectWithTag("Player").GetComponent<Character>().damage);
        }
    }
}
