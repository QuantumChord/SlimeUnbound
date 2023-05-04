using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonShot : MonoBehaviour
{

	public void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Terrain"))
		{
            Destroy(gameObject);
		}

		if (other.CompareTag("Player"))
		{
			other.gameObject.GetComponent<PlayerScript>().ProjDamage();

			Destroy(gameObject);
		}
	}
}
