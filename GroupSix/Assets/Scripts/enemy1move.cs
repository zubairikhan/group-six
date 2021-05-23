using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy1move : MonoBehaviour
{
     public float speed, range;
    //public bool MoveRight;
    public float distToPlayer;
    

    public Rigidbody2D rb;
    public Transform groundCheckPos;
    public LayerMask groundLayer;
    public Collider2D bodyCollider;
    public Transform player;
   

    //[HideInInspector]
    public bool mustPatrol;
    public bool mustTurn;
    

    public virtual void Start()
    {

        rb = GetComponent<Rigidbody2D>(); 
        mustPatrol = true;
    }

    public virtual void Update()
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

       
        }
          else{
            mustPatrol = true;
        }
      
    }

    // private void FixedUpdate()
    // {
    //     if(mustPatrol)
    //     {
    //         mustTurn = !Physics2D.OverlapCircle(groundCheckPos.position, 0.1f, groundLayer);
    //     }
    // }

    void Patrol()
    {
        // if(mustTurn || bodyCollider.IsTouchingLayers(groundLayer))
        // {
        //     Flip();
        // }
        transform.Translate(speed * Time.deltaTime * 2,0,0);
        //rb.velocity = new Vector2(speed * Time.fixedDeltaTime, rb.velocity.y);
    }

    public virtual void OnTriggerEnter2D(Collider2D trig){
        if(trig.gameObject.CompareTag("turn")){
         Flip();   
        }
    }
      public void Flip(){
        mustPatrol = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        speed *= -1;
        mustPatrol = true;
    }

   

    
    }

