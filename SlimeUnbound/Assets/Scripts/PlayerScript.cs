using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    public int boost;
    public int slimeType;

    public float speed = 8f;
    public float gravity = 9.81f;
    public float jumpHeight = 3f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public bool doubleJump = false;

    Vector3 velocity;
    bool isGrounded;

	// Update is called once per frame
	void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(x, 0f, z).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity,turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDirection.normalized * speed * Time.deltaTime);
        }

        boost = GetComponent<SlimeScript>().powerStack;
        slimeType = GetComponent<SlimeScript>().slimePower;

        if (Input.GetKey(KeyCode.LeftShift) && boost <100)
        {
            speed = 12f *2;
        }
        else if(boost >= 100 && slimeType == 1)
        {

            if (Input.GetKey(KeyCode.LeftShift))
			{
                speed = 24f;
            }
			else
			{
                speed = 20f;
			}

        }
        else if (boost >= 100 && slimeType == 2)
        {
            jumpHeight = 3f * 2;

            if (Input.GetKey(KeyCode.LeftShift))
            {
                speed = 20f;
            }
            else
            {
                speed = 16f;
            }

        }
        else if (boost >= 100 && slimeType == 3)
        {
            jumpHeight = 3f * 3;

            if (Input.GetKey(KeyCode.LeftShift))
            {
                speed = 8f;
            }
            else
            {
                speed = 6f;
            }

        }
        else
        {
            jumpHeight = 3f;
            speed = 8f;
        }
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            doubleJump = true;
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        if(Input.GetButtonDown("Jump") && !isGrounded && doubleJump)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            doubleJump = false;
        }
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
