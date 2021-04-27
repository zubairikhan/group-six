using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy1move : MonoBehaviour
{
    public float speed;
    public bool MoveRight;
  
    
    

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

   

    
    }

