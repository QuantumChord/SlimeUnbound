using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MovingPlat : MonoBehaviour
{
    [SerializeField] GameObject[] waypoints;
    public int waypointIndex = 0;

    [SerializeField] float moveSpeed = 6f;

	// Update is called once per frame
	void Update()
    {
        if(Vector3.Distance(transform.position, waypoints[waypointIndex].transform.position) < .1f)
		{
            waypointIndex++;
            if(waypointIndex >= waypoints.Length)
			{
                waypointIndex = 0;
			}
		}
        transform.position = Vector3.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, moveSpeed * Time.deltaTime);

    }
}
