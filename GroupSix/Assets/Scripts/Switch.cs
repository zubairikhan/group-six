using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    [SerializeField] BoxCollider2D boxCollider;
    [SerializeField] Animator animator;
    [SerializeField] SpriteRenderer switchLight;
    [SerializeField] SpriteRenderer doorLight;
   
    

    public void Activate()
    {
        FindObjectOfType<audiomanager>().Play("door open");
        switchLight.color = new Color(0, 1, 0, 1);
        doorLight.color = new Color(0, 1, 0, 1);
        animator.SetBool("open", true);
        boxCollider.enabled = false;
    }
}
