using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2move : MonoBehaviour
{
    public float speed, range, timeBTWShots, shootSpeed;
    //public bool MoveRight;
    private float distToPlayer;
    

    public Rigidbody2D rb;
    public Transform groundCheckPos;
    public LayerMask groundLayer;
    public Collider2D bodyCollider;
    public Transform player, shootPos;
    public GameObject bullet;

    [HideInInspector]
    public bool mustPatrol;
    private bool mustTurn, canShoot;
    

    void Start()
    {
        mustPatrol = true;
        canShoot = true;
    }

    void Update()
    {
        if(mustPatrol){
            Patrol();
        }

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

            }
            StartCoroutine(Shoot());
        }
        else
        {
            mustPatrol = true;
        }
    }

    private void FixedUpdate()
    {
        if(mustPatrol)
        {
            mustTurn = !Physics2D.OverlapCircle(groundCheckPos.position, 0.1f, groundLayer);
        }
    }

    void Patrol()
    {
        if(mustTurn || bodyCollider.IsTouchingLayers(groundLayer))
        {
            Flip();
        }
        rb.velocity = new Vector2(speed * Time.fixedDeltaTime, rb.velocity.y);
    }




    // void OnTriggerEnter2D(Collider2D trig){
    //     if(trig.gameObject.CompareTag("turn")){
    //         if (MoveRight){
    //             MoveRight = false;
    //         }
    //         else{
    //             MoveRight = true;
    //         }
    //     }
    // }

    void Flip(){
        mustPatrol = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        speed *= -1;
        mustPatrol = true;
    }

    IEnumerator Shoot(){ 
        canShoot = false;
        yield return new WaitForSeconds(timeBTWShots);
        GameObject newBullet = Instantiate(bullet,shootPos.position, Quaternion.identity);
        
        newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(shootSpeed * speed * Time.fixedDeltaTime, 0f);
        canShoot = true; 
    }
}
