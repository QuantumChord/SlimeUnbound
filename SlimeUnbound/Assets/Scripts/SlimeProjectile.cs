using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeProjectile : MonoBehaviour
{
    public double fullDamage;
    public double projDamage;
    public double elemDamage;
    public double damageOverTime;
    public int slimeBulletType;

    public float speed;

    void Start()
    {
        projDamage = 4;
    }

	public void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Terrain"))
		{
            Destroy(gameObject);
		}
    }

	public void ElementalDamage()
    {
        if (slimeBulletType == 1)
        {
            elemDamage = 2;
            damageOverTime = 2;
        }

        else if (slimeBulletType == 2)
        {
            elemDamage = 3;
            damageOverTime = 1;
        }

        else if (slimeBulletType == 3)
        {
            elemDamage = 4;
            damageOverTime = 0;
        }
        else
        {
            elemDamage = 0;
            damageOverTime = 0;
        }
    }

    void Update()
    {
        ElementalDamage();

        fullDamage = projDamage + elemDamage;
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * speed, ForceMode.Impulse);
    }
}
