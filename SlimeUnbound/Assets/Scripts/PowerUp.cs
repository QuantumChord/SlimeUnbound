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

    void Start()
    {
        slimeUpAmount = powerUpAmount;

        if (powerUpTypeList == powerUpType.fire) 
        {
            connectPow = 1;
        }

        else if(powerUpTypeList == powerUpType.ice)
		{
            connectPow = 2;
        }

        else if (powerUpTypeList == powerUpType.rock)
        {
            connectPow = 3;
        }

		else
		{
            connectPow = 0;
        }
    }
}
