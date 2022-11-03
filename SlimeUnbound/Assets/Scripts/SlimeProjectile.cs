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

    void Start()
    {
        projDamage = 4;
        elemDamage = 0;
        damageOverTime = 0;
        slimeBulletType = 0;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Terrain")
        {
            Destroy(gameObject);
        }

        if (collision.collider.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }

    public void elementalDamage()
    {

        slimeBulletType = GetComponent<SlimeScript>().slimePower;

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
        fullDamage = projDamage + elemDamage;
    }
}
