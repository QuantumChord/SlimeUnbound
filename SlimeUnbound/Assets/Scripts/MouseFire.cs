using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFire : MonoBehaviour
{
    public Vector2 turn;

	void Start()
	{
		Cursor.lockState = CursorLockMode.Locked;
	}

	// Update is called once per frame
	void Update()
    {
        turn.x += Input.GetAxis("Mouse X");
        turn.y += Input.GetAxis("Mouse Y");

        transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0);
    }
}
