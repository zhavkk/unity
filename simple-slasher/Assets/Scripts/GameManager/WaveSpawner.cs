using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WaveSpawner : MonoBehaviour
{
    [Header("Spawn Settings")]
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float timeBetweenWaves = 10f;
    [SerializeField] private float timeBetweenEnemies = 1f;

    [Header("Wave Configuration")]
    [SerializeField] private int startEnemyCount = 3;
    [SerializeField] private int enemyIncreasePerWave = 2;
    [SerializeField] private float healthIncreasePerWave = 1.2f;
    [SerializeField] private float damageIncreasePerWave = 1.1f;

    [Header("References")]
    [SerializeField] private Transform player;

    private int currentWave = 0;
    private int enemiesRemaining;
    private bool isSpawning = false;
    private List<GameObject> activeEnemies = new List<GameObject>();

    private void Start()
    {
        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player")?.transform;

        StartCoroutine(StartFirstWave());
    }

    private IEnumerator StartFirstWave()
    {
        yield return new WaitForSeconds(2f);
        StartWave();
    }

    private void Update()
    {
        // Clean up dead enemies from list
        activeEnemies.RemoveAll(enemy => enemy == null);

        // Check if wave is complete
        if (!isSpawning && enemiesRemaining <= 0 && activeEnemies.Count == 0)
        {
            StartCoroutine(StartNextWave());
        }
    }

    private IEnumerator StartNextWave()
    {
        yield return new WaitForSeconds(timeBetweenWaves);
        StartWave();
    }

    private void StartWave()
    {
        if (isSpawning) return;

        currentWave++;
        isSpawning = true;

        // Calculate wave difficulty
        int enemyCount = startEnemyCount + (currentWave - 1) * enemyIncreasePerWave;
        enemiesRemaining = enemyCount;

        // Update UI
        if (UIManager.Instance != null)
        {
            UIManager.Instance.UpdateWave(currentWave);
        }

        Debug.Log($"Starting Wave {currentWave} with {enemyCount} enemies");

        StartCoroutine(SpawnEnemies(enemyCount));
    }

    private IEnumerator SpawnEnemies(int count)
    {
        for (int i = 0; i < count; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(timeBetweenEnemies);
        }

        isSpawning = false;
    }

    private void SpawnEnemy()
    {
        if (spawnPoints == null || spawnPoints.Length == 0)
        {
            Debug.LogWarning("No spawn points set!");
            return;
        }

        // Choose random spawn point
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        // Spawn enemy
        GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);

        // Configure enemy based on wave
        EnemyController enemyController = enemy.GetComponent<EnemyController>();
        if (enemyController != null)
        {
            // Scale enemy stats based on wave
            float healthMultiplier = Mathf.Pow(healthIncreasePerWave, currentWave - 1);
            float damageMultiplier = Mathf.Pow(damageIncreasePerWave, currentWave - 1);

            // Note: You may need to expose health/damage fields in EnemyController
            // or use reflection/modifier methods to scale stats
        }

        activeEnemies.Add(enemy);
    }

    public void OnEnemyKilled()
    {
        enemiesRemaining--;
        Debug.Log($"Enemy killed! Remaining: {enemiesRemaining}");
    }

    public int GetCurrentWave()
    {
        return currentWave;
    }

    public int GetEnemiesRemaining()
    {
        return enemiesRemaining;
    }

    private void OnDrawGizmosSelected()
    {
        // Draw spawn points
        if (spawnPoints != null)
        {
            Gizmos.color = Color.cyan;
            foreach (Transform spawnPoint in spawnPoints)
            {
                if (spawnPoint != null)
                {
                    Gizmos.DrawWireSphere(spawnPoint.position, 1f);
                }
            }
        }
    }
}
