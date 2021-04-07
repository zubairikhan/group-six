using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float walkSpeed= 1f;
    [SerializeField] float jumpSpeed = 1f;
    [SerializeField] float fallMultiplier = 2.5f;
    bool isGrounded = false;
    bool isWalking = false;
    bool jumped = false;
    

    private Animator anim;
    private float dirX;
    private bool facingRight = true;
    private Vector3 localScale;
    private Vector3 checkPoint;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        localScale = transform.localScale;
        checkPoint = transform.position; 
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            jumped = true;
        }
        
    }

    void FixedUpdate()
    {
        Walk();
        //rb.velocity = new Vector2(dirX, rb.velocity.y);


        if (jumped)
        {
            Jump();
        }

        QuickFall();
    }

    private void QuickFall()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
    }

    void LateUpdate()
    {
        ChangeDirection();
    }

    private void ChangeDirection()
    {
        if (dirX > 0)
        {
            facingRight = true;
        }
        else if (dirX < 0)
        {
            facingRight = false;
        }

        if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
        {
            localScale.x *= -1;
        }
        transform.localScale = localScale;
    }

    private void Jump()
    {
        
        rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        anim.SetBool("jumped", true);
        
        jumped = false;
        
    }

    private void Walk()
    {
        float horizontalVelocity = dirX * walkSpeed;
        rb.velocity = new Vector2(horizontalVelocity, rb.velocity.y);

        if (Mathf.Abs(dirX) > 0 && rb.velocity.y == 0)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
    }

    public void StopJumpAnimation()
    {
        Debug.Log("Stopping jump anim");
        anim.SetBool("jumped", false);
    }

    public void SetGroundedStatus(bool status)
    {
        isGrounded = status;
    }
    
    public bool GetGroundedStatus()
    {
        return isGrounded;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "bottom")
        {
            transform.position = checkPoint;
        }
    }
    /*private void OnCollisionEnter2D(Collision2D collision)
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
    }*/
}
