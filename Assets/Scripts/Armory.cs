using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armory : MonoBehaviour
{
    public List<GunBase> guns;

    // Here is where we can alternate gunfire or shoot two at once or etc etc.
    public void OnShoot()
    {
        foreach (GunBase gun in guns)
        {
            gun.OnShoot();
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
