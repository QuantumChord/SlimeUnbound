using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlimeScript : MonoBehaviour
{
	public Text pointText;

	public int powerStack;

    public int points;
	void Start()
	{
        points = 0;
		powerStack = 0;
		pointText.text = "Score: 0";
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

	public void PowerAwakening()
	{
		if (powerStack <= 4)
		{

		}
	}

	void Update()
	{
		pointText.text = "Score: " + points;
	}
}
