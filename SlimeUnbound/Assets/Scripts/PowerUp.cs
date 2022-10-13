using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum powerUpType { fire, ice, rock, blank };

public class PowerUp : MonoBehaviour
{
    public powerUpType powerUpTypeList;
    public static int slimeUpAmount;
    public int powerUpAmount;
    public int connectPow;
    public int poweringSlime;

    private Renderer powerColor;

    void Start()
    {
        powerColor = GetComponent<Renderer>();
        slimeUpAmount = powerUpAmount;

        if (powerUpTypeList == powerUpType.fire) 
        {
            powerColor.material.color = new Color(1f, 0f, 0f, 1f);
            connectPow = 1;
        }

        else if(powerUpTypeList == powerUpType.ice)
		{
            powerColor.material.color = new Color(0f, 1f, 1f, 1f);
            connectPow = 2;
        }

        else if (powerUpTypeList == powerUpType.rock)
        {
            powerColor.material.color = new Color(1f, 0.92f, 0.016f, 1f);
            connectPow = 3;
        }

		else
		{
            powerColor.material.color = new Color(1f, 1f, 1f, 1f);
            connectPow = 0;
        }
    }
}
