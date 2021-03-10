using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_Sidescroller : MonoBehaviour
{
    public int playerSpeed = 10;
    public int playerJumpPower = 1250;
    public Animator animator;
    [SerializeField] Transform[] groundChecks;
    [SerializeField] LayerMask groundLayers;

    string crouching = "isSliding";
    string jumping = "isJumping";
    string isRunning = "isRunning";
    public GameObject run, crouch;
    Rigidbody2D rb;


    bool start = false;

    bool running = true;
    bool isGrounded;

    bool jumpPressed;
    float jumpTimer;
    float jumpGracePeriod = 0.2f;

    public enum playerStates
    {
        Running,
        Jumping,
        Crouching
    }

    playerStates currentState = playerStates.Running;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        isGrounded = false;
        foreach (var groundCheck in groundChecks)
        {
            //Debug.DrawRay(groundCheck.position, groundCheck.position, Color.red);
            //RaycastHit2D hits = Physics2D.CircleCast(groundCheck.position, 0.1f, -transform.up, 10f);
            //Debug.Log(hits.collider.tag);
            //if (Physics.CheckSphere(transform.position, 0.1f, groundLayers, QueryTriggerInteraction.Ignore))
            if (Physics2D.CircleCast(groundCheck.position, 0.1f, -transform.up, 0f, groundLayers.value))
            {
                isGrounded = true;
                break;
            }
        }

        SetAnimatorStates();

        if (start)
        {
            //PlayerMove();
            //ActivateDefaultSprite();
            PlayerStates();
        }

        StartGame();

    }

    private void FixedUpdate()
    {
        if (start)
        {
            rb.velocity = new Vector2(-playerSpeed, rb.velocity.y);
        }
    }

    private void StartGame()
    {
        if (!start && Input.GetKeyDown(KeyCode.Space))
        {
            start = true;
        }
    }

    void PlayerMove()
    {
        //CONTROLS
        if (running && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Z)))
        {
            Jump();
        }

        if (running && (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)))
        {
            Crouch();
        }
        else
        {
            Stand();
        }
        //ANIMATIONS
        //PLAYER DIRECTION
        //PHYSICS
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.collider.CompareTag("Ground") && currentState == playerStates.Jumping)
    //    {
    //        ReturnToRunning();
    //    }
    //}


    void Jump()
    {
        rb.AddForce(Vector2.up * playerJumpPower, ForceMode2D.Impulse);
        currentState = playerStates.Jumping;
    }

    void Crouch()
    {
        //transform.rotation = Quaternion.Euler(0, 0, 90);
        //run.SetActive(false);
        //crouch.SetActive(true);
        currentState = playerStates.Crouching;
    }

    void Stand()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    void ReturnToRunning()
    {
        currentState = playerStates.Running;
        //crouch.SetActive(false);
        //run.SetActive(true);
    }

    void PlayerStates()
    {
        switch (currentState)
        {
            case playerStates.Running:
                JumpInput();
                CrouchInput();
                break;
            case playerStates.Jumping:
                if (isGrounded)
                {
                    ReturnToRunning();
                }
                break;
            case playerStates.Crouching:
                if (!CheckCrouchInput())
                {
                    ReturnToRunning();
                }
                break;

        }

    }

    bool CheckJumpInput()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Z)))
            return true;
        return false;
    }

    void JumpInput()
    {
        jumpPressed = (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Z));
        if (jumpPressed)
        {
            jumpTimer = Time.time;
        }

        if (isGrounded && (jumpPressed || (jumpTimer > 0 && Time.time < jumpTimer + jumpGracePeriod)))
        {
            Jump();
            jumpTimer = -1;
        }
    }
    bool CheckCrouchInput()
    {
        if ((Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)))
            return true;
        return false;
    }

    void CrouchInput()
    {
        if ((Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)))
            Crouch();
    }

    void SetAnimatorStates()
    {
        if (currentState == playerStates.Crouching)
        {
            animator.SetBool(crouching, true);
            animator.SetBool(isRunning, false);
            animator.SetBool(jumping, false);
        }
        if (currentState == playerStates.Running)
        {
            animator.SetBool(crouching, false);
            animator.SetBool(isRunning, true);
            animator.SetBool(jumping, false);
        }
        if (currentState == playerStates.Jumping)
        {
            animator.SetBool(crouching, false);
            animator.SetBool(isRunning, false);
            animator.SetBool(jumping, true);
        }
    }
}
