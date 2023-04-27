using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GooingEffect : MonoBehaviour
{
    public int gooingType;

    public float reduceSpeed = 5f;

    // Update is called once per frame
    void Update()
    {
        //gooingType = GetComponent<PlayerScript>().slimeType;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SpiderEnemy"))
        {
            other.GetComponent<SpiderEnemy>().gooingTrigger = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("SpiderEnemy"))
        {
            other.GetComponent<SpiderEnemy>().gooingTrigger = false;
        }
    }
}
