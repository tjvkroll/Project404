using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GunBase : MonoBehaviour
{

    public float damage, knockBack, fireRate, speed, explosionPower, TTL;
    private float timer;
    public bool explosive, isFriendly, piercing, canFire;
    public GameObject bullet;
    public UnityEvent OnShotCreated;



    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > fireRate)
        {
            canFire = true;
        }
    }

    public void CreateBullet(Vector3 pos, Quaternion rot)
    {
        GameObject go = Instantiate(bullet, pos, rot);
        BulletBase bb = go.GetComponent<BulletBase>();
        bb.damage = damage;
        bb.explosionPower = explosionPower;
        bb.speed = speed;
        bb.knockBack = knockBack;
        bb.TTL = TTL;
        bb.piercing = piercing;
        bb.explosive = explosive;
        bb.isFriendly = isFriendly;
    }

    public void OnShoot()
    {
        if (!canFire)
        {
            return;
        }
        CreateBullet(transform.position, transform.rotation);
        OnShotCreated.Invoke();
        timer = 0;
        canFire = false;
    }


}
