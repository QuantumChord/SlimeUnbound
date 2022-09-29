using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public enum powerUpType { Fire, Ice, Rock };
    public powerUpType powerUpTypeList;
    public int powerUpAmount;

    private Renderer powerColor;

    void Start()
    {
        powerColor = GetComponent<Renderer>();

        if(powerUpTypeList = powerUpType.Fire)
        {
            powerColor.material.color = new Color(1f, 0f, 0f, 1f);
        }
        
    }
}
