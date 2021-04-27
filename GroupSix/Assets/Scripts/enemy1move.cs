using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy1move : Enemy2move
{
    //public float speed,range;
    public bool MoveRight;
   // private float distToPlayer;
    //public Transform player;
    
    

    // Update is called once per frame
    void Update()
    {
        //if move right bool is true meaning enemy will move to the right
        if (MoveRight){
            transform.Translate(2 * Time.deltaTime * speed,0,0,Camera.main.transform);
            transform.localScale = new Vector2(2,2);

        }
        else{
            transform.Translate(-2 * Time.deltaTime * speed,0,0,Camera.main.transform);
            transform.localScale = new Vector2(-2,2);
        }
         distToPlayer = Vector2.Distance(transform.position, player.position);
        
        if(distToPlayer <= range)
        {
            
            if(player.position.x > transform.position.x && transform.localScale.x < 0
            ||player.position.x < transform.position.x && transform.localScale.x > 0)
            {
                Flip();
            }
    }
    }

    

    void OnTriggerEnter2D(Collider2D trig){
        if(trig.gameObject.CompareTag("turn")){
            if (MoveRight){
                MoveRight = false;
            }
            else{
                MoveRight= true;
                
            }
        }
    }

    void Flips(){
        base.Flip();
    }

    
    }

