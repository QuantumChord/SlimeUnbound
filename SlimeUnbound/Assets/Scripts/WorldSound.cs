using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSound : MonoBehaviour
{
    public PlayerScript player;

    public AudioSource worldAudio;

    public int audioInt;

    // Start is called before the first frame update
    void Start()
    {
        worldAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.domainArea == audioInt)
        {
            worldAudio.Play();
        }

        else
        {
            worldAudio.Stop();
        }
    }
}
