using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController characterController;
    public Transform cam;

    public float speed = 6f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    public Animator anim;

    // Update is called once per frame
    void Update()
    {
        // Reset velocity if player is grounded
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // Basic 3D Movement
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        
        // Make the player face the camera and move in the camera direction
        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            characterController.Move(moveDir.normalized * speed * Time.deltaTime);
        }
        // Jumping physics
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            //Start animation
            anim.SetBool("jump", true);
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            //Stop animation after 1s
            Invoke("StopJump", 1f);
            
        }

        // Basic gravity force
        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }

    private void Start()
    {
        // Locks the mouse to the game window
        Cursor.lockState = CursorLockMode.Locked;
    }
    // We use this to stop the jumping state
    private void StopJump()
    {
        anim.SetBool("jump", false);
    }
}


