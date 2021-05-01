using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    [SerializeField] BoxCollider2D boxCollider;
    [SerializeField] Animator animator;
    [SerializeField] SpriteRenderer light;
    

    public void Activate()
    {
        light.color = new Color(0, 1, 0, 1);
        animator.SetBool("open", true);
        
        Debug.Log("Switch activated");
        boxCollider.enabled = false;
    }
}
