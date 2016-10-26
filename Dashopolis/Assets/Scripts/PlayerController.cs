using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public int playerNumber; // player 1, player 2... (player 0 used for KB controls) 
    private string playerPrefix; // used to map inputs individually for each player 

    public float moveSpeed;
    public float runSpeed;
    private float moveVelocity;
    public float jumpHeight;
    public float wallSlideSpeed;
    public int dirFacing;
    bool isWalking;
    bool isRunning;
    bool isJumping;
    bool isWallJumping;
    bool isUsingSuperFlight;
    bool isUsingSuperSpeed;
    bool isUsingSuperTime;

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

    public GameObject deathParticles;
    public int superSkill; // 1: SuperSpeed 2: SuperFlight 3: SuperTime
    private int superSkillTimer;

    // Use this for initialization
    void Start()
    {
        if (playerNumber == 0)
        {
            playerPrefix = "KB_";
        }
        else
        {
            playerPrefix = "P" + playerNumber + "_";
        }
        isWalking = false;
        isRunning = false;
        isJumping = false;
        isWallJumping = false;
        isUsingSuperFlight = false;
        isUsingSuperSpeed = false;
        isUsingSuperTime = false;
        superSkillTimer = 0;

        AudioSource[] audios = GetComponents<AudioSource>();
        groundedSfx = audios[0];
        jumpSfx = audios[1];
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

        if (Input.GetButton(playerPrefix + "Dash"))
        {
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }
        if (Input.GetAxisRaw(playerPrefix + "Horizontal") != 0)
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

        if (Input.GetButtonDown(playerPrefix + "Jump") && grounded)
        {
            isJumping = true;
            Jump();
        }
        else
            isJumping = false;

        if (Input.GetButtonDown(playerPrefix + "Jump") && !grounded && onWall)
        {
            isWallJumping = true;
            WallJump();
        }
        else
            isWallJumping = false;

        anim.SetBool("isJumping", isJumping);
        anim.SetBool("isWallJumping", isWallJumping);

        /*
        if (Input.GetKeyDown(KeyCode.Space) && !doubleJumped && !grounded)
        {
            Jump();
            doubleJumped = true;
        }
        */

        //moveVelocity = 0f;

        if (Input.GetButton(playerPrefix + "Dash"))
        {
            moveVelocity = runSpeed * Input.GetAxisRaw(playerPrefix + "Horizontal");
        }
        else
        {
            moveVelocity = moveSpeed * Input.GetAxisRaw(playerPrefix + "Horizontal");
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

        /*
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
        */

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

    public void Die()
    {
        // Add particles effect
        Instantiate(deathParticles, transform.position, transform.rotation);
        
        // Make the gameObject disappear without killing it
        gameObject.SetActive(false);

        /*SpriteRenderer sprite_renderer = (SpriteRenderer) gameObject.GetComponentInChildren<SpriteRenderer>();
        sprite_renderer.enabled = false;*/
    }

    public void Respawn()
    {
       /* SpriteRenderer spriteRenderer = (SpriteRenderer) gameObject.GetComponentInChildren<SpriteRenderer>();
        spriteRenderer.enabled = true;*/

        // Reactivate the gameObject
        gameObject.SetActive(true);

        // Add a trail to show the use of a super skill
        TrailRenderer trailRenderer = gameObject.GetComponentInChildren<TrailRenderer>();
        trailRenderer.enabled = true;
    }

    public void SuperSpeed()
    {
        // Add a trail to show the use of a super skill
        TrailRenderer trailRenderer = gameObject.GetComponentInChildren<TrailRenderer>();
        trailRenderer.enabled = true;

        // Give speed boost
        moveSpeed *= 5;
    }

    public void SuperFlight()
    {
        // Add a trail to show the use of a super skill
        TrailRenderer trailRenderer = gameObject.GetComponentInChildren<TrailRenderer>();
        trailRenderer.enabled = true;

        // Remove gravity
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 0.0f;
    }

    public void SuperTime()
    {
        // Next iteration
    }

    // Manage the Super Skills
    public void EnableSuperSkill()
    {
        // Super Speed
        if (superSkill == 1)
        {
            isUsingSuperSpeed = true;
            SuperSpeed();
        }
        else
            isUsingSuperSpeed = false;

        // Super Flight
        if (superSkill == 2)
        {
            DisableOtherMoves();
            isUsingSuperFlight = true;

            SuperFlight();
        }
        else
            isUsingSuperFlight = false;

        // Super Time?? Next iteration
        if (superSkill == 3)
        {
            isUsingSuperTime = true;
            SuperTime();
        }
        else
            isUsingSuperTime = false;

        anim.SetBool("isUsingSuperSpeed", isUsingSuperSpeed);
        anim.SetBool("isUsingSuperFlight", isUsingSuperFlight);
        anim.SetBool("isUsingSuperTime", isUsingSuperTime);
    }


    public void DisableOtherMoves()
    {
        // Disable other animations
        isWalking = false;
        isRunning = false;
        isJumping = false;
        isWallJumping = false;
        isUsingSuperFlight = true;

        anim.SetBool("isWalking", isWalking);
        anim.SetBool("isRunning", isRunning);
        anim.SetBool("isJumping", isJumping);
        anim.SetBool("isWallJumping", isWallJumping);

    }
}
