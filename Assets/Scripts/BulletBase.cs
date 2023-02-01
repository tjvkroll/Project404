using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBase : MonoBehaviour
{

    public float TTL, speed, damage, knockBack, explosionPower;
    public bool piercing, explosive, isFriendly; 

    // Update is called once per frame
    void FixedUpdate()
    {
        TTL -= Time.deltaTime;
        if(TTL <= 0){
            // can add explosion before or after destroy
            Destroy(this.gameObject); 
        }

        transform.position += transform.forward * speed;  
    }
}


