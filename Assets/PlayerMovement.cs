
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed;
    public float jumpForce;
    public Transform GroundCheck;
    public Transform CeilingCheck;
    public LayerMask groundObjects;
    public float checkRadius;

    private Rigidbody2D rb;
    private bool facingRight = true;
    private float moveDirection;
    private bool isJumping = false;
    private bool isGrounded;
    // awake is called after all objects are initialized in a random order
    private Transform groundCheck;      // Ground check position
    public float groundCheckRadius = 0.2f; // Radius for checking ground

    private LayerMask groundLayer;      // Layer used to detect ground



    private void Start()
    {
        // Automatically get references to Rigidbody2D, groundCheck, and groundLayer
        rb = GetComponent<Rigidbody2D>();                  // Get the Rigidbody2D component of the player.
        groundCheck = transform.Find("GroundCheck");       // Find the ground check position (assumes a child object named "GroundCheck").
        groundLayer = LayerMask.GetMask("Ground");         // Set the ground layer (replace "Ground" with the actual layer name).

        rb.freezeRotation = true; // Lock the character's rotation.
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    private void Update()
    {
        // inputs
        ProcessInputs();

        // "animate"    
        animate();
        

    }


    private void FixedUpdate()
    {
       
            // Check if the player is grounded and handle jumping logic
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

            //Debug.Log("isGrounded=" + isGrounded);

            // move
            Move();
    }
    private void Move()
    {
        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);

    }

    private void ProcessInputs()
    {
        moveDirection = Input.GetAxis("Horizontal");
        if ((Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.Space)) )
        {
         
            if ( isGrounded)
            {
                isJumping = true;

                Jump();

                Debug.Log("isJumping=" + isJumping);
            }
      

        }

        //Debug.Log("isJumping=" + isJumping);
    }

    void Jump()
    {
        // Apply vertical force to jump
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);

        // Debug to check if the jump function is being called and the velocity is being set
        Debug.Log("Jump executed. Velocity: " + rb.velocity);
    }

    private void animate()
    {
        if (moveDirection > 0 && !facingRight)
        {
            FlipCharacter();

        }
        else if (moveDirection < 0 && facingRight)
        {
            FlipCharacter();
        }
    }

    private void FlipCharacter()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);



    }

}



