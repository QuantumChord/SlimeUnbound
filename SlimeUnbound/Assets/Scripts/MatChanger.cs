using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatChanger : MonoBehaviour
{
    public Material[] slimeMat;

    public int boostLevel;
    public int slimeBoost;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().material = slimeMat[3];
    }

    // Update is called once per frame
    void Update()
    {
        boostLevel = GetComponent<SlimeScript>().powerStack;
        slimeBoost = GetComponent<SlimeScript>().slimePower;

        if (boostLevel >= 100 && slimeBoost == 1)
        {
            GetComponent<Renderer>().material = slimeMat[0];
        }

        else if (boostLevel >= 100 && slimeBoost == 2)
        {
            GetComponent<Renderer>().material = slimeMat[1];
        }

        else if (boostLevel >= 100 && slimeBoost == 3)
        {
            GetComponent<Renderer>().material = slimeMat[2];
        }

        else
        {
            GetComponent<Renderer>().material = slimeMat[3];
        }
    }
}
