using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public int playerNumber; // player 1, player 2... (player 0 used for KB controls) 
    private string playerPrefix; // used to map inputs individually for each player 
    public bool timeFreezeActivated;

    public GameObject checkpoints;

    public float moveSpeed;
    public float runSpeed;
    private float moveVelocityH;
    private float moveVelocityV;
    public float jumpHeight;
    public float wallSlideSpeed;
    public int dirFacing;
    bool isVisible;
    bool isWalking;
    bool isRunning;
    bool isJumping;
    bool isWallJumping;
    bool isGrounded;
    bool isFalling;
    bool isUsingSkill;
    bool isUsingSuperFlight;
    bool isUsingSuperSpeed;
    bool isUsingSuperTime;
    bool startSuperSkill;
    
    public Transform groundCheck;
    public float groundCheckRadius;
    public Transform leftWallCheck;
    public Transform rightWallCheck;
    public float wallCheckRadius;
    public LayerMask whatIsGround;
    public LayerMask whatIsSand;
    private int Power;
    private int ReqPower;
    private int superSkillDuration;

    private HUDManager hud;

    private bool onWall;

    //private bool doubleJumped;

    public Animator anim;
    AudioSource jumpSfx;
    AudioSource groundedSfx;
    AudioSource wallJumpSfx;
    AudioSource powerupSfx;
    AudioSource deathSfx;
    bool hitGround;
    public GameObject hitGroundParticleEffect;
    private float oriGravityScale;

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
    private float superSkillStartTime;
    private int superSkillCtr;
    private float superSpeedBoost;

    private bool offScreen;
    public bool onRope;
    public float climbSpeed;
    private float climbVelocity;
    private bool onSand;
    public GameObject sandFx;

    private bool isRespawning;

    // Use this for initialization
    void Start()
    {
        hud = GameObject.Find("HUD").GetComponentInChildren<HUDManager>();

        if (playerNumber == 0)
        {
			superSkill = PlayerPrefs.GetInt ("P1 Ability");
            playerPrefix = "KB_";
        }
        else
        {
			superSkill = PlayerPrefs.GetInt ("P2 Ability");
            playerPrefix = "P" + playerNumber + "_";
        }
        isVisible = true;
        isWalking = false;
        isRunning = false;
        isJumping = false;
        isWallJumping = false;
        isUsingSuperFlight = false;
        isUsingSuperSpeed = false;
        isUsingSuperTime = false;
        superSkillStartTime = -1;
        startSuperSkill = false;
        oriGravityScale = gameObject.GetComponent<Rigidbody2D>().gravityScale;
        timeFreezeActivated = false;

        AudioSource[] audios = GetComponents<AudioSource>();
        groundedSfx = audios[0];
        jumpSfx = audios[1];
        wallJumpSfx = audios[2];
        powerupSfx = audios[3];
        deathSfx = audios[4];
        hitGround = true;
        //anim = GetComponent<Animator>();
        ReqPower = 10;
        superSpeedBoost = 2.0f;
        superSkillCtr = 0;
        if (superSkill != 3)
        {
            superSkillDuration = 5;
        }
        else
        {
            superSkillDuration = 3;
        }
			 

        Debug.Log("P1 Ability: " + PlayerPrefs.GetInt("P1 Ability"));
		Debug.Log("P2 Ability: " + PlayerPrefs.GetInt("P2 Ability"));

        offScreen = false;
        onRope = false;
        onSand = false;
        isRespawning = false;
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround) || Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsSand);
        onSand = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsSand);
        if (isGrounded && isRespawning)
        {
            isRespawning = false;
            anim.SetBool("isRespawning", false);
        }
        /*   anim.SetBool("isGrounded", isGrounded);*/

        if (onSand)
            sandFx.GetComponent<ParticleSystem>().Play();
        else
            sandFx.GetComponent<ParticleSystem>().Stop();

        if (!isGrounded)
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
		//Debug.Log("onRope is = " + onRope);
        if (onRope)
        {
            GetComponent<Rigidbody2D>().gravityScale = 0;
            if (Input.GetButton(playerPrefix + "Dash"))
            {
                climbVelocity = runSpeed * Input.GetAxisRaw(playerPrefix + "Vertical");
            }
            else
            {
                climbVelocity = climbSpeed * Input.GetAxisRaw(playerPrefix + "Vertical");
            }
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, climbVelocity);
        }
        else
        {
            GetComponent<Rigidbody2D>().gravityScale = oriGravityScale;
        }

        Vector3 screenPoint = Camera.main.WorldToViewportPoint(transform.position);
        bool onScreen = screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;
        if (!onScreen && !Camera.main.GetComponent<CameraController>().singlePlayer)
        {
            Debug.Log("Player " + playerNumber + " is out of bounds.");
            offScreen = true;
            Die();
        }
        if (isVisible && !timeFreezeActivated)
        {
            /*
            if (grounded)
               {
                    doubleJumped = false;
                }
            */

            if (!isGrounded)
            {
                //Invoke("setHitGround", 0.1f);
                hitGround = false;
            }

            else
            {
                isFalling = false;
            }


            if (isGrounded && !hitGround)
            {
                groundedSfx.Play();
                Instantiate(hitGroundParticleEffect, groundCheck.transform.position + new Vector3(0, 0.2f, 0), groundCheck.transform.rotation);
                hitGround = true;
            }

            if (Input.GetAxisRaw(playerPrefix + "Horizontal") != 0)
            {
                isWalking = true;

            }
            else
            {
                isWalking = false;
            }
            if (Input.GetButton(playerPrefix + "Dash") && isWalking && !onSand)
            {
                isRunning = true;
                //isWalking = false;
            }
            else
            {
                isRunning = false;
            }

            //bool wallSliding = false;

            onWall = Physics2D.OverlapCircle(leftWallCheck.position, wallCheckRadius, whatIsGround) || Physics2D.OverlapCircle(rightWallCheck.position, wallCheckRadius, whatIsGround);
            /*
            if (onWall && !isGrounded && GetComponent<Rigidbody2D>().velocity.y < 0)
            {
                wallSliding = true;

                if (GetComponent<Rigidbody2D>().velocity.y < -wallSlideSpeed)
                {
                    GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, -wallSlideSpeed);
                }

                       anim.SetBool("isWallJumping", wallSliding);
            }
            */


            //anim.SetBool("Grounded", grounded);

            if (Input.GetButtonDown(playerPrefix + "Jump") && isGrounded && !onWall)
            {
                isJumping = true;
                isWallJumping = false;
                Jump();
                //JumpDisableOtherAnim();
            }
            else if (Input.GetButtonDown(playerPrefix + "Jump") /*&& !isGrounded*/ && onWall)
            {
                isWallJumping = true;
                isJumping = false;
                WallJump();
                //JumpDisableOtherAnim();
            }
            else
            {
                isJumping = false;
                isWallJumping = false;
            }


            if (GetComponent<Rigidbody2D>().velocity.y < 0)
            {
                isFalling = true;
            }


            /*
            if (Input.GetKeyDown(KeyCode.Space) && !doubleJumped && !isGrounded)
            {
                Jump();
                doubleJumped = true;
            }
            */

            //moveVelocity = 0f;

            //  Running: available in all cases, except for SuperFlight
            if (Input.GetButton(playerPrefix + "Dash") && !onSand /*&& !isUsingSuperFlight*/)
                moveVelocityH = runSpeed * Input.GetAxisRaw(playerPrefix + "Horizontal");
            // SuperSpeed min speed = runSpeed
            else if (!Input.GetButton(playerPrefix + "Dash") && isUsingSuperSpeed)
                moveVelocityH = runSpeed / superSpeedBoost * Input.GetAxisRaw(playerPrefix + "Horizontal");
            // Walking
            else
                moveVelocityH = moveSpeed * Input.GetAxisRaw(playerPrefix + "Horizontal");

            // Manage the Super Skills add-ons
            if (Input.GetButton(playerPrefix + "Skill") || startSuperSkill)
            {
                if (CheckSuperSkillConditions() || startSuperSkill)
                    EnableSuperSkill();
                //else
                //DisableSuperSkill();
            }

            if (startSuperSkill && !UpdateSuperSkill())
            {
                DisableSuperSkill();
            }

            if (knockbackCount <= 0)
            {
                if (!isUsingSuperFlight)
                    GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocityH, GetComponent<Rigidbody2D>().velocity.y);
                else
                    GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocityH, moveVelocityV);
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

            // Update all the animation parameters (booleans)
            SetAnimBool();
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
    }

    public void Jump()
    {
        Invoke("setHitGround", 0.1f);
     //   if (!isUsingSuperSpeed)
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
      /*  else
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight * superSpeedBoost * 1.5f);*/
        jumpSfx.Play();
    }

    public void WallJump()
    {
        Invoke("setHitGround", 0.1f);
        anim.SetTrigger("wallJump");
     //   if (!isUsingSuperSpeed)
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, jumpHeight);
     /*   else
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight * superSpeedBoost * 1.5f);*/
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
        if (isVisible)
        {
            deathSfx.Play();
            // Add particles effect
            Instantiate(deathParticles, transform.position, transform.rotation);

            // Make the gameObject disappear without killing it
            SpriteRenderer[] srs = gameObject.GetComponentsInChildren<SpriteRenderer>();

            foreach (SpriteRenderer sr in srs)
            {
                sr.enabled = false;
            }
            isVisible = false;
            //gameObject.SetActive(false);

            Invoke("Respawn", 2);

            /*SpriteRenderer sprite_renderer = (SpriteRenderer) gameObject.GetComponentInChildren<SpriteRenderer>();
            sprite_renderer.enabled = false;*/
        }
    }

    public void Respawn()
    {
        /* SpriteRenderer spriteRenderer = (SpriteRenderer) gameObject.GetComponentInChildren<SpriteRenderer>();
         spriteRenderer.enabled = true;*/
        Debug.Log("Player " + playerNumber + " Respawn");

        Transform[] cs = checkpoints.GetComponentsInChildren<Transform>();
        Transform activeCheckpoint = cs[0];

        if (!offScreen)
        {
            foreach (Transform t in cs)
            {
                if (t.position.x < gameObject.transform.position.x)
                {
                    //Debug.Log(checkpointIndex);
                    activeCheckpoint = t;
                    //checkpointIndex++;
                }
                else
                {
                    break;
                }
            }
        }
        else
        {
            // respawn at the leftmost checkpoint visible to the camera  
            double VerticalHeightSeen = Camera.main.orthographicSize * 2.0;
            double HorizontalWidthSeen = VerticalHeightSeen * Screen.width / Screen.height;

            Debug.Log("Vertical Height Seen: " + VerticalHeightSeen);
            Debug.Log("Horizontal Width Seen: " + HorizontalWidthSeen);

            double HalfWidth = HorizontalWidthSeen;
            foreach (Transform t in cs)
            {
                Vector3 screenPoint = Camera.main.WorldToViewportPoint(t.position);
                bool checkpointVisible = screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;
                if (checkpointVisible)
                {
                    activeCheckpoint = t;
                    break;
                }
            }
        }

        offScreen = false;

        gameObject.transform.position = new Vector2(activeCheckpoint.position.x, activeCheckpoint.position.y);

        // Reactivate the gameObject
        //gameObject.SetActive(true);
        SpriteRenderer[] srs = gameObject.GetComponentsInChildren<SpriteRenderer>();

        foreach (SpriteRenderer sr in srs)
        {
            sr.enabled = true;
        }
        isVisible = true;

        // Add a trail to show the use of a super skill
        /*
        TrailRenderer trailRenderer = gameObject.GetComponentInChildren<TrailRenderer>();
        trailRenderer.enabled = true;
        */

        isRespawning = true;
        anim.SetBool("isRespawning", true);
    }

    public void SuperSpeed()
    {
        // Add a trail to show the use of a super skill
        TrailRenderer trailRenderer = gameObject.GetComponentInChildren<TrailRenderer>();
        trailRenderer.enabled = true;

        // Give speed boost
        moveVelocityH = moveVelocityH * superSpeedBoost;
    }

    public void SuperFlight()
    {
        // Read Up and Down arrow input
        moveVelocityV = moveSpeed * Input.GetAxisRaw(playerPrefix + "Vertical") * 1.5f;

        // Add a trail to show the use of a super skill
        TrailRenderer trailRenderer = gameObject.GetComponentInChildren<TrailRenderer>();
        trailRenderer.enabled = true;

        // Remove gravity
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 0.0f;

    }

    public void SuperTime()
    {
        // Next iteration
		PteraMover.ActivateTimeFreeze();
        CaveFlamePit.ActivateTimeFreeze();
        Fireball.ActivateTimeFreeze();
        DestroyByTime.ActivateTimeFreeze();
        LaserBeam.ActivateTimeFreeze();
        Saw.ActivateTimeFreeze();
        LaserTurret.ActivateTimeFreeze();
        SwingingBoulder[] sb = FindObjectsOfType<SwingingBoulder>();
        sb[0].ActivateTimeFreeze();
        sb[1].ActivateTimeFreeze();
        RockController.ActivateTimeFreeze();
        Turret.ActivateTimeFreeze();
        PlayerController[] players = FindObjectsOfType<PlayerController>();
        foreach (PlayerController p in players)
        {
            if (p.playerNumber != playerNumber)
            {
                p.timeFreezeActivated = true;
                p.GetComponent<Rigidbody2D>().isKinematic = true;
                p.anim.enabled = false;
            }
        }
        GameObject[] FXs = GameObject.FindGameObjectsWithTag("FX");
        foreach (GameObject fx in FXs)
        {
            fx.GetComponent<ParticleSystem>().Pause();
        }
    }

    // Manage the Super Skills
    public void EnableSuperSkill()
    {
        if (!startSuperSkill)
        {
            startSuperSkill = true;
            superSkillStartTime = Time.time;
        }

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
            SuperFlightDisableOtherAnim();
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

    }

    public void DisableSuperSkill()
    {
        isUsingSuperFlight = false;
        isUsingSuperSpeed = false;
        isUsingSuperTime = false;

        // Remove the superskill trail
        TrailRenderer trailRenderer = gameObject.GetComponentInChildren<TrailRenderer>();
        trailRenderer.enabled = false;

        // Reset gravity to its orignal value
        gameObject.GetComponent<Rigidbody2D>().gravityScale = oriGravityScale;
		PteraMover.DeactivateTimeFreeze ();
        CaveFlamePit.DeactivateTimeFreeze();
        Fireball.DeactivateTimeFreeze();
        DestroyByTime.DeactivateTimeFreeze();
        LaserBeam.DeactivateTimeFreeze();
        Saw.DeactivateTimeFreeze();
        LaserTurret.DeactivateTimeFreeze();
        SwingingBoulder[] sb = FindObjectsOfType<SwingingBoulder>();
        sb[0].DeactivateTimeFreeze();
        sb[1].DeactivateTimeFreeze();
        RockController.DeactivateTimeFreeze();
        Turret.DeactivateTimeFreeze();
        PlayerController[] players = FindObjectsOfType<PlayerController>();
        foreach (PlayerController p in players)
        {
            p.timeFreezeActivated = false;
            p.GetComponent<Rigidbody2D>().isKinematic = false;
            p.anim.enabled = true;
        }
        GameObject[] FXs = GameObject.FindGameObjectsWithTag("FX");
        foreach (GameObject fx in FXs)
        {
            fx.GetComponent<ParticleSystem>().Play();
        }
    }

    public void SuperFlightDisableOtherAnim()
    {
        // Disable other animations
        isWalking = false;
        isRunning = false;
        isJumping = false;
        isWallJumping = false;
    }

    public void JumpDisableOtherAnim()
    {
        // Disable other animations
        isWalking = false;
        isRunning = false;
    }

    public void AddPower(int newpowervalue)
    {
        Power += newpowervalue;
        //Debug.Log("Player: " + playerNumber);
        //Debug.Log("Prefix: " + playerPrefix);
        powerupSfx.Play();

        if (playerNumber == 0)
        {
            hud.increasePlayerOne(newpowervalue);
        }
        else if (playerNumber == 1)
        {
            hud.increasePlayerTwo(newpowervalue);
        }

    }

    public void ResetPower()
    {
        // Reset Power Variable
        Power = 0;

        // Reset Power Bar in HUD
        if (playerNumber == 0)
        {
            hud.resetPlayerOne();
        }
        else if (playerNumber == 1)
        {
            hud.resetPlayerTwo();
        }
    }

    void SetAnimBool()
    {
        anim.SetBool("isGrounded", isGrounded);
        anim.SetBool("isFalling", isFalling);
        anim.SetBool("isWalking", isWalking);
        anim.SetBool("isRunning", isRunning);
        anim.SetBool("isJumping", isJumping);
        anim.SetBool("isWallJumping", isWallJumping);
        anim.SetBool("isUsingSuperFlight", isUsingSuperFlight);
        anim.SetBool("isUsingSuperSpeed", isUsingSuperSpeed);
		anim.SetBool("onRope", onRope);
    }

    bool CheckSuperSkillConditions()
    {
        // Case 1: player has collected the required number of orbs to enable SS
        if (!startSuperSkill && Power >= ReqPower)
        {
            startSuperSkill = true;
            superSkillStartTime = Time.time;
            superSkillCtr++;
            return true;
        }
        // Case 4: not enough orbs
        else
            return false;
    }

    bool UpdateSuperSkill()
    {
        // Case 2: SS is still enabled and has not reached the time limit
        if (startSuperSkill && Power >= ReqPower && Time.time <= superSkillStartTime + superSkillDuration)
        {
            DecreasePowerBar(Time.time);
            return true;
        }
        // Case 3: SS was enabled, but the player died or has reached the time limit
        //else (startSuperSkill && (Power == 0 || Time.time > superSkillStartTime + superSkillDuration))
        else 
        {
            startSuperSkill = false;
            superSkillStartTime = -1;
            superSkillCtr = 0;
            ResetPower();
            return false;
        }
    }

    void DecreasePowerBar(float currentTime)
    {
        float lowerBound = superSkillStartTime + superSkillCtr - 0.5f;
        float upperBound = superSkillStartTime + superSkillCtr + 0.5f;
        if (currentTime >= lowerBound && currentTime < upperBound)
        {
            if (playerNumber == 0)
            {
                hud.decreasePlayerOne(ReqPower / superSkillDuration);
            }
            else if (playerNumber == 1)
            {
                hud.decreasePlayerTwo(ReqPower / superSkillDuration);
            }

            superSkillCtr++;
        }
    } 
    /*
    void OnBecameInvisible() {
        Debug.Log("Player " + playerNumber + " is out of bounds.");
        offScreen = true;
        Die();
    }
    */
}