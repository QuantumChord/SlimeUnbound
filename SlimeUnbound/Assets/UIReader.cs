using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIReader : MonoBehaviour
{
    public SlimeScript slime;
    public Text score;

    void Start()
	{
        slime = GameObject.FindGameObjectWithTag("Player").GetComponent<SlimeScript>();
        
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Score: " + slime.points;
    }
}
