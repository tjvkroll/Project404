using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy_prefab;
    public float spawnRadius;
    public float timebetweenspawns = .05f;
    private bool currentlySpawning;

    public void SpawnEnemy(int count)
    {
        if (currentlySpawning) return;
        StartCoroutine(spawnEnemiesCoroutine(count));
    }

    IEnumerator spawnEnemiesCoroutine(int count)
    {
        currentlySpawning = true;
        int spawned = 0;
        while (spawned < count)
        {
            float timetowait = 0;
            // Pick location in spawn radius
            Vector3 potential_location = new Vector3(
                transform.position.x + Random.Range(-spawnRadius, spawnRadius),
                transform.position.y,
                transform.position.z + Random.Range(-spawnRadius, spawnRadius));
            // Check if there's a mob there?
            bool mob_present = false;
            // if no, spawn.
            if (!mob_present)
            {
                Instantiate(enemy_prefab, potential_location, Quaternion.identity);
                spawned++;
                // timetowait = Random.Range(.01f, .2f);
                timetowait = timebetweenspawns;
            }
            yield return new WaitForSecondsRealtime(timetowait);
        }
        currentlySpawning = false;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, spawnRadius);
    }
}
