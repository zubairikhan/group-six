using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{


    [SerializeField] Rigidbody2D rb;
    [SerializeField] float walkSpeed= 1f;
    [SerializeField] float jumpSpeed = 1f;
    [SerializeField] float fallMultiplier = 2.5f;
    [SerializeField] float stompingFallMultiplier = 3.5f;
    [SerializeField] int extraJumpsAllowed;
    [SerializeField] float stompModePermissionDuration;

    


    [SerializeField] Joystick joystick;
    [SerializeField] GameObject stompTrigger;

    int extraJumpsLeft;
    bool isWalking = false;
    bool jump = false;
    bool isGrounded = false;

    [SerializeField] Transform groundCheck;
    [SerializeField] float checkRadius;
    [SerializeField] LayerMask whatIsJumpable;

    private Animator anim;
    private float dirX;
    private bool facingRight = true;
    private Vector3 localScale;
    public Vector3 checkPoint;

    

    [SerializeField] PlayerHealth playerHealth;
    bool canStomp= false;
    bool isStomping;
    bool swipedDown;

    BatteryController batteryObj;
    ScoreScript scoreObj;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
        extraJumpsLeft = extraJumpsAllowed;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        localScale = transform.localScale;
        checkPoint = transform.position;
        

    }

    // Update is called once per frame
    void Update()
    {
       

        //movement with keyboard
        dirX = Input.GetAxisRaw("Horizontal");

        //For joystick control. Do NOT delete
        /*if (joystick.Horizontal >= 0.5f)
        {
            dirX = 1;
        }
        else if (joystick.Horizontal <= -0.5f)
        {
            dirX = -1;
        }
        else
        {
            dirX = 0f;
        }
        */
        

        

        if (isGrounded == true)
        {
            extraJumpsLeft = extraJumpsAllowed;
            
        }


        //jump using keyboard
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && extraJumpsLeft > 0)
        {
            jump = true;
        }
        else if((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && extraJumpsLeft <= 0 && isGrounded)
        {
            jump = true;
        }

        //Stomping using keyboard
        if((Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) && canStomp)
        {
            ToggleStompMode(true);
        }
        

        //stomping using mobile
        /*
        if (joystick.Vertical > -0.2f)
        {
            swipedDown = false;
        }

        if (joystick.Vertical <= -0.7f && canStomp)
        {
            if (!swipedDown)
            {
                ToggleStompMode(true);
                swipedDown = true;
            }
        }
        */
        
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsJumpable);

        Walk();

        //jump using keyboard
        if (jump)
        {
            Jump();
            
        }
        
        

        QuickFall();
    }

    private void QuickFall()
    {
        if (rb.velocity.y < 0 && !isStomping)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y < 0 && isStomping)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (stompingFallMultiplier - 1) * Time.deltaTime;
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

    public void Jump()
    {

        //Jump for mobile input
        /*if(extraJumpsLeft > 0 || extraJumpsLeft <=0 && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
            extraJumpsLeft--;
            anim.SetBool("jumped", true);
            //jump = false;
        }
        */
        

        //jump using keyboard
        rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        extraJumpsLeft--;
        anim.SetBool("jumped", true);
        jump = false;
        
        StartCoroutine(ToggleStompPermission());



        
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

    

    IEnumerator ToggleStompPermission()
    {
        canStomp = true;
        
        yield return new WaitForSeconds(stompModePermissionDuration);
        canStomp = false;
        

    }

    private void ToggleStompMode(bool status)
    {
        isStomping = status;
        stompTrigger.SetActive(status);
        //Debug.Log("isStomping: " + isStomping);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.tag == "bottom")
        {
            ResetWhenFall(collision);
        }

        else if (collision.tag == "Checkpoint")
        {
            checkPoint = collision.transform.position;

        }

        else if (collision.tag == "battery")
        {

            ScoreScript.scoreValue++;
            Destroy(collision.gameObject);
            Debug.Log("Battery Collected!");
            print("Battery Collected!");
        }

        DamageDealer damageDealer = collision.gameObject.GetComponent<DamageDealer>();
        if (damageDealer !=null)
        {
            Debug.Log("got damage dealer");
            playerHealth.UpdateHealth(-damageDealer.GetDamage());
        }

        // else if (collision.tag == "bullet")
        // {  
        //     playerHealth.UpdateHealth(bullet.damage);
        // }


    }

    private void ResetWhenFall(Collider2D collision)
    {
        if (collision.tag == "bottom")
        {
            transform.position = checkPoint;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        StopStomping(collision);
        

    }

    private void StopStomping(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            if (isStomping)
            {
                ToggleStompMode(false);
                swipedDown = false;
            }
        }
    }

    public void StopJumpAnimation()
    {
        anim.SetBool("jumped", false);
    }
    public void SetIsStomping(bool status)
    {
        ToggleStompMode(false);
    }

}
