using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float walkSpeed= 1f;
    [SerializeField] float jumpSpeed = 1f;
    [SerializeField] float fallMultiplier = 2.5f;
    bool isGrounded = false;
    bool jumped = false;
    [SerializeField] Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Walk();
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            jumped = true;
        }
    }

    private void FixedUpdate()
    {
        if (jumped)
        {
            rb.velocity= new Vector2(rb.velocity.x, jumpSpeed);
            jumped = false;
        }
        if ( rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime; 
        }
    }

    private void Walk()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * walkSpeed;
        var newXPos = transform.position.x + deltaX;
        transform.position = new Vector2(newXPos, transform.position.y);
        //float horizontalVelocity = Input.GetAxis("Horizontal") * walkSpeed;
        //rb.velocity = new Vector2(horizontalVelocity, rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }
}
