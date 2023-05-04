using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerScript : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    public int boost;
    public int slimeType;

    public int health;
    public Text healthText;

    public bool contact;
    public float contactBySecond = 5f;
    public int contactDamage = 1;

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
    public GameObject[] projType;
    public float shootCountDown = 0f;
    public float shootRate = 2f;

    //public bool puddleTrigger;
    //public GameObject gooZone;
    //public GameObject gooPuddle;
    //public int gooAmount;

    public Material[] slimeMat;
    public GameObject slimeBody;

    public AudioSource slimeAudio;
    public AudioClip slimeJump;
    public AudioClip lavaShoot;
    public AudioClip slimeShoot;
    public int domainArea;

    void Start()
    {
        slimeAudio = GetComponent<AudioSource>();
        projectile = projType[3];
        slimeBody.GetComponent<Renderer>().material = slimeMat[3];
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = "Health: " + health;
        //This section controls movement and the camera controls
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

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            doubleJump = true;
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            slimeAudio.PlayOneShot(slimeJump, 1f);
        }

        if(Input.GetButtonDown("Jump") && !isGrounded && doubleJump)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            doubleJump = false;
            slimeAudio.PlayOneShot(slimeJump, 1f);
        }

        playerVelocity.y += gravity * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);


        if (boost >= 100 && slimeType == 1)
        {
            slimeBody.GetComponent<Renderer>().material = slimeMat[0];
        }

        else if (boost >= 100 && slimeType == 2)
        {
            slimeBody.GetComponent<Renderer>().material = slimeMat[1];
        }

        else if (boost >= 100 && slimeType == 3)
        {
            slimeBody.GetComponent<Renderer>().material = slimeMat[2];
        }

        else
        {
            slimeBody.GetComponent<Renderer>().material = slimeMat[3];
        }

        //This section controls the bullet firing system
        Vector3 targetPosition = cam.transform.TransformPoint(Vector3.forward * 500);
        Vector3 projectileOriginPosition = projectileZone.transform.position;
        Quaternion projectileRotation = Quaternion.LookRotation(targetPosition - projectileOriginPosition);
		

        if (Input.GetButtonDown("Fire1") && shootCountDown <= 0f)
        {
            GameObject slimeProj = Instantiate(projectile, projectileOriginPosition, projectileRotation);
            slimeProj.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, projSpeed));
            if(slimeType == 1)
			{
                slimeAudio.PlayOneShot(lavaShoot, 1f);
            }

			else
			{
                slimeAudio.PlayOneShot(slimeShoot, 1f);
            }
            shootCountDown = 6f / shootRate;
        }
        shootCountDown -= Time.deltaTime;

        if(shootCountDown < 0)
		{
            shootCountDown = 0;
		}

        //This section allows for bullet changing during elemental change
        if (boost>=100 && slimeType == 1)
        {
            projectile = projType[0];
        }

        else if(boost>=100 && slimeType == 2)
        {
            projectile = projType[1];
        }

        else if(boost>=100 && slimeType == 3)
        {
            projectile = projType[2];
        }

        else
        {
            projectile = projType[3];
        } 

        //This section allows the goo to be shot using the Q key
        /*if (Input.GetKeyDown(KeyCode.Q) && gooAmount >0)
        {
            DepositGooLoad();
        }*/

        if(contact == true)
		{
            if(contactBySecond > 0)
			{
                contactBySecond -= Time.deltaTime;
			}

			else
			{
                contact = false;
                contactBySecond = 5f;
			}
		}

		else
		{
            contactBySecond = 5f;
		}

        if(contactBySecond < 0)
		{
            contactBySecond = 0;
		}

        if(health <= 0)
		{
            Death();
		}
    }

    //This changes how it reacts with slime puddles it leaves
    /*public void OnTriggerEnter(Collider other)
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
    }*/

	public void OnControllerColliderHit(ControllerColliderHit hit)
	{
        if (hit.collider.CompareTag("SpiderEnemy")&& !contact && contactBySecond == 5f)
        {
            contact = true;
            health-= contactDamage;
            Debug.Log("SpiderHit");
        }

        if (hit.collider.CompareTag("BatEnemy") && !contact && contactBySecond == 5f)
        {
            contact = true;
            health -= contactDamage;
            Debug.Log("BatHit");
        }
        if (hit.collider.CompareTag("PlantEnemy") && !contact && contactBySecond == 5f)
        {
            contact = true;
            health -= contactDamage;
            Debug.Log("PlantHit");
        }
    }
    //This allows the slime to deposit the slime puddle
	/*public void DepositGooLoad()
    {
        Instantiate(gooPuddle, gooZone.transform.position, gooPuddle.transform.rotation);
    }*/

    public void ProjDamage()
	{
        --health;
	}

    //This destroyes the slime
    public void Death()
	{
            Destroy(gameObject);
	}
}
