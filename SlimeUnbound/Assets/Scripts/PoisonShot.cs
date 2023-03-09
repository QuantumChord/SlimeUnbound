using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonShot : MonoBehaviour
{
	public int damage;

    // Update is called once per frame
    void Update()
    {
        
    }

	public void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Terrain"))
		{
            Destroy(gameObject);
		}

		if (other.CompareTag("Player"))
		{
			Destroy(gameObject);
		}
	}
}
