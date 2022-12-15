using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeProjectile : MonoBehaviour
{
    public int fullDamage;
    public int projDamage;
    public int elemDamage;
    public int damageOverTime;
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
    }
}
