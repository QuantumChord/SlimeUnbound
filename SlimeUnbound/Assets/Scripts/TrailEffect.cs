using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailEffect : MonoBehaviour
{
    public TrailRenderer trail;
    public GameObject trailFollower;
    public GameObject colliderPrefab;

    public int poolSize = 5;
    GameObject[] pool;

    void Start()
    {
        trail = GetComponent<TrailRenderer>();
        pool = new GameObject[poolSize];
        for(int i = 0; i<pool.Length; i++)
        {
            pool[i] = Instantiate(colliderPrefab);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!trail.isVisible)
        {
            for(int i = 0; i < pool.Length; i++)
            {
                pool[i].gameObject.SetActive(false);
            }
        }

        else
        {
            TrailCollission();
        }
    }

    void TrailCollission()
    {
        for(int i = 0; i < pool.Length; i++)
        {
            if(pool[i].gameObject.activeSelf == false)
            {
                pool[i].gameObject.SetActive(true);
                pool[i].gameObject.transform.position = trailFollower.gameObject.transform.position;
                return;
            }
        }
    }
}
