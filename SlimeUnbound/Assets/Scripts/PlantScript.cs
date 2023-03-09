using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlantScript : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float plantRange =20f;
    private float playerDistance;
    private NavMeshAgent navMeshAgent;

    public Transform poisonSpot;
    public GameObject poisonProj;
    private float fireCountdown = 0f;
    private float fireRate = 2f;

    public Transform[] tunnelArray;
    public int plantStatus;
    public float plantTime;
    public float plantInSeconds = 1f;
    public int plantIndex;
    //public int secondIndex;

    public int health;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = tunnelArray[0].transform.position;
        plantStatus = 0;

        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

        //Creates a tunneling system for the Plant based on time.
        plantTime += Time.deltaTime * plantInSeconds;

        if (plantStatus == 0 && plantTime >= 10)
        {
            PlantTunnel();
            plantTime = 0;
        }

        if(plantStatus==1 && plantTime < 5)
		{
            transform.position = tunnelArray[plantIndex].position + new Vector3(0, -10, 0);
        }

        if (plantStatus == 1 && plantTime >= 5)
		{
            PlantUntunnel();
            plantTime = 0;
		}

		if (plantStatus == 2 && plantTime >= .5)
        {
            plantStatus = 0;
            plantTime = 0;
		}

        //Sets distance from player for shooting or biting.
        playerDistance = Vector3.Distance(player.position, transform.position);

        if(playerDistance <= plantRange && plantStatus == 0)
        {
            transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));

            if (fireCountdown <= 0f)
            {
                GameObject poison = Instantiate(poisonProj, poisonSpot.position, transform.rotation);
                poison.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward*(100f *playerDistance));

                fireCountdown = 6f / fireRate;
            }
            fireCountdown -= Time.deltaTime;
        }

        if (health <= 0)
		{
            Destroy(gameObject);
		}
        
    }

	public void OnTriggerEnter(Collider other)
	{
        if (other.CompareTag("Projectile"))
		{
            int projDamage = other.GetComponent<SlimeProjectile>().fullDamage;
            health -= projDamage;
        }
	}

	//The "Tunnelling" section for the Plant. Plant burrows down, selects spot before coming up in later section.
	public void PlantTunnel()
	{
        plantIndex = Random.Range(0, 3);
        plantStatus = 1;

    }

    public void PlantUntunnel()
	{
        transform.position = tunnelArray[plantIndex].transform.position;
        plantStatus = 2;
    }
}
