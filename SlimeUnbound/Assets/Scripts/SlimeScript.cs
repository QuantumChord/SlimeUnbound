using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeScript : MonoBehaviour
{
    public int points;

    // Start is called before the first frame update
    void Start()
    {
        points = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Collectibles")
		{
            points++;
            Destroy(other.gameObject);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
