using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantScript : MonoBehaviour
{
    public GameObject poisonSpot;

    public Transform[] tunnelArray;
    public Vector3 offset = new Vector3(0, 10, 0);
    public int plantStatus;
    public float plantTime;
    public float plantInSeconds = 1f;
    public int plantIndex;
    public int secondIndex;

    public int health;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = tunnelArray[0].transform.position;
        plantStatus = 0;
    }

    // Update is called once per frame
    void Update()
    {

        //Creates a tunneling system for the Plant based on time.
        plantTime += Time.deltaTime * plantInSeconds;

        if (plantStatus == 0 && plantTime >= 10)
        {
            PlantTunnel();
            plantTime = 0;
        }

        if (plantStatus == 1 && plantTime >= 5)
		{
            PlantUntunnel();
            plantTime = 0;
		}

		if (plantStatus == 2 && plantTime >= 2)
        {
            plantStatus = 0;
            plantTime = 0;
		}
    }

    //The "Tunnelling" section for the Plant. Plant burrows down, selects spot before coming up in later section.
    public void PlantTunnel()
	{
        plantIndex = Random.Range(0, 3);

        if(secondIndex == plantIndex && plantStatus == 0)
		{
            plantIndex = Random.Range(0, 3);
        }

        if(secondIndex !=plantIndex && plantStatus == 0)
		{
            plantStatus = 1;
            secondIndex = plantIndex;
		}

        if (plantIndex == 0)
		{
            transform.position = tunnelArray[0].transform.position - offset;
        }

        else if(plantIndex == 1)
		{
            transform.position = tunnelArray[1].transform.position - offset;
        }
        else if (plantIndex == 2)
        {
            transform.position = tunnelArray[2].transform.position - offset;
        }

		else
		{
            transform.position = tunnelArray[3].transform.position - offset;
        }

    }

    public void PlantUntunnel()
	{
        plantStatus = 2;
        if (plantIndex == 0)
        {
            transform.position = tunnelArray[0].transform.position;
        }

        else if (plantIndex == 1)
        {
            transform.position = tunnelArray[1].transform.position;
        }
        else if (plantIndex == 2)
        {
            transform.position = tunnelArray[2].transform.position;
        }

        else
        {
            transform.position = tunnelArray[3].transform.position;
        }
    }
}
