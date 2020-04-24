using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float minTimeBetweenSpawns = 1, maxTimeBetweenSpawns = 2f;
    [SerializeField] private Transform[] spawnPoints = default;
    [SerializeField] private List<GameObject> enemiesToSpawn = new List<GameObject>();

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
        GameObject randomEnemy = enemiesToSpawn[Random.Range(0, enemiesToSpawn.Count)];
        Transform randomTransform = spawnPoints[Random.Range(0, spawnPoints.Length)];

        Instantiate(randomEnemy, randomTransform.position, Quaternion.identity);

        yield return new WaitForSeconds(timeUntilNextSpawn);

        canSpawn = true;
    }

    public void ChangeTiming(float newMinTime, float newMaxTime)
    {
        minTimeBetweenSpawns = newMinTime;
        maxTimeBetweenSpawns = newMaxTime;
    }

    public void AddEnemyToSpawnList(GameObject enemy)
    {
        enemiesToSpawn.Add(enemy);
    }
}
