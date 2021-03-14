using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerCharacterController : MonoBehaviour
{
    [SerializeField] LayerMask groundLayers;
    [SerializeField] float runSpeed = 20;
    [SerializeField] float jumpHeight = 2f;
    [SerializeField] float strafeSpeed = 1f;
    [SerializeField] Transform[] groundChecks;

    float gravity = -50f;
    CharacterController characterController;
    Vector3 velocity;
    bool isGrounded;
    float horizontalInput;
    float forwardInput = 1;

    bool jumpPressed;
    float jumpTimer;
    float jumpGracePeriod = 0.2f;

    bool gameStarted = false;


    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Check if grounded
        isGrounded = false;

        foreach (var groundCheck in groundChecks)
        {
            if (Physics.CheckSphere(groundCheck.position, 0.1f, groundLayers, QueryTriggerInteraction.Ignore))
            {
                isGrounded = true;
                break;
            }
        }


        if (isGrounded && velocity.y < 0)
        {
            velocity.y = 0;
        }
        else
        {
            //Add gravity
            velocity.y += gravity * Time.deltaTime;
        }


        //if (gameStarted)
        //{
        //    SideMovement();
        //    Jump();
        //    RunForward();
        //}

        SideMovement();
        Jump();
        RunForward();

        AssignGravity();

        StartGame();
    }

    private void Jump()
    {
        //Jump
        jumpPressed = Input.GetButtonDown("Jump");
        if (jumpPressed)
        {
            jumpTimer = Time.time;
        }

        if (isGrounded && (jumpPressed || (jumpTimer > 0 && Time.time < jumpTimer + jumpGracePeriod)))
        {
            velocity.y += Mathf.Sqrt(jumpHeight * -2 * gravity);
            jumpTimer = -1;
        }
    }

    void StartGame()
    {
        if (!gameStarted && Input.anyKeyDown)
        {
            gameStarted = true;
        }
    }

    void SideMovement()
    {
        if (isGrounded && Input.GetAxisRaw("Horizontal") != 0)
        {
            characterController.Move(new Vector3(Input.GetAxisRaw("Horizontal") * strafeSpeed * Time.deltaTime, 0, 0));
        }
    }

    void RunForward()
    {
        //Constant run
        characterController.Move(new Vector3(0, 0, forwardInput * runSpeed) * Time.deltaTime);
    }

    void AssignGravity()
    {
        //Vertical velocity
        characterController.Move(velocity * Time.deltaTime);
    }
}
