using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpiderEnemy : MonoBehaviour
{
    public Transform player;
    public Transform spider;
    protected NavMeshAgent spiderMesh;

    public Transform venomSpot;
    public GameObject venomShot;
    private float fireCountdown = 0f;
    private float fireRate = 2f;
    public bool inRangeFire;

    public int health;

    public double distanceFromPlayer;
    // Start is called before the first frame update
    void Start()
    {
        spiderMesh = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        distanceFromPlayer = Vector3.Distance(spider.position, player.position);
        spiderMesh.SetDestination(player.position);

        if (distanceFromPlayer > 40)
        {
            spiderMesh.isStopped = true;
            inRangeFire = false;
        }

        else if(distanceFromPlayer <40 && distanceFromPlayer > 20)
        {
            spiderMesh.isStopped = true;
            inRangeFire = true;

        }

        else
        {
            spiderMesh.isStopped = false;
            transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));
            inRangeFire = false;
        }

        if(health == 0)
		{
            Death();
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
