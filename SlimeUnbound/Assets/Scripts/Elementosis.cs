using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elementosis : MonoBehaviour
{
    public int element;
    public int elementStack;
    public int effect;
    public double damageOverTime;

    void Start()
    {
        element = 0;
        elementStack = 0;
        effect = 0;
        damageOverTime = 0;
    }

    public void elementLoader()
    {
        if (elementStack <= 100)
        {
            if (element == 1)
            {
                effect = 2;
            }

            else if (element == 2)
            {
                effect = 2;
            }

            else if (element == 3)
            {
                effect = 3;
            }

            else
            {
                effect = 0;
            }
        }
    }

    public void elementDamageOverTime()
    {
        if (effect == 1)
        {
            damageOverTime = 2.5;
        }

        else if (effect == 2)
        {
            damageOverTime = 1.5;
        }

        else
        {
            damageOverTime = 0;
        }
    }

    void Update()
    {
        element = GetComponent<SlimeScript>().slimePower;
        elementStack = GetComponent<SlimeScript>().powerStack;
    }
}
