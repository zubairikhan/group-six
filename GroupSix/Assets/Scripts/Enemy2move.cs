using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2move : enemy1move
{
    // public float speed, range, timeBTWShots, shootSpeed;
    // //public bool MoveRight;
    // public float distToPlayer;
    

    // public Rigidbody2D rb;
    // public Transform groundCheckPos;
    // public LayerMask groundLayer;
    // public Collider2D bodyCollider;
    // public Transform player, shootPos;
    

    // //[HideInInspector]
    // public bool mustPatrol;
    // public bool mustTurn;
    public GameObject bullet;
    public float shootSpeed, timeBTWShots,range;
    public bool canShoot;
    public Transform shootPos;
    [SerializeField] private Transform player;
    float distToPlayer;


    public override void Start()
    {
        base.Start();
        canShoot = true;
        mustPatrol = true;
        
    }

    void Update()
    {
        if (mustPatrol)
            Patrol();
            
        distToPlayer = Vector2.Distance(transform.position, player.position);      
        if(distToPlayer <= range)
        {
             if(player.position.x > transform.position.x && transform.localScale.x < 0
            ||player.position.x < transform.position.x && transform.localScale.x > 0)
            {
                Flip();
            }

           mustPatrol = false;
         
           rb.velocity = Vector2.zero;
          
            if(canShoot)
            {
                StartCoroutine(Shoot());
            }

        }
        else
            mustPatrol = true;
      
    }
    public override void OnTriggerEnter2D(Collider2D trig){
        base.OnTriggerEnter2D(trig);  
        }

    IEnumerator Shoot(){ 
        canShoot = false;
        yield return new WaitForSeconds(timeBTWShots);
        GameObject newBullet = Instantiate(bullet,shootPos.position, Quaternion.identity) as GameObject;
        FindObjectOfType<audiomanager>().Play("projectile shoot");
        newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(shootSpeed * speed * Time.fixedDeltaTime, 0f);
        canShoot = true; 
    }
}
