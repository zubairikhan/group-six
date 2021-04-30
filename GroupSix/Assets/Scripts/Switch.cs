using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    [SerializeField] BoxCollider2D boxCollider;
    

    public void Activate()
    {
        Debug.Log("Switch activated");
        boxCollider.enabled = false;
    }
}
