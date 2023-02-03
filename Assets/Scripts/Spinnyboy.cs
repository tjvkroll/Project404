using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinnyboy : MonoBehaviour
{
    void FixedUpdate()
    {
        transform.Rotate(new Vector3(0, 5, 0), Space.Self);
    }
}
