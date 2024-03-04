using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class EnemySpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject[] spawnPoints;

    public int totalSpawnCount = 25;
    public int spawnCount = 0;
    private float spawnDelay;

    private void Start()
    {
        spawnCount = totalSpawnCount;
    }

    public void resetSpawnCount()
    {
        spawnCount = totalSpawnCount;
    }

    public void StartSpawningEnemies()
    {
        StartCoroutine(SpawnEnemies());
    }

    public int GetSpawnCount()
    {
        return totalSpawnCount;
    }

    public void StopSpawningEnemies()
    {
        StopAllCoroutines();
    }

    public void DestroyAllEnemies()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject enemy in enemies)
        {
            Destroy(enemy);
        }
    }

    public void ScaleSpawnCount(float scale)
    {
        totalSpawnCount = Mathf.FloorToInt(totalSpawnCount * scale);
    }

    IEnumerator SpawnEnemies()
    {
        spawnDelay = 50.0f / totalSpawnCount;
        while (spawnCount > 0)
        {
            GameObject currentSpawnPoint = spawnPoints[Random.Range(0, 2)];
            GameObject currentEnemy = Instantiate(enemyPrefab, currentSpawnPoint.transform.position, Quaternion.identity);
            spawnCount--;
            yield return new WaitForSeconds(spawnDelay);
        }
        
    }
}
