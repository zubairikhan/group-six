using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float walkSpeed= 1f;
    [SerializeField] float jumpSpeed = 1f;
    [SerializeField] float fallMultiplier = 2.5f;
    bool isGrounded = false;
    bool isWalking = false;
    bool jumped = false;
    [SerializeField] Rigidbody2D rb;

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
        dirX = Input.GetAxisRaw("Horizontal") * walkSpeed;

        if(Input.GetButtonDown("Jump") && rb.velocity.y == 0){
            rb.AddForce(Vector2.up * 500f);
        }

        if(Mathf.Abs(dirX) > 0 && rb.velocity.y == 0){
            anim.SetBool("isWalking", true);
        }
        else{
            anim.SetBool("isWalking", false);
        }

        if(rb.velocity.y == 0){
            anim.SetBool("jumped", false);
        }
        if (rb.velocity.y > 0){
            anim.SetBool("jumped", true);
        }
        if (rb.velocity.y < 0){
            anim.SetBool("jumped", false);
        }
        

    //     if (Input.GetAxis("Horizontal")!=0)
    //     {
    //         isWalking = true;
    //     }
    //     else
    //     { 
    //         isWalking = false;
    //     }

    //     //Walk();
    //     if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
    //     {
    //         jumped = true;
    //     }
    // }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(dirX, rb.velocity.y);
        
        // if (isWalking)
        // {
        //     Walk();
        // }
        // if (jumped)
        // {
        //     Jump();
        // }
        // if ( rb.velocity.y < 0)
        // {
        //     rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime; 
        // }
    }

    void LateUpdate(){
        if (dirX > 0){
            facingRight = true;
        }
        else if(dirX < 0){
            facingRight = false;
        }

        if(((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0))){
            localScale.x *= -1;
        }
        transform.localScale = localScale;
    }
    

    // private void Jump()
    // {
    //     rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
    //     jumped = false;
    // }

    // private void Walk()
    // {
    //     /*var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * walkSpeed;
    //     var newXPos = transform.position.x + deltaX;
    //     transform.position = new Vector2(newXPos, transform.position.y);
    //     */

    //     float horizontalVelocity = Input.GetAxis("Horizontal") * walkSpeed;
    //     rb.velocity = new Vector2(horizontalVelocity, rb.velocity.y);
        

    //     //rb.AddForce(new Vector2(Input.GetAxis("Horizontal")* walkSpeed, 0));
    // }

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
