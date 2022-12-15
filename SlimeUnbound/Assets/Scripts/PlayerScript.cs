using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    public int boost;
    public int slimeType;

    public int health;

    public float speed = 8f;
    private float gravity = -9.81f;
    public float jumpHeight = 3f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    private Vector3 playerVelocity;

    public bool doubleJump = false;
    bool isGrounded;

    public float projectileSpeed = 20f;
    public GameObject projectile;
    public GameObject projectileZone;
    public Vector3 projectileOriginPosition;
    public float projSpeed = 500f;

    public bool puddleTrigger;
    public GameObject gooZone;
    public GameObject gooPuddle;

    // Update is called once per frame
    void Update()
    {
        isGrounded = controller.isGrounded;

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
            speed = 16f;
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

        if (puddleTrigger)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                speed = 10f;
            }

            else
            {
                speed = 5f;
            }
        }

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            doubleJump = true;
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        if(Input.GetButtonDown("Jump") && !isGrounded && doubleJump)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            doubleJump = false;
        }

        playerVelocity.y += gravity * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        Vector3 targetPosition = Camera.main.transform.TransformPoint(Vector3.forward * 500);
        Vector3 projectileOriginPosition = projectileZone.transform.position;
        Quaternion projectileRotation = Quaternion.LookRotation(targetPosition - projectileOriginPosition);
		

        if (Input.GetButtonDown("Fire1"))
        {
            GameObject slimeProj = Instantiate(projectile, projectileOriginPosition, projectileRotation);
            slimeProj.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, projSpeed));
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            DepositGooLoad();
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SlimePuddle"))
        {
            puddleTrigger = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("SlimePuddle"))
        {
            puddleTrigger = false;
        }
    }

	public void OnCollisionEnter(Collision collision)
	{
            if (collision.collider.CompareTag("SpiderEnemy"))
            {
                TakeDamage();
            }

            if (collision.collider.CompareTag("BatEnemy"))
            {
                TakeDamage();
            }
    }

    public void TakeDamage()
	{
        --health;
    }

	public void DepositGooLoad()
    {
        Instantiate(gooPuddle, gooZone.transform.position, gooPuddle.transform.rotation);
    }

    public void Death()
	{
        if (health == 0)
		{
            Destroy(gameObject);
		}
	}
}
