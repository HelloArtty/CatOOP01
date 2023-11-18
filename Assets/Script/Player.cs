using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Player : MonoBehaviour
{

    Rigidbody2D rb;
    Animator animator;
    public Transform groundCheckCollider;
    public LayerMask groundLayer;

    const float groundCheckRadius = 0.2f;
    [SerializeField] float speed = 1;
    [SerializeField] float jumpPower = 150;
    float horizontalValue;
    float runSpeedModifier = 2f;

    [SerializeField] bool isGrounded;
    bool isRunning;
    bool facingRight = true;
    bool jump;

    public GameObject bound;
    //public CinemachineVirtualCamera vcam;
    CinemachineConfiner2D confiner2D;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        confiner2D = GetComponent<CinemachineConfiner2D>();
    }

    void Update()
    {
        horizontalValue = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.LeftShift))
            isRunning = true;
        
        if (Input.GetKeyUp(KeyCode.LeftShift))
            isRunning = false;

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("Jump", true);
        }
        else if (Input.GetButtonUp("Jump"))
            jump = false;

        animator.SetFloat("yVelocity", rb.velocity.y);
    }

    void FixedUpdate()
    {
        GetBound();
        GroundCheck();
        Move(horizontalValue, jump);
    }

    void GroundCheck()
    {
        bool wasGrounded = isGrounded;
        isGrounded = false;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckCollider.position, groundCheckRadius, groundLayer);
        if (colliders.Length > 0)
            isGrounded = true;

        animator.SetBool("Jump", !isGrounded);
    }

    void Move(float dir, bool jumpFlag)
    {
        #region Jump
        if(isGrounded && jumpFlag)
        {
            jumpFlag = false;
            //isGrounded = false;
            rb.AddForce(new Vector2(0f, jumpPower));
        }
        #endregion

        #region run & move
        float xVal = dir * speed * 100 * Time.deltaTime;

        if (isRunning)
            xVal *= runSpeedModifier;

        Vector2 targetVelocity = new Vector2(xVal, rb.velocity.y);
        rb.velocity = targetVelocity;

        if (facingRight && dir < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            facingRight = false;
        }
        else if (!facingRight && dir > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            facingRight = true;
        }

        animator.SetFloat("xVelocity", Mathf.Abs(rb.velocity.x));
        #endregion
    }

    private void GetBound()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up);
        if (hit.collider != null)
        {
            if (hit.collider.tag == "Bound")
            {
                bound = hit.collider.gameObject;

            }
        }
    }
}