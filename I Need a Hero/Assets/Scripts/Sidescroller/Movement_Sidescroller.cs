using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_Sidescroller : MonoBehaviour
{
    public int playerSpeed = 10;
    public int playerJumpPower = 1250;

    public GameObject run, crouch;
    Rigidbody2D rb;


    bool start = false;

    bool running = true;

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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground") && currentState == playerStates.Jumping)
        {
            ReturnToRunning();
        }
    }


    void Jump()
    {
        rb.AddForce(Vector2.up * playerJumpPower, ForceMode2D.Impulse);
        running = false;
    }

    void Crouch()
    {
        //transform.rotation = Quaternion.Euler(0, 0, 90);
        run.SetActive(false);
        crouch.SetActive(true);
    }

    void Stand()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    void ReturnToRunning()
    {
        currentState = playerStates.Running;
        crouch.SetActive(false);
        run.SetActive(true);
    }

    void PlayerStates()
    {
        switch (currentState)
        {
            case playerStates.Running:
                if (CheckJumpInput())
                {
                    Jump();
                    currentState = playerStates.Jumping;
                }
                if (CheckCrouchInput())
                {
                    Crouch();
                    currentState = playerStates.Crouching;
                }
                break;
            case playerStates.Jumping:
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
    bool CheckCrouchInput()
    {
        if ((Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)))
            return true;
        return false;
    }
}
