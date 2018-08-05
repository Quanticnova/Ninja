using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   // player walk and jump
    public float walkSpeed = 1.0f; float startWalkSpeed;
    public float runSpeed = 5.0f;
    public float jumpForce = 10.0f;

    string vertAxis, horAxis;

    bool isGrounded;

    public GameObject player;
    [SerializeField]
    private Rigidbody playerRb;

    private GameObject[] menus;

    public GameObject Trail;
    public float trailtime;

    private void Walk()
    {
        float translation = Input.GetAxis(vertAxis) * walkSpeed;
        float strafe = Input.GetAxis(horAxis) * walkSpeed;

        translation *= Time.deltaTime;
        strafe *= Time.deltaTime;

        player.transform.Translate(strafe, 0, translation);
        trailtime += Time.deltaTime;
        if (trailtime >= 0.75)
        {
            Instantiate(Trail, gameObject.transform.position, Quaternion.identity);
            trailtime = 0;
        }
    }

    void PlayerWalk()
    {
        if (player.name == "Player 1(Clone)")
        {
            vertAxis = "Player1Vertical";
            horAxis = "Player1Horizontal";
        }
        else if (player.name == "Player 2(Clone)")
        {
            vertAxis = "Player2Vertical";
            horAxis = "Player2Horizontal";
        }
        else if (player.name == "Player 3(Clone)")
        {
            vertAxis = "Player3Vertical";
            horAxis = "Player3Horizontal";
        }
        else if (player.name == "Player 4(Clone)")
        {
            vertAxis = "Player4Vertical";
            horAxis = "Player4Horizontal";
        }
        Walk();
    }


    void PlayerRun()
    {
        if (player.name == "Player 1(Clone)")
        {
            if (Input.GetKey(KeyCode.Joystick1Button6))
            {
                walkSpeed = runSpeed;
            }
        }
        else if (player.name == "Player 2(Clone)")
        {
            if (Input.GetKey(KeyCode.Joystick2Button6))
            {
                walkSpeed = runSpeed;
            }
        }
        else if (player.name == "Player 3(Clone)")
        {
            if (Input.GetKey(KeyCode.Joystick3Button6))
            {
                walkSpeed = runSpeed;
            }
        }
        else if (player.name == "Player 4(Clone)")
        {
            if (Input.GetKey(KeyCode.Joystick4Button6))
            {
                walkSpeed = runSpeed;
            }
        }
    }

    private void Jump()
    {
        if (isGrounded)
        {
            playerRb.AddForce(new Vector3(0.00f, jumpForce, 0.00f), ForceMode.Impulse);
        }
    }

    void PlayerJump()
    {
        if (player.name == "Player 1(Clone)")
        {
            if (Input.GetKey(KeyCode.Joystick1Button1))
            {
                Jump();
            }
        }
        else if (player.name == "Player 2(Clone)")
        {
            if (Input.GetKey(KeyCode.Joystick2Button1))
            {
                Jump();
            }
        }
        else if (player.name == "Player 3(Clone)")
        {
            if (Input.GetKey(KeyCode.Joystick3Button1))
            {
                Jump();
            }
        }
        else if (player.name == "Player 4(Clone)")
        {
            if (Input.GetKey(KeyCode.Joystick4Button1))
            {
                Jump();
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

        // player = GameObject.FindGameObjectWithTag("Player");
        playerRb = GetComponent<Rigidbody>();
        //playerRb = player.GetComponent<Rigidbody>();
        menus = GameObject.FindGameObjectsWithTag("playerSelect");
    }

    private void Update()
    {

        for (int i = 0; i < menus.Length; i++)
        {
            if (!menus[i].activeInHierarchy)     // make sure player moves when menus are closed
            {
                PlayerWalk();
                PlayerJump();
                PlayerRun();
            }
        }

    }
}