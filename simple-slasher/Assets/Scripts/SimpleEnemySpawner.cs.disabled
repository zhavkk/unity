using UnityEngine;
using System.Collections.Generic;

public class SimpleEnemySpawner : MonoBehaviour
{
    [Header("Spawn Settings")]
    public GameObject enemyPrefab;
    public float spawnRate = 3f;
    public int maxEnemies = 10;
    public float spawnRadius = 20f;
    public float minDistanceFromPlayer = 5f;

    [Header("Wave Settings")]
    public bool useWaveSystem = true;
    public int enemiesPerWave = 5;
    public float waveInterval = 10f;
    public int currentWave = 1;

    private float nextSpawnTime;
    private float nextWaveTime;
    private List<GameObject> activeEnemies = new List<GameObject>();

    void Update()
    {
        // Handle wave system
        if (useWaveSystem)
        {
            HandleWaveSpawning();
        }
        else
        {
            // Continuous spawning
            if (Time.time >= nextSpawnTime && activeEnemies.Count < maxEnemies)
            {
                SpawnEnemy();
                nextSpawnTime = Time.time + spawnRate;
            }
        }
    }

    void HandleWaveSpawning()
    {
        // Check if wave should start
        if (Time.time >= nextWaveTime)
        {
            StartWave();
        }
    }

    void StartWave()
    {
        Debug.Log("Starting Wave " + currentWave);

        // Spawn enemies for this wave
        int enemiesToSpawn = enemiesPerWave * currentWave;

        for (int i = 0; i < enemiesToSpawn && activeEnemies.Count < maxEnemies; i++)
        {
            SpawnEnemy();
        }

        // Schedule next wave
        nextWaveTime = Time.time + waveInterval;
        currentWave++;
    }

    void SpawnEnemy()
    {
        Vector3 spawnPosition = GetRandomSpawnPosition();

        GameObject enemy;

        if (enemyPrefab != null)
        {
            // Use prefab
            enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }
        else
        {
            // Create enemy dynamically
            enemy = new GameObject("Enemy");
            enemy.transform.position = spawnPosition;
            enemy.tag = "Enemy";

            // Add SimpleEnemy component
            SimpleEnemy enemyScript = enemy.AddComponent<SimpleEnemy>();

            // Add collider
            BoxCollider collider = enemy.AddComponent<BoxCollider>();
            collider.size = new Vector3(1f, 2f, 1f);
            collider.center = new Vector3(0, 1f, 0);
        }

        activeEnemies.Add(enemy);

        // Clean up dead enemies
        CleanupDeadEnemies();

        Debug.Log("Spawned enemy at: " + spawnPosition);
    }

    Vector3 GetRandomSpawnPosition()
    {
        Vector3 playerPosition = Vector3.zero;

        SimplePlayerController player = FindAnyObjectByType<SimplePlayerController>();
        if (player != null)
        {
            playerPosition = player.transform.position;
        }

        Vector3 randomDirection = Random.insideUnitSphere * spawnRadius;
        randomDirection.y = 0;

        Vector3 spawnPosition = playerPosition + randomDirection;

        // Ensure minimum distance from player
        float distance = Vector3.Distance(spawnPosition, playerPosition);
        if (distance < minDistanceFromPlayer)
        {
            spawnPosition = (spawnPosition - playerPosition).normalized * minDistanceFromPlayer + playerPosition;
        }

        return spawnPosition;
    }

    void CleanupDeadEnemies()
    {
        for (int i = activeEnemies.Count - 1; i >= 0; i--)
        {
            if (activeEnemies[i] == null)
            {
                activeEnemies.RemoveAt(i);
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        // Draw spawn radius
        Gizmos.color = Color.green;
        Vector3 center = transform.position;

        SimplePlayerController player = FindAnyObjectByType<SimplePlayerController>();
        if (player != null)
        {
            center = player.transform.position;
        }

        Gizmos.DrawWireSphere(center, spawnRadius);

        // Draw minimum distance from player
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(center, minDistanceFromPlayer);
    }
}
