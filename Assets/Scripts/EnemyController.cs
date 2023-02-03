using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
  public Transform playerTrans;
  public CharacterController mycontroller;
  public float moveSpeed;
  public float gravity;
  public float attackRange;
  private Vector3 movement;

  [GradientUsageAttribute(true)]
  public Gradient onHitBodyGradient;

  public float flashOnHitDuration = 0.5f;
  void Start()
  {
    mycontroller = GetComponent<CharacterController>();
    playerTrans = GameObject.FindGameObjectWithTag("Player").transform;
  }

  void FixedUpdate()
  {
    // Look at
    transform.LookAt(playerTrans, Vector3.up);

    // Move towards
    if (Vector3.Distance(playerTrans.position, transform.position) > attackRange)
    {
      transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
      movement = transform.forward * moveSpeed;
    }

    // Gravity
    movement.y += gravity;
    mycontroller.Move(movement);
    movement.Scale(new Vector3(0.75f, .99f, 0.75f));
  }

  public void OnTakeDamage(float dummy)
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
