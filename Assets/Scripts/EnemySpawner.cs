using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float minTimeBetweenSpawns = 1f, maxTimeBetweenSpawns = 3f;
    [SerializeField] private Transform[] spawnPoints = default;
    [SerializeField] private GameObject[] enemiesToSpawn = default;

    private bool canSpawn = true;

    private void Update()
    {
        if (canSpawn && LevelManager.Instance.player != null)
        {
            canSpawn = false;
            StartCoroutine(SpawnRoutine());
        }
    }

    IEnumerator SpawnRoutine()
    {
        float timeUntilNextSpawn = Random.Range(minTimeBetweenSpawns, maxTimeBetweenSpawns);
        GameObject randomEnemy = enemiesToSpawn[Random.Range(0, enemiesToSpawn.Length)];
        Transform randomTransform = spawnPoints[Random.Range(0, spawnPoints.Length)];

        Instantiate(randomEnemy, randomTransform.position, Quaternion.identity);

        yield return new WaitForSeconds(timeUntilNextSpawn);

        canSpawn = true;
    }
}
