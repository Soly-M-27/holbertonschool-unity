using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private float TSTime = 0.1f;
    private float TSVelocity;
    public Transform Cam;
    public float jumpForce;
    Rigidbody rb;  

    private CharacterController characterController;

    // Force Player to come back down by applying gravity 
    // to the player each frame. Increase jump when button is pressed
    // and decrease as the player comes back down so double jump doesn't
    // take place
    private float ySpeed;
    
    // Private field to fix Player StepOffset. Set it to 0
    // when character is on the ground to avoid jerky jumping;
    private float originalStepOffset;
    private Vector3 v_movement, v_velocity;
    public GameObject player, tyPlayer;

    float H, V;

    public bool CollidedWithFlag = false;
    
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        player = GameObject.Find("Player");
        tyPlayer = GameObject.Find("tyPlayer");
        originalStepOffset = characterController.stepOffset;
        rb = GetComponent<Rigidbody>();
        //start_pos = new Vector3(0f, 50f, 0f);
        //anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {  
        PlayerMoves();
        Jumping();
        FallingOut();
        //I have no idea why the heck this doesn't work
        //Debug.Log(player.transform.position.y);
        
        //H = Input.GetAxis("Horizontal");
        //V = Input.GetAxis("Vertical");
        //v_movement = characterController.transform.forward * V * Time.deltaTime;
        //characterController.transform.Rotate(Vector3.up * H * (100f * Time.deltaTime));

        /*if (v_movement != Vector3.zero)
        {
            anim.SetBool("isRunning", false); 
        }
        else
        {
            anim.SetBool("isRunning", true);
        }*/

        //Vector3 moveDir = new Vector3(H, 0, V);
        /*if (moveDir.y <= -25)
        {
            player.transform.position = start_pos; //does not work
        }*/
        //Debug.Log("moveDir is: " + moveDir);
        /*float magnitude = Mathf.Clamp01(v_movement.magnitude) * speed;*/
        /*if (magnitude <= -25)
        {
            player.transform.position = start_pos; //does not work
        }*/
        //Debug.Log("magnitude is: " + magnitude);
        /*v_movement.Normalize();*/

        // Adjust the gravity. We're getting the physics gravity value
        // and adding this amount to our ySpeed every second.
        // Time.delatTime is the amount of seconds that have passed since the
        // last frame. By default the physics gravity value is set to
        // -9.81 in a Y direction. So this line will decrease our Y Speed
        // by 9.81 every second.
        /*ySpeed += Physics.gravity.y * Time.deltaTime;*/
        //Debug.Log("ySpeed is: " + ySpeed);

        /*if (ySpeed <= -25)
        {
            player.transform.position = start_pos; //does not work
        }*/
        
        // Freeze Cylinder in place to avoid floating rotations 
        /*rb.constraints = RigidbodyConstraints.FreezeRotation;*/

        // Now we need to use our ySpeed when moving the character. 
        // To do this we need to extract the calculation we pass into
        // the SimpleMove method and instead assign it to variable.
        /*Vector3 velocity = v_movement * magnitude;
        velocity.y = ySpeed;*/
        //Debug.Log("velocity is: " + velocity);
        //Debug.Log("velocity.y is: " + velocity.y);

        /*if (velocity.y <= -25)
        {
            player.transform.position = start_pos; //does not work
        }*/
        

        // SimpleMove is only for simple movement and ignores any
        // movement in the Y direction. Switch to Move Method.
        // You must multiply by Time.deltaTime to ensure the characeter
        // moves at the same speed regardless of the frame rate
        /*characterController.Move(velocity * Time.deltaTime);*/

        /*if (CollidedWithFlag == false)
        {
            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow)
            || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)
            || Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") 
            || Input.GetKey("d"))
            {
                this.GetComponent<Timer>().enabled = true;
                /*anim.SetBool("isRunning", true);*/
           /* }
            /*else
            {
                anim.SetBool("isRunning", false);
            }
        }*/

        /*if (characterController.isGrounded) // isGrounded is a Flag
        {
            // When character is not on the ground, set OG StepOffset
            characterController.stepOffset = originalStepOffset;

            // Set ySpeed back to a negative amount to stop it from 
            // increasing indefinitely. If set to zero, Jump button
            // will only work once.
            ySpeed = -0.5f;

            // Check if player is pressing the jump button
            if (Input.GetKey(KeyCode.Space))
            {
                ySpeed = jumpForce;
                /*if (ySpeed <= -25)
                {
                    player.transform.position = start_pos; //does not work
                }*/
               /* rb.constraints = RigidbodyConstraints.FreezeRotation;
            }
        }
        else
        {
            // Sets it to 0 when character is on the ground;
            characterController.stepOffset = 0;
        }

        if (transform.position.y < -25)
        {
            //this.GetComponent<Rigidbody>().isKinematic = true;
            transform.position = new Vector3(0, 25, 0);
            //Debug.Log("We are falling");
        }*/

        /*if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow)
            || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)
            || Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") 
            || Input.GetKey("d"))
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }*/
    }

    void PlayerMoves()
    {
        H = Input.GetAxis("Horizontal");
        V = Input.GetAxis("Vertical");
        
        float magnitude = Mathf.Clamp01(v_movement.magnitude) * speed;

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow)
            || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)
            || Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s")
            || Input.GetKey("d"))
            {
                anim.SetBool("isRunning", true);
                anim.SetBool("isIdle", false);
            }
            else
            {
                anim.SetBool("isRunning", false);
            }

            v_movement = new Vector3(H, 0, V).normalized;

            if(v_movement.magnitude >= 0.1f)
            {
                float MainAngle = Mathf.Atan2(v_movement.x, v_movement.z) * Mathf.Rad2Deg + Cam.eulerAngles.y;
                float Agl = Mathf.SmoothDampAngle(transform.eulerAngles.y, MainAngle, ref TSVelocity, TSTime);
                transform.rotation = Quaternion.Euler(0f, Agl, 0f);

                Vector3 mDir = Quaternion.Euler(0f, MainAngle, 0f) * Vector3.forward;
                characterController.Move(mDir.normalized * speed * Time.deltaTime);
            }
            rb.constraints = RigidbodyConstraints.FreezeRotation;
    }

    void FallingOut()
    {
        if (transform.position.y <= -25)
        {
            anim.SetBool("isFalling", true);
            transform.position = new Vector3(0, 35, 0);
        }
        
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }

    void Jumping()
    {
        if (characterController.isGrounded)
        {
            anim.SetBool("isFalling", false);
            anim.SetBool("isGrounded", true);
            v_velocity.y = -9.81f * Time.deltaTime;
            rb.constraints = RigidbodyConstraints.FreezeRotation;
        }
        if (Input.GetKey(KeyCode.Space) && characterController.isGrounded)
        {
            anim.SetTrigger("Jump");
            anim.SetBool("isGrounded", false);
            v_velocity.y += Mathf.Sqrt(jumpForce * -1f * -9.81f);
            rb.constraints = RigidbodyConstraints.FreezeRotation;
        }

        v_velocity.y += -9.81f * Time.deltaTime;
        characterController.Move(v_velocity * Time.deltaTime);

        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }
}