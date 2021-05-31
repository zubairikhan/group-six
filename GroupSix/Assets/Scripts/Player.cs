using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement configs")]
    [SerializeField] float walkSpeed= 1f;
    [SerializeField] float jumpSpeed = 1f;
    [SerializeField] float fallMultiplier = 2.5f;
    [SerializeField] float stompingFallMultiplier = 3.5f;
    [SerializeField] float updraftFallMultiplier = 1.5f;
    [SerializeField] int extraJumpsAllowed;
    [SerializeField] float stompModePermissionDuration;
    [SerializeField] ParticleSystem dust;
   



    [Header("Extra configs")]
    [SerializeField] float playerBlinkingTime= 0.01f;
    [SerializeField] float playerJumpOffEnemyForce = 5f;
    //[SerializeField] float updrafFallVelocity= 2f;
    [SerializeField] Animator fadeAnimator; 

    [Header("References")]
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Joystick joystick;
    [SerializeField] GameObject stompTrigger;
    [SerializeField] public PlayerHealth playerHealth;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Switch switchBoard;
    [SerializeField] ScoreScript scoreScript;
    [SerializeField] audiomanager audioManager;
    [SerializeField] reverse reverse;
    [SerializeField] CameraShake cameraShake;
    
    int extraJumpsLeft;
    bool isWalking = false;
    bool jump = false;
    bool isGrounded = false;

    [Header("Wall jumping configs")]
    [SerializeField] Transform groundCheck;
    [SerializeField] float checkRadius;
    [SerializeField] LayerMask whatIsJumpable;


    [Header("Camera shake configs")]
    [SerializeField] float shakeDuration;
    [SerializeField] float shakeMagnitude;
    [SerializeField] bool fadeOut;


    private Animator anim;
    private float dirX;
    private bool facingRight = true;
    private Vector3 localScale;

    [Header("Latest checkpoint")]
    public Vector3 checkPoint;


    //Enemy Projectile Deflection
    bool willDeflect= false;
    Rigidbody2D enemyProjectileRb= null;

    
    bool canStomp = false;
    bool isStomping;
    bool swipedDown;
    bool inUpdraft;
    bool isDead;
    bool nearToSwitch;

    BatteryController batteryObj;
    //ScoreScript scoreObj;
    

    private Coroutine playerBlink;

    bool canControl;


    public bool getIsStomping()
    {
        return isStomping;
    }


    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
        audioManager = FindObjectOfType<audiomanager>();
        extraJumpsLeft = extraJumpsAllowed;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        localScale = transform.localScale;
        checkPoint = transform.position;
        canControl = true;
        

    }

    // Update is called once per frame
    void Update()
    {

        if (canControl) { 
            //movement with keyboard
            dirX = Input.GetAxisRaw("Horizontal");

            //////////////////////////////////////////////////////////////////////For joystick control. Do NOT delete///////////////////////////////////////////////////////////////////////////////
            
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
            }*/
            




       
        




            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

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
            
            /*if (joystick.Vertical > -0.2f)
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
            }*/
            
        




            //Action button(switch+deflect) using keyboard

            if (Input.GetKeyDown(KeyCode.G) && nearToSwitch)
            {
                if(scoreScript.GetCellCount() > 0)
                {
                    ActivateSwitch();
                }
            }
        
            if (Input.GetKeyDown(KeyCode.G) && willDeflect && enemyProjectileRb!=null)
            {
                enemyProjectileRb.velocity = -enemyProjectileRb.velocity;
            }
            



        }

    }
    public void Action()
    {
        Debug.Log("Action pressed");
        if (nearToSwitch)
        {
            if (scoreScript.GetCellCount() > 0)
            {
                ActivateSwitch();
            }
        }
        if (willDeflect && enemyProjectileRb != null)
        {
            enemyProjectileRb.velocity = -enemyProjectileRb.velocity;
        }
    }

    private void ActivateSwitch()
    {
        scoreScript.DecrementCellCount();
        switchBoard.Activate();
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
        if (rb.velocity.y < 0 && !isStomping && !inUpdraft)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y < 0 && inUpdraft)
        {
            rb.velocity -= Vector2.up * Physics2D.gravity.y * (updraftFallMultiplier - 1) * Time.deltaTime;
            //rb.velocity = Vector2.down * updrafFallVelocity;
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
        if(extraJumpsLeft > 0 || extraJumpsLeft <=0 && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
            extraJumpsLeft--;
            anim.SetBool("jumped", true);
            //jump = false;
        }
        
        
        
        //jump using keyboard
        rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        extraJumpsLeft--;
        audioManager.Play("jump grunt");
        anim.SetBool("jumped", true);
        jump = false; 
        //anim.SetBool("isStomping", false);
        


        StartCoroutine(ToggleStompPermission());
        //anim.SetBool("isGrounded", true);
        



        
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

    private void FootStep(){
        audioManager.Play("footsteps");
    }

    public void Die()
    {
        //anim.SetBool("isDead", true);
        
        Invoke("Respawn" , 1f);
        
    }

    private void Respawn()
    {
        //anim.SetBool("isDead", false);
        //anim.SetBool("isGrounded", true);
        transform.position = checkPoint;
        playerHealth.InitializeHealthStatus();
    }

    IEnumerator ToggleStompPermission()
    {
        canStomp = true;
        yield return new WaitForSeconds(stompModePermissionDuration);
        canStomp = false;
    }

    private void ToggleStompMode(bool status)
    {
        if (status== false)
        {
            StartCoroutine(cameraShake.ShakeCamera(shakeDuration, shakeMagnitude, true));
        }
        isStomping = status;
        stompTrigger.SetActive(status);
        Debug.Log("isStomping: " + isStomping);

        if(isStomping){
            anim.SetBool("isStomping", true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Switch")
        {
            Debug.Log("triggered switch");
            nearToSwitch = true;
            switchBoard = collision.gameObject.GetComponent<Switch>();
        }
        if (collision.tag == "bottom")
        {
            //ResetWhenFall();
            canControl = false;
            //rb.velocity = new Vector2(0, rb.velocity.y);
            dirX = 0;
            Invoke("ResetWhenFall", 1f);
        }

        else if (collision.tag == "Checkpoint")
        {
            UpdateCheckpoint(collision);

        }

        else if (collision.tag == "battery")
        {
            CollectBattery(collision);

        }

        else if (collision.tag == "snack")
        {
            CollectSnack(collision);
            DamageDealer snackHealth = collision.gameObject.GetComponent<DamageDealer>();
            IncreaseHealth(snackHealth);


        }
        else if (collision.tag == "Ground")
        {
            CreateDust();
        }

        else if (collision.tag == "spikes")
        {
            Die();
        }

        if (collision.gameObject.tag == "bullet" || collision.gameObject.tag=="DmgRock")
        {
            DamageDealer damageDealer = collision.gameObject.GetComponent<DamageDealer>();
            TakeDamage(damageDealer);
        }
        if (collision.gameObject.tag == "UpdraftZone")
        {
            inUpdraft = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "UpdraftZone")
        {
            inUpdraft = false;
        }
        if (collision.tag == "Switch")
        {
            nearToSwitch = false;
            switchBoard = null;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        StopStomping(collision);

        if (collision.gameObject.tag == "EnemyTop")
        {
            
            Vector2 force = new Vector2(0f, playerJumpOffEnemyForce);
            //rb.AddForce(force, ForceMode2D.Impulse);
            rb.velocity = force;
        }
        if(collision.gameObject.tag == "Enemy")
        {
            DamageDealer damageDealer = collision.gameObject.GetComponent<DamageDealer>();
            TakeDamage(damageDealer);
        }
    }

    private void UpdateCheckpoint(Collider2D collision)
    {
        checkPoint = collision.transform.position;
    }

    private void CollectBattery(Collider2D collision)
    {
        scoreScript.IncrementCellCount();
        audioManager.Play("cell collection");
        Destroy(collision.gameObject);

    }

    private void CollectSnack(Collider2D collision)
    {
        audioManager.Play("snackable");
        Destroy(collision.gameObject);

    }


    private void TakeDamage(DamageDealer damageDealer)
    {
        if (damageDealer != null) { 
            playerHealth.UpdateHealth(-damageDealer.GetDamage());
            if(playerBlink != null)
            {
                StopCoroutine(playerBlink);
            }
        
            playerBlink= StartCoroutine(PlayerBlink());
            //Vector2 force = new Vector2(-5f, 10f);
            //rb.velocity = force;
        }

    }

    private void IncreaseHealth(DamageDealer snackHealth)
    {
        playerHealth.UpdateHealth(snackHealth.GetDamage());
        
        
        //playerBlink= StartCoroutine(PlayerBlink());
        //Vector2 force = new Vector2(-5f, 10f);
        //rb.velocity = force;

    }

    IEnumerator PlayerBlink()
    {
        int count = 7;
        while (count >=0 )
        {
            spriteRenderer.enabled = !spriteRenderer.enabled;
            yield return new WaitForSeconds(playerBlinkingTime);
            count--;
        }
        spriteRenderer.enabled = true;
    }

    

    private void ResetWhenFall()
    {
        canControl = true;
        transform.position = checkPoint;
    }
    private void StopStomping(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            if (isStomping)
            {
                ToggleStompMode(false);
                swipedDown = false;
                //StartCoroutine(cameraShake.ShakeCamera(shakeDuration, shakeMagnitude, true));
                //anim.SetBool("isStomping", false);
            }
        }
    }

    public void StopJumpAnimation()
    {
        anim.SetBool("jumped", false);
    }
    public void StopStompAnimation()
    {
        anim.SetBool("isStomping", false);
    }
    public void SetIsStomping(bool status)
    {
        ToggleStompMode(status);
        //anim.SetBool("isStomping", true);
    }
    void CreateDust(){
        dust.Play();
    }

    public void SetEnemyProjectileRb(Rigidbody2D rb)
    {
        enemyProjectileRb = rb;
    }
    public void SetWillDeflect(bool status)
    {
        willDeflect = status; ;
    }
}
