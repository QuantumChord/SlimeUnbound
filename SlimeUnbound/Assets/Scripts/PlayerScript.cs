using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public CharacterController controller;
    public int boost;
    public int slimeType;

    public float speed = 12f;
    public float gravity = 9.81f;
    public float jumpHeight = 3f;

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
                speed = 12f * 4;
            }
			else
			{
                speed = 12f * 3;
			}

        }
        else if (boost >= 100 && slimeType == 2)
        {
            jumpHeight = 3f * 2;

            if (Input.GetKey(KeyCode.LeftShift))
            {
                speed = 12f * 3;
            }
            else
            {
                speed = 12f *2;
            }

        }
        else if (boost >= 100 && slimeType == 3)
        {
            jumpHeight = 3f * 3;

            if (Input.GetKey(KeyCode.LeftShift))
            {
                speed = 12f;
            }
            else
            {
                speed = 8f;
            }

        }
        else
        {
            jumpHeight = 3f;
            speed = 12f;
        }

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

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
