using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlimeScript : MonoBehaviour
{
	public Text pointText;
	public Text powerUpText;

	public GameObject player;

	public int powerStack;
	public int points;

	public float timer = 20f;

	void Start()
	{
        points = 0;
		powerStack = 0;
		pointText.text = "Score: 0";
		powerUpText.text = "Power: 0";
	}

	private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Collectibles")
		{
            points++;
            Destroy(other.gameObject);
        }

		if (other.gameObject.tag == "PowerBoost")
		{
			powerStack++;
			Destroy(other.gameObject);
		}
        
    }

	void Update()
	{
		pointText.text = "Score: " + points;
		powerUpText.text = "Power: " + (powerStack * 25);
		if (powerStack == 4)
		{
			timer -= Time.deltaTime;

			if (timer < 0)
			{
				powerStack = 0;
				timer = 20;
			}

			powerUpText.text = "Power: Full Charge";
		}
	}
}
