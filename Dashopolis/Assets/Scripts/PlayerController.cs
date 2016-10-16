using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;
    public float runSpeed;
    private float moveVelocity;
    public float jumpHeight;
    public float wallSlideSpeed;

    public Transform groundCheck;
    public float groundCheckRadius;
    public Transform leftWallCheck;
    public Transform rightWallCheck;
    public float wallCheckRadius;
    public LayerMask whatIsGround;
    private bool grounded;
    private bool onWall;


    //private bool doubleJumped;

    /*
    private Animator anim;

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
        //anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        if (!grounded)
        {
            onWall = Physics2D.OverlapCircle(leftWallCheck.position, wallCheckRadius, whatIsGround) || Physics2D.OverlapCircle(rightWallCheck.position, wallCheckRadius, whatIsGround);
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

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.Space) && !grounded && onWall)
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

        moveVelocity = 0f;

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
        }

        else if (GetComponent<Rigidbody2D>().velocity.x < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }

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
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
    }

    public void WallJump()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed * 10, jumpHeight);
    }
}
