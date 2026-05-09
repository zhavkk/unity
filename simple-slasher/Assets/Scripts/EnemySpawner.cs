using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Spawn Settings")]
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private int spawnCount = 5;
    [SerializeField] private float spawnRadius = 20f;
    [SerializeField] private float minDistanceFromPlayer = 5f;

    [Header("Respawn Settings")]
    [SerializeField] private bool autoRespawn = true;
    [SerializeField] private float respawnDelay = 3f;

    private int currentEnemyCount = 0;

    private void Start()
    {
        SpawnEnemies();
    }

    private void SpawnEnemies()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            SpawnSingleEnemy();
        }
    }

    private GameObject SpawnSingleEnemy()
    {
        Vector3 spawnPosition = GetRandomSpawnPosition();
        GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

        currentEnemyCount++;

        // Subscribe to enemy death event (optional, if you add events to EnemyController)
        EnemyController enemyController = enemy.GetComponent<EnemyController>();
        if (enemyController != null && autoRespawn)
        {
            StartCoroutine(RespawnEnemyAfterDelay(enemy));
        }

        return enemy;
    }

    private Vector3 GetRandomSpawnPosition()
    {
        Vector3 playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        Vector3 randomPosition;

        int attempts = 0;
        int maxAttempts = 10;

        do
        {
            // Generate random position within radius
            Vector2 randomCircle = Random.insideUnitCircle * spawnRadius;
            randomPosition = new Vector3(randomCircle.x, 0, randomCircle.y) + playerPosition;

            attempts++;
        } while (Vector3.Distance(randomPosition, playerPosition) < minDistanceFromPlayer && attempts < maxAttempts);

        return randomPosition;
    }

    private System.Collections.IEnumerator RespawnEnemyAfterDelay(GameObject enemy)
    {
        // Wait until enemy is destroyed
        while (enemy != null)
        {
            yield return new WaitForSeconds(0.5f);
        }

        yield return new WaitForSeconds(respawnDelay);
        SpawnSingleEnemy();
    }

    public void SpawnAdditionalEnemy()
    {
        SpawnSingleEnemy();
    }

    public void IncreaseSpawnCount(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            SpawnSingleEnemy();
        }
    }
}
