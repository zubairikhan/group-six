using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    [SerializeField] BoxCollider2D boxCollider;
    [SerializeField] Animator animator;
    

    public void Activate()
    {
        animator.SetBool("open", true);
        Debug.Log("Switch activated");
        boxCollider.enabled = false;
    }
}
