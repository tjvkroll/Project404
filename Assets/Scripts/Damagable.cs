using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damagable : MonoBehaviour
{
    HP hp;
    void Start()
    {
        hp = GetComponent<HP>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            BulletBase bb = other.GetComponent<BulletBase>();
            if (!bb.piercing)
            {
                Destroy(other.gameObject);
            }
            hp.OnDamage(bb.damage);
        }
    }
}
