using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BatEnemy : MonoBehaviour
{
    public Transform player;
    public Transform bat;
    protected NavMeshAgent batMesh;

    public double distanceFromPlayer;

    public bool batHit;
    public double hitTimer;

    public int health;
    // Start is called before the first frame update
    void Start()
    {
        batMesh = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

        distanceFromPlayer = Vector3.Distance(bat.position, player.position);
        batMesh.SetDestination(player.position);

        if (distanceFromPlayer > 40)
		{
            batMesh.isStopped = true;
		}

		else
		{
            batMesh.isStopped = false;
            transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));
        }

        if(batHit == true && hitTimer >0)
		{
            batMesh.SetDestination(-player.position);
            hitTimer -= Time.deltaTime;
        }

        if(hitTimer <= 0)
		{
            batHit = false;
            hitTimer = 0;
		}

        if (health == 0)
		{
            Death();
		}
    }

	public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
		{
            hitTimer = 5;
            batHit = true;
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
