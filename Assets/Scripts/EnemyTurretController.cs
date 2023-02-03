using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurretController : MonoBehaviour
{
  public Transform playerTrans;
  public float attackRange;
  public Transform turretTransform;

  [GradientUsageAttribute(true)]
  public Gradient onHitBodyGradient;

  public float flashOnHitDuration = 0.5f;
  public Armory armory;
  void Start()
  {
    playerTrans = GameObject.FindGameObjectWithTag("Player").transform.Find("LockOnSnap");
    armory = GetComponentInChildren<Armory>();
  }

  void FixedUpdate()
  {
    // Look at
    turretTransform.LookAt(playerTrans, Vector3.up);
    if (Vector3.Distance(playerTrans.position, transform.position) <= attackRange)
    {
      armory.OnShoot();
    }
  }

  public void OnTakeDamage()
  {
    StartCoroutine(DamageBlink(1));
  }

  public void OnDeath()
  {
    Destroy(this.gameObject);
  }

  IEnumerator DamageBlink(int blinkCount)
  {
    Material mat = GetComponentInChildren<Renderer>().material;
    for (int i = 0; i < blinkCount; i++)
    {
      float blink_start = Time.time;
      while (Time.time - blink_start < flashOnHitDuration)
      {
        Color currentColor = onHitBodyGradient.Evaluate((Time.time - blink_start) / flashOnHitDuration);
        mat.SetColor("_EmissionColor", currentColor);
        yield return null;
      }
    }
    mat.SetColor("_EmissionColor", Color.black);
  }

  void OnDrawGizmosSelected()
  {
    Gizmos.color = Color.red;
    Gizmos.DrawWireSphere(transform.position, attackRange);
  }

}
