using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy1move : MonoBehaviour
{
     public float speed;
    //public bool MoveRight;
    
    

    public Rigidbody2D rb;
    public Transform groundCheckPos;
    public LayerMask groundLayer;
    public Collider2D bodyCollider;
    
   

    //[HideInInspector]
    public bool mustPatrol;
    public bool mustTurn;

    audiomanager audiomanager;

    public virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audiomanager = FindObjectOfType<audiomanager>();
    }

    void Update()
    {
            Patrol();
    }


    public void Patrol()
    {
        transform.Translate(speed * Time.deltaTime * 2,0,0);
    }

    public virtual void OnTriggerEnter2D(Collider2D trig){
        if(trig.tag=="turn"){
            Flip();   
        }
        
    }
    public void Flip(){
        mustPatrol = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        speed *= -1;
        mustPatrol = true;
    }

    public void KillEnemy()
    {
        audiomanager.Play("enemy kill");
        Destroy(gameObject);
    }


}

