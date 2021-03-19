using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float walkSpeed= 1f;
    [SerializeField] Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalVelocity = Input.GetAxis("Horizontal") * walkSpeed;
        rb.velocity = new Vector2(horizontalVelocity, rb.velocity.y);
    }
}
