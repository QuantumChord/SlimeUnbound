using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlimeScript : MonoBehaviour
{
	public Text pointText;
	public Text powerUpText;

	public int powerStack;
	public int points;
	public int slimePower;

	public float timer = 20f;

	void Start()
	{
        points = 0;
		powerStack = 0;
		slimePower = 0;
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
		if(other.gameObject.tag == "PowerBoost")
		{
			if (other.gameObject.GetComponent<PowerUp>().connectPow == 1 && (slimePower == 1 || slimePower == 0))
			{
				powerStack += PowerUp.slimeUpAmount;
				slimePower = 1;
				Destroy(other.gameObject);
			}
			else if (other.gameObject.GetComponent<PowerUp>().connectPow == 2 && (slimePower == 2 || slimePower == 0))
			{
				powerStack += PowerUp.slimeUpAmount;
				slimePower = 2;
				Destroy(other.gameObject);
			}

			else if (other.gameObject.GetComponent<PowerUp>().connectPow == 3 && (slimePower == 3 || slimePower == 0))
			{
				powerStack += PowerUp.slimeUpAmount;
				slimePower = 3;
				Destroy(other.gameObject);
			}

			else
			{
				powerStack = other.gameObject.GetComponent<PowerUp>().connectPow;
				timer = 20;
				slimePower = 25;
				Destroy(other.gameObject);
			}
		}
	}

	void Update()
	{
		pointText.text = "Score: " + points;
		powerUpText.text = "Power: " + powerStack;
		if (powerStack >= 100)
		{
			timer -= Time.deltaTime;

			if (timer < 0)
			{
				powerStack = 0;
				timer = 20;
				slimePower = 0;
			}

			powerUpText.text = "Power: Full Charge";
		}
	}
}
