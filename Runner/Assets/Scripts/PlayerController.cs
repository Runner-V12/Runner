using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float runSpeed = 13f;
    [SerializeField] private float dash = 10f;
    [SerializeField] private float m_JumpForce = 400f;                          // Amount of force added when the player jumps.
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;  // How much to smooth out the movement
    [SerializeField] private bool m_AirControl = false;                         // Whether or not a player can steer while jumping;
    [SerializeField] private LayerMask m_WhatIsGround;                          // A mask determining what is ground to the character
    [SerializeField] private Transform m_GroundCheck;                           // A position marking where to check if the player is grounded.

    private float speed = 0f;
    private bool jump = false;
    private bool m_Grounded;            // Whether or not the player is grounded.
    private Rigidbody2D m_Rigidbody2D;
    private bool m_FacingRight = true;  // For determining which way the player is currently facing.
    private Vector3 m_Velocity = Vector3.zero;
    private Animator animator;

    private void Awake()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

	void Update()
    {
        animator.SetFloat("Speed", Mathf.Abs(speed));
    }

    // UpdateFixed is called once each fixed time (used for physics)
    private void FixedUpdate()
    {
        if (IsGround())  //This function use physics
        {
            m_Grounded = true;
            animator.SetBool("Jump", false);
        }
        else
        {
            m_Grounded = false;
            animator.SetBool("Jump", true);
        }
		this.Move(speed * Time.fixedDeltaTime, jump);
        jump = false;
    }

    private bool IsGround()
    {
        return Physics2D.Raycast(m_GroundCheck.transform.position, Vector2.down, 0.1f, m_WhatIsGround);
    }

    public void Move(float move, bool jump)
    {
        // If crouching, check to see if the character can stand up

        //only control the player if grounded or airControl is turned on
        if (m_Grounded || m_AirControl)
        {
            // Move the character by finding the target velocity
            Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);
            // And then smoothing it out and applying it to the character
            m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

            // If the input is moving the player right and the player is facing left...
            if (move > 0 && !m_FacingRight)
            {
                // ... flip the player.
                Flip();
            }
            // Otherwise if the input is moving the player left and the player is facing right...
            else if (move < 0 && m_FacingRight)
            {
                // ... flip the player.
                Flip();
            }
        }
        // If the player should jump...
        if (m_Grounded && jump)
        {
            m_Grounded = false;
            // Add a vertical force to the player.
            m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
        }
    }


    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

	public void idle()
    {
		Debug.Log("idle");
        speed = 0f;
    }

    public void goRight()
    {
        Debug.Log("right");
        if (speed <= 0)
        {
            speed = runSpeed;
        }
    }

    public void goLeft()
    {
        Debug.Log("left");
        if (speed >= 0)
        {
            speed = -runSpeed;
        }
    }

    public void Jump()
    {
		Debug.Log("Jump");
        jump = true;
    }
}