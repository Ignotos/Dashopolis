using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;
    public float runSpeed;
    private float moveVelocity;
    public float jumpHeight;
    public float wallSlideSpeed;
    public int dirFacing;
    bool isWalking;
    bool isRunning;

    public Transform groundCheck;
    public float groundCheckRadius;
    public Transform leftWallCheck;
    public Transform rightWallCheck;
    public float wallCheckRadius;
    public LayerMask whatIsGround;
    private bool grounded;
    private bool onWall;


    //private bool doubleJumped;


    public Animator anim;
    AudioSource jumpSfx;
    AudioSource groundedSfx;
    AudioSource wallJumpSfx;
    bool hitGround;
    public GameObject hitGroundParticleEffect;

    /*
    public Transform firePoint;
    public GameObject ninjaStar;

    public float shotDelay;
    private float shotDelayCounter;
    */

    public float knockback;
    public float knockbackLength;
    public bool knockFromRight;
    public float knockbackCount;

    // Use this for initialization
    void Start()
    {
        isWalking = false;
        isRunning = false;
        AudioSource[] audios = GetComponents<AudioSource>();
        jumpSfx = audios[1];
        groundedSfx = audios[0];
        wallJumpSfx = audios[2];
        hitGround = true;
        //anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        if (!grounded)
        {
            onWall = Physics2D.OverlapCircle(leftWallCheck.position, wallCheckRadius, whatIsGround) || Physics2D.OverlapCircle(rightWallCheck.position, wallCheckRadius, whatIsGround);
            if (onWall)
            {
                /*
                if (Physics2D.OverlapCircle(leftWallCheck.position, wallCheckRadius, whatIsGround))
                {
                    wallDir = 1;
                }
                else
                {
                    wallDir = -1;
                }
                */
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (grounded)
        {
            doubleJumped = false;
        }
        */
        if (!grounded)
        {
            //Invoke("setHitGround", 0.1f);
            hitGround = false;
        }

        if (grounded && !hitGround)
        {
            groundedSfx.Play();
            Instantiate(hitGroundParticleEffect, groundCheck.transform.position + new Vector3(0, 0.2f, 0), groundCheck.transform.rotation);
            hitGround = true;
        }

        if (Input.GetButton("Dash") || Input.GetKey(KeyCode.LeftShift))
        {
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            isWalking = true;
        }
        else
        {
            isWalking = false;
        }

        bool wallSliding = false;
        if (onWall && !grounded && GetComponent<Rigidbody2D>().velocity.y < 0)
        {
            wallSliding = true;

            if (GetComponent<Rigidbody2D>().velocity.y < -wallSlideSpeed)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, -wallSlideSpeed);
            }
        }

        //anim.SetBool("Grounded", grounded);

        if (Input.GetButtonDown("Jump") && grounded)
        {
            Jump();
        }

        if (Input.GetButtonDown("Jump") && !grounded && onWall)
        {
            WallJump();
        }

        /*
        if (Input.GetKeyDown(KeyCode.Space) && !doubleJumped && !grounded)
        {
            Jump();
            doubleJumped = true;
        }
        */

        //moveVelocity = 0f;

        if (Input.GetButton("Dash") || Input.GetKey(KeyCode.LeftShift))
        {
            moveVelocity = runSpeed * Input.GetAxisRaw("Horizontal");
        }
        else
        {
            moveVelocity = moveSpeed * Input.GetAxisRaw("Horizontal");
        }

        /*
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            if (Input.GetKey(KeyCode.LeftShift))
            {
                moveVelocity = runSpeed;

            }
            else
            {
                moveVelocity = moveSpeed;
            }
        }
        */

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            if (Input.GetKey(KeyCode.LeftShift))
            {
                moveVelocity = -runSpeed;
            }
            else
            {
                moveVelocity = -moveSpeed;
            }
        }

        if (knockbackCount <= 0)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);
        }
        else
        {
            if (knockFromRight)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(-knockback, knockback);
            }
            else
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(knockback, knockback);
            }
            knockbackCount -= Time.deltaTime;
        }

        //anim.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));

        // if player is moving right
        if (GetComponent<Rigidbody2D>().velocity.x > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            dirFacing = -1;
        }

        else if (GetComponent<Rigidbody2D>().velocity.x < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
            dirFacing = 1;
        }

        anim.SetBool("isWalking", isWalking);
        anim.SetBool("isRunning", isRunning);

        /*
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Instantiate(ninjaStar, firePoint.position, firePoint.rotation);
            shotDelayCounter = shotDelay;
        }

        if (Input.GetKey(KeyCode.Return))
        {
            shotDelayCounter -= Time.deltaTime;

            if (shotDelayCounter <= 0)
            {
                Instantiate(ninjaStar, firePoint.position, firePoint.rotation);
                shotDelayCounter = shotDelay;
            }
        }

        
        if (anim.GetBool("Sword"))
        {
            anim.SetBool("Sword", false);
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            anim.SetBool("Sword", true);

        }
        */
    }

    public void Jump()
    {
        Invoke("setHitGround", 0.1f);
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
        jumpSfx.Play();
    }

    public void WallJump()
    {
        Invoke("setHitGround", 0.1f);
        GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, jumpHeight);
        Instantiate(hitGroundParticleEffect, groundCheck.transform.position + new Vector3(0, 0.5f, 0), groundCheck.transform.rotation);
        wallJumpSfx.Play();
        //GetComponent<Rigidbody2D>().AddForce(new Vector2(4000 * dirFacing, 500));
        //dirFacing = dirFacing * -1;
    }

    public void setHitGround()
    {
        hitGround = false;
    }
}
