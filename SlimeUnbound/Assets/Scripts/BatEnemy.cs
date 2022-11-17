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

    // Start is called before the first frame update
    void Start()
    {
        batMesh = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        distanceFromPlayer = Vector3.Distance(bat.position, player.position);

        if(distanceFromPlayer > 40)
		{
            batMesh.ResetPath();
		}

		else
		{
            batMesh.SetDestination(player.position);
            transform.LookAt(player);
            transform.rotation *= Quaternion.FromToRotation(Vector3.left, Vector3.forward);
		}
    }
}
