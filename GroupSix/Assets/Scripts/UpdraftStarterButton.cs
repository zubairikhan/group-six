using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdraftStarterButton : MonoBehaviour
{
    [SerializeField] GameObject updraft;
    [SerializeField] Animator animator;
   

    bool started= false;
    
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Stomper")
        {
            if (!started)
            {
                ActivateUpdraft();
                
            }
            
        }
    }

    private void ActivateUpdraft()
    {
        Debug.Log("updraft activated");
        animator.SetBool("buttonPushed", true);
        started = true;
        updraft.SetActive(true);
    }

}
