using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damagable : MonoBehaviour
{
  public bool isFriendly = false;
  void Start()
  {

  }
  private void OnTriggerEnter(Collider other)
  {
    if (other.CompareTag("Bullet"))
    {
      BulletBase bb = other.GetComponent<BulletBase>();
      if (bb.isFriendly == isFriendly) { return; }
      if (!bb.piercing)
      {
        Destroy(other.gameObject);
      }
      BroadcastMessage("OnTakeDamage", bb.damage, SendMessageOptions.DontRequireReceiver);
    }
  }
}
