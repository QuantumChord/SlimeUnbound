using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform teleport;
	public int area;

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			other.transform.position = teleport.transform.position;
			other.gameObject.GetComponent<PlayerScript>().domainArea = area;
		}
	}
}
