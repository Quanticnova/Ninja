using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   // player walk and jump
    public float walkSpeed = 1.0f; float startWalkSpeed;
    public float runSpeed = 5.0f;
    public float jumpForce = 10.0f;

    bool isGrounded;

    private GameObject player;
    private Rigidbody playerRb;

    private void Walk()
    {
        float translation = Input.GetAxis("VerticalJoy") * walkSpeed;
        float strafe = Input.GetAxis("HorizontalJoy") * walkSpeed;

        translation *= Time.deltaTime;
        strafe *= Time.deltaTime;

        player.transform.Translate(strafe, 0, translation);
    }

    private void Run()
    {
        if(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.JoystickButton6))    // L2
        {
            walkSpeed = runSpeed;
        }
        else
        {
            walkSpeed = startWalkSpeed;
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton1))   // X
        {
            if (isGrounded)
            {
                playerRb.AddForce(new Vector3(0.00f, jumpForce, 0.00f), ForceMode.Impulse);
            }
        }
    }

    // player can only jump once
    void OnCollisionStay(Collision collision)
    {
        isGrounded = true;
    }

    void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }

    private void Start()
    {
        startWalkSpeed = walkSpeed;

        player = GameObject.FindGameObjectWithTag("Player");
        playerRb = player.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Walk();
        Jump();
        Run();
    }
}