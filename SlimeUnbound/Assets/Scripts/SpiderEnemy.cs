using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpiderEnemy : MonoBehaviour
{
    public Transform player;
    protected NavMeshAgent spiderMesh;

    public Transform venomSpot;
    public GameObject venomShot;
    private float fireCountdown = 0f;
    private float fireRate = 2f;
    public bool inRangeFire;

    public int health;

    public float distanceFromPlayer;

    public float gooSpeed = 2.5f;
    public bool gooingTrigger;
    // Start is called before the first frame update
    void Start()
    {
        spiderMesh = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        distanceFromPlayer = Vector3.Distance(player.position, transform.position);
        spiderMesh.SetDestination(player.position);

        if (distanceFromPlayer >= 45)
        {
            spiderMesh.isStopped = true;
            inRangeFire = false;
        }

        else if(distanceFromPlayer<45 && distanceFromPlayer >= 35)
		{
			spiderMesh.isStopped = false;
            transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));
            inRangeFire = false;
		}

        else if(distanceFromPlayer <35 && distanceFromPlayer >= 20)
        {
            spiderMesh.isStopped = false;
            transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));
            inRangeFire = true;

        }

        else
        {
            spiderMesh.isStopped = true;
            transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));
            inRangeFire = true;
        }

        if(health == 0)
		{
            Death();
		}

        if(inRangeFire == true)
		{
            if(fireCountdown <= 0)
			{
                GameObject venom = Instantiate(venomShot, venomSpot.position, transform.rotation);
                venom.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * (100f * distanceFromPlayer));
                fireCountdown = 6f / fireRate;
			}
            fireCountdown -= Time.deltaTime;
		}

        if(gooingTrigger == true)
        {
            spiderMesh.speed = gooSpeed;
        }

        else
        {
            spiderMesh.speed = 3.5f;
        }
    }
    public void Damage(int damageAmount)
    {
        health -= damageAmount;
    }

    public void Death()
	{
        Destroy(gameObject);
	}
}
