using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BatEnemy : MonoBehaviour
{
    public Transform player;
    protected NavMeshAgent batMesh;

    public double distanceFromPlayer;

    public bool batHit;
    public double hitTimer;

    public int health;

    public AudioSource batAudio;
    public AudioClip batSqueak;
    public float batSqueakTime;
    // Start is called before the first frame update
    void Start()
    {
        batMesh = GetComponent<NavMeshAgent>();
        batAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        distanceFromPlayer = Vector3.Distance(player.position, transform.position);
        batMesh.SetDestination(player.position);

        if (distanceFromPlayer > 20)
		{
            batMesh.isStopped = true;
		}

		else
		{
            if (batSqueakTime <= 0f)
            {
                batAudio.PlayOneShot(batSqueak, 0.75f);

                batSqueakTime = 6f;
            }

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

        batSqueakTime -= Time.deltaTime;
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
