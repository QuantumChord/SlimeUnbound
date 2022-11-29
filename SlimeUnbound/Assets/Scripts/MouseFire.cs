using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFire : MonoBehaviour
{
    public float projectileSpeed = 20f;
    public GameObject projectile;
    public GameObject projectileZone;
    public Transform projectilePoint;
    public Vector3 projectileOriginPosition;
    void Start()
	{
		Cursor.lockState = CursorLockMode.Locked;
	}

	// Update is called once per frame
	void Update()
    {

        Vector3 targetPosition = Camera.main.transform.TransformPoint(Vector3.forward * 500);
        Vector3 projectileOriginPosition = projectileZone.transform.position;
        Quaternion projectileRotation = Quaternion.LookRotation(targetPosition - projectileOriginPosition);


        if (Input.GetButtonDown("Fire1"))
        {
            GameObject bullet = Instantiate(projectile, projectileOriginPosition, projectileRotation);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.AddForce(projectilePoint.forward * projectileSpeed, ForceMode.Impulse);
        }
    }
}
