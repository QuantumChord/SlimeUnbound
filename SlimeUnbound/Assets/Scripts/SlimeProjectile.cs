using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeProjectile : MonoBehaviour
{
    public int fullDamage;
    public int projDamage;
    public int elemDamage;
    public float damageOverTime;
    public int slimeBulletType;

    void Start()
    {
        projDamage = 1;
    }

	public void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Terrain"))
		{
            Destroy(gameObject);
		}

		if (other.CompareTag("BatEnemy"))
		{
            other.GetComponent<BatEnemy>().Damage(fullDamage);
            Destroy(gameObject);
        }

        if (other.CompareTag("SpiderEnemy"))
        {
            other.GetComponent<SpiderEnemy>().Damage(fullDamage);
            Destroy(gameObject);
        }
    }

	public void ElementalDamage()
    {
        if (slimeBulletType == 1)
        {
            elemDamage = 1;
            //damageOverTime = 0.3;
        }

        else if (slimeBulletType == 2)
        {
            elemDamage = 2;
            //damageOverTime = 0.15;
        }

        else if (slimeBulletType == 3)
        {
            elemDamage = 3;
            //damageOverTime = 0;
        }
        else
        {
            elemDamage = 0;
            //damageOverTime = 0;
        }
    }

    void Update()
    {
        fullDamage = projDamage + elemDamage;
    }
}
