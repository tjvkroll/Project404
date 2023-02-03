using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour
{
    public float maxHP;
    public float currentHP;
    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
    }

    public void OnDamage(float amt)
    {
        currentHP -= amt;
        if (currentHP <= 0) Destroy(this.gameObject);
    }
}
